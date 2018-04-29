using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Boundary 
{
   public float xMax, xMin, yMax, yMin;
}
enum BoltType
{
    ordinary,
    tripple
}
public class PlayerMove : MonoBehaviour {
    public event Action GameOver_PlayerDead;

    public string PlayerName;
    
    public List<GameObject> redSqureImages; //  红：生命
    public List<GameObject> blueSqureImages;    //  蓝：大招
    public GameObject[] bonusSqureImages;   //  黄：子弹级别
    public AudioClip[] audioClips;
    
    //  红相关
    public int health = 1;
    public int livesInitialCount;
    public float reDamagePeriod;

    //  蓝相关
    public GameObject ultimateSkill;
    public float ultimateDuration;
    public float ultimateCoolingTime;
    public int ultimateInitialCount;
    
    //  黄相关
    public Transform[] shotSpawn_0;
    public Transform[] shotSpawn_1;
    public Transform[] shotSpawn_2;
    public Transform[] shotSpawn_3;
    public Transform[] shotSpawn_4;
    public Transform[] shotSpawn_5;

    public int level = 0;
    public GameObject deadExplosion;
    public float fireRate;
    public GameObject bolt_Ordinary;
    public GameObject bolt_Tripple;
    public float ultimateDamageAmount;

    //  高、低速
    public float normalSpeed;
    public float slowerSpeed;
    public GameObject slowRing;
    
    //  运动范围
    public Boundary boundary;

    private float speed;
    private float nextFire = 0f;
    private float nextUltimate = 0f;
    private BoltType boltType = BoltType.ordinary;
    private Dictionary<int, Transform[]> shotSpawnsDic = new Dictionary<int, Transform[]>();
    private int ultimateCurCount;
    public int livesCurCount;
    private float nextDamage = 0f;
    private bool isDead = false;
    private bool isUnmatched = false;

    private CountDownForWholeLevel_0 enemyWavesManager;

    private void OnEnable() {
        this.GameOver_PlayerDead += OnGameOver_PlayerDead;
    }

    private void OnDisable() {
        this.GameOver_PlayerDead -= OnGameOver_PlayerDead;
    }

    void Awake () 
    {
        InitPropertiesInfo();
        InitShotSpawnsList();
	}

	void Update () 
    {
        BonusSqureControl(level);   //  根据当前子弹级别，控制能量块的显示个数

        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)    //  普通射击
        {
            nextFire = Time.time + fireRate;
            ShootSpawnsControl(level);  //  根据当前子弹级别开启相应的发射口

            GetComponent<AudioSource>().clip = audioClips[0];
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKey(KeyCode.LeftShift))   //  低速模式
        {
            speed = slowerSpeed;    //  速度降低
            slowRing.SetActive(true);   //  显示低速光环
        }
        else if (Input.GetKey(KeyCode.X) && Time.time > nextUltimate && ultimateCurCount > 0)   //  开启大招
        {
            nextUltimate = Time.time + ultimateCoolingTime; //  设置好下一次大招的冷却时间
            StartCoroutine(CastUltimateSkill());    //  大招开启，一段时间后消失
            BlueSqureMinus();   //  耗蓝

            GetComponent<AudioSource>().clip = audioClips[1];
            GetComponent<AudioSource>().Play();
        }
        else if(Input.GetKey(KeyCode.Alpha1))
        {
            isUnmatched = true;
        }
        else if(Input.GetKey(KeyCode.Alpha2))
        {
            isUnmatched = false;
        }
        else if(Input.GetKey(KeyCode.Alpha3))
        {
            livesCurCount = 8;
            ultimateCurCount = 8;
            level = 5;
            BonusSqureControl(level);
            ShootSpawnsControl(level);
            UpdateRedImages(livesCurCount);
            UpdateBlueImages(ultimateCurCount);
        }
        else
        {
            speed = normalSpeed;    //  高速模式
            slowRing.SetActive(false);  //  低速光环被隐藏
        }
	}

    //  运动控制
    void FixedUpdate()
    { 
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(h, v);

        GetComponent<Rigidbody2D>().velocity = move * speed;

        GetComponent<Rigidbody2D>().position = new Vector2
            (
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
            );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBolt" || other.tag == "EnemyAndBolt")
        {
            if(livesCurCount > 0 && Time.time > nextDamage && !isUnmatched)
            {
                nextDamage = Time.time + reDamagePeriod;
                Dead();
            } else if (livesCurCount <= 0){
                if (GameOver_PlayerDead != null) {
                    GameOver_PlayerDead();
                }
            }
        }
    }

    void Dead()
    {
        GetComponent<AudioSource>().clip = audioClips[2];
        GetComponent<AudioSource>().Play();

        GetComponent<Animator>().SetTrigger("isDead");  //  重生动画

        Instantiate(deadExplosion, transform.position, Quaternion.identity);
        RedSqureMinus();
    }

    void ShootSpawnsControl(int _level) //  发射口控制
    {
        for (int i = 0; i <= _level; i++)
        {
            foreach (Transform singleSpawn in shotSpawnsDic[i])
            {
                Instantiate(bolt_Ordinary, singleSpawn.position, singleSpawn.rotation);
            }
        }
    }

    void BonusSqureControl(int _level)  //  能量块的显示
    {
        for (int i = 0; i < _level; i++ )
        {
            bonusSqureImages[i].SetActive(true);
        }
    }

    /// <summary>
    /// 魔法值管理
    /// </summary>
    IEnumerator CastUltimateSkill() //  开启大招
    {
        ultimateSkill.SetActive(true);
        isUnmatched = true;
        yield return new WaitForSeconds(ultimateDuration);
        ultimateSkill.SetActive(false);
        isUnmatched = false;
    }
    void BlueSqureMinus()   //  耗蓝操作(施放大招后)
    {
        if (ultimateCurCount > 0)
        {
            ultimateCurCount--;
            UpdateBlueImages(ultimateCurCount);
        }
    }
    public void BlueSqureAdd()  //  增蓝操作(拾取蓝块后)
    {
        if(ultimateCurCount < 8)
        {
            ultimateCurCount++;
            UpdateBlueImages(ultimateCurCount);
        }
    }
    void UpdateBlueImages(int activeCount)  //  蓝量发生变化后，更新蓝块显示
    {
        for (int i = 0; i < activeCount; i++)
        {
            blueSqureImages[i].SetActive(true);
        }

        for (int j = activeCount; j < blueSqureImages.Count; j++)
        {
            blueSqureImages[j].SetActive(false);
        }
    }

    /// <summary>
    /// 生命值管理
    /// </summary>
    void RedSqureMinus()    //  耗红操作（死亡）
    {
        if(livesCurCount > 0)
        {
            livesCurCount--;
            UpdateRedImages(livesCurCount);
        }
    }
    public void RedSqureAdd()   //  加红操作（拾取红块）
    {
        if(livesCurCount < 8)
        {
            livesCurCount++;
            UpdateRedImages(livesCurCount);
        }
    }
    void UpdateRedImages(int activeCount)   //  更新红块显示
    {
        for (int i = 0; i < activeCount; i++ )
        {
            redSqureImages[i].SetActive(true);
        }

        for (int j = activeCount; j < redSqureImages.Count; j++ )
        {
            redSqureImages[j].SetActive(false);
        }
    }

    /// <summary>
    /// 初始化操作
    /// </summary>
    void InitShotSpawnsList()   //  将所有发射口保存至字典中
    {
        shotSpawnsDic.Add(0, shotSpawn_0);
        shotSpawnsDic.Add(1, shotSpawn_1);
        shotSpawnsDic.Add(2, shotSpawn_2);
        shotSpawnsDic.Add(3, shotSpawn_3);
        shotSpawnsDic.Add(4, shotSpawn_4);
        shotSpawnsDic.Add(5, shotSpawn_5);
    }

    void InitPropertiesInfo()
    {
        speed = normalSpeed;

        livesCurCount = livesInitialCount;
        UpdateRedImages(livesCurCount);

        ultimateCurCount = ultimateInitialCount;
        UpdateBlueImages(ultimateCurCount);

        enemyWavesManager = GameObject.Find("EnemyMovingModesManager").GetComponent<CountDownForWholeLevel_0>();
    }

    /// <summary>
    /// 其他
    /// </summary>
    private void UsedUpdate()
    {
        //if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        //    {
        //        nextFire = Time.time + fireRate;

        //        foreach(Transform shootPoint in shotSpawn)
        //        {
        //            Instantiate(bolt_Ordinary, shootPoint.position, shootPoint.rotation);
        //        }

        //        if (boltType == BoltType.ordinary)
        //        {
        //            Instantiate(bolt_Ordinary, shotSpawn.position, shotSpawn.rotation);
        //        }
        //        else if (boltType == BoltType.tripple)
        //        {
        //            Instantiate(bolt_Tripple, shotSpawn.position, shotSpawn.rotation);
        //        }
        //    }
        //    if (boltType == BoltType.ordinary && Input.GetKey(KeyCode.Alpha2))
        //    {
        //        boltType = BoltType.tripple;
        //    }
        //    else if (boltType == BoltType.tripple && Input.GetKey(KeyCode.Alpha1))
        //    {
        //        boltType = BoltType.ordinary;
        //    }
    }

    public void SetUltimateDamageAmount(float ulDamageAmount)
    {
        this.ultimateDamageAmount = ulDamageAmount;
    }

    public float GetUltimateDamageAmount()
    {
        return this.ultimateDamageAmount;
    }

    private void OnGameOver_PlayerDead() {
        this.enabled = false;
    }
}
