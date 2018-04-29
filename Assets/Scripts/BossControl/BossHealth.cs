using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour {
    public GameObject[] healthBar = new GameObject[5];
    public float healthBarHealth;
    public float totalHealth;
    public float reDamagePeriod;
    public float damageAmount;
    public int scoreIncrementEachHealthBar = 700;
    public bool ifBoss1 = false;
    public bool ifBoss2 = false;
    public bool ifBoss3 = false;
    public GameObject bonus_Yellow;
    public int bonusCountEveryHealthBar;
    public EnemyShoot_Boss1 bossShoot1 = null;
    public EnemyShoot_Boss2 bossShoot2 = null;
    public EnemyShoot_Boss3 bossShoot3 = null;
    public GameObject levelPass;
    public GameObject levelPass_ENG;

    public Vector3 diePosition;
    public float dieDuration;

    //[HideInInspector]
    public float curHealth = 0f;

    private enum BossState
    {
        BOSS_1,
        BOSS_2,
        BOSS_3,
        NULL
    }
    private float[] health = new float[5];
    private BossState bossState = BossState.NULL;
    private float everyHealthBarValue;
    private Vector3 healthScale;
    private float nextDamage = 0f;
    private bool[] invokeBossBoltControl = new bool[]{false,false,false,false,false};
    private int currentHealthBarID = 0;
    private

    void Start()
    {
        ConfirmBossState();
        ResetEveryHealthBarValue();
        InitHealthInfo();
        InitHealthBarValueArray();
    }

    void Update()
    {
        //  血条 / 子弹: 0
        if(curHealth <= health[0] && !invokeBossBoltControl[0])
        {
            if (bossState == BossState.BOSS_1) { bossShoot1.ShootBolt1_Start(); }
            if (bossState == BossState.BOSS_2) { bossShoot2.ShootBolt1_Start(); }
            if (bossState == BossState.BOSS_3) { bossShoot3.ShootBolt1_Start(); }

            ShowNextHealthBar(0);
        }

        //  血条 / 子弹：1
        if (curHealth <= health[1] && !invokeBossBoltControl[1])
        {
            if (bossState == BossState.BOSS_1)
            {
                bossShoot1.ShootBolt1_Stop();
                bossShoot1.ShootBolt2_Start();
            }
            if (bossState == BossState.BOSS_2)
            {
                bossShoot2.ShootBolt1_Stop();
                bossShoot2.ShootBolt2_Start();
            }
            if (bossState == BossState.BOSS_3)
            {
                bossShoot3.ShootBolt1_Stop();
                bossShoot3.ShootBolt2_Start();
            }
            
            ShowNextHealthBar(1);
        }

        //  血条 / 子弹：2
        if (curHealth <= health[2] && !invokeBossBoltControl[2])
        {
            if (bossState == BossState.BOSS_1)
            {
                bossShoot1.ShootBolt2_Stop();
                bossShoot1.ShootBolt3_Start();
            }
            if (bossState == BossState.BOSS_2)
            {
                bossShoot2.ShootBolt2_Stop();
                bossShoot2.ShootBolt3_Start();
            }
            if (bossState == BossState.BOSS_3)
            {
                bossShoot3.ShootBolt2_Stop();
                bossShoot3.ShootBolt3_Start();
            }
            ShowNextHealthBar(2);
        }

        //  血条 / 子弹：3
        if (curHealth <= health[3] && !invokeBossBoltControl[3])
        {
            if (bossState == BossState.BOSS_1)
            {
                bossShoot1.ShootBolt3_Stop();
                bossShoot1.ShootBolt4_Start();
            }
            if (bossState == BossState.BOSS_2)
            {
                bossShoot2.ShootBolt3_Stop();
                bossShoot2.ShootBolt4_Start();
            }
            if (bossState == BossState.BOSS_3)
            {
                bossShoot3.ShootBolt3_Stop();
                bossShoot3.ShootBolt4_Start();
            }
            ShowNextHealthBar(3);
        }

        //  血条 / 子弹：4
        if (curHealth <= health[4] && !invokeBossBoltControl[4])
        {
            if (bossState == BossState.BOSS_1)
            {
                bossShoot1.ShootBolt4_Stop();
                bossShoot1.ShootBolt5_Start();
            }
            if (bossState == BossState.BOSS_2)
            {
                bossShoot2.ShootBolt4_Stop();
                bossShoot2.ShootBolt5_Start();
            }
            if (bossState == BossState.BOSS_3)
            {
                bossShoot3.ShootBolt4_Stop();
                bossShoot3.ShootBolt5_Start();
            }
            ShowNextHealthBar(4);
        }

        //  Boss死亡，停止发射
        if(curHealth <= 0)
        {
            if (bossState == BossState.BOSS_1)
            {
                bossShoot1.ShootBolt5_Stop();
            }
            if (bossState == BossState.BOSS_2)
            {
                bossShoot2.ShootBolt5_Stop();
            }
            if (bossState == BossState.BOSS_3)
            {
                bossShoot3.ShootBolt5_Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBolt")
        {
            if (curHealth > 0)
            {
                if (Time.time > nextDamage)
                {
                    TakeDamage(damageAmount);
                    nextDamage += reDamagePeriod;
                }
            }
            else
            {
                TweenPosition.Begin(gameObject, dieDuration, diePosition);
                Invoke("Die", 3f);
            }
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        PlayerPassLevel();
    }

    private void PlayerPassLevel()
    {
        if (LanguageManager.lanInstance.GetLanguageIfCN())
        {
            Instantiate(levelPass, levelPass.transform.position, Quaternion.identity);
            Debug.Log("Language: CN");
        }
        else
        {
            Instantiate(levelPass_ENG, levelPass_ENG.transform.position, Quaternion.identity);
            Debug.Log("Language: ENG");
        }
        Invoke("BackToStart", 3f);
    }
    private void BackToStart()
    {
        SceneManager.LoadScene("Start_1");
    }

    private void ConfirmBossState()
    {
        if (ifBoss1 && !ifBoss2 && !ifBoss3) { bossState = BossState.BOSS_1; }
        if (!ifBoss1 && ifBoss2 && !ifBoss3) { bossState = BossState.BOSS_2; }
        if (!ifBoss1 && !ifBoss2 && ifBoss3) { bossState = BossState.BOSS_3; }
    }

    private void InitHealthInfo()
    {
        curHealth = totalHealth;
        healthScale = healthBar[0].transform.localScale;
        InitHealthBar();
    }

    private void InitHealthBar()
    {
        for (int i = 0; i < healthBar.Length; ++i )
        {
            UpdateHealthBar(i);
            healthBar[i].SetActive(false);
        }
    }

    private void InitHealthBarValueArray()
    {
        for (int i = 0; i < health.Length; ++i )
        {
            health[i] = totalHealth - healthBarHealth * i;
        }
    }

    private void ShowNextHealthBar(int curHealthBarID)
    {
        GameObject.Find("UI").GetComponent<ScoreManager>().AddScore(scoreIncrementEachHealthBar);
        DropBonus();

        currentHealthBarID = curHealthBarID;
        if(curHealthBarID > 0)
        {
            healthBar[curHealthBarID - 1].SetActive(false);
            GameObject.FindWithTag("BossExplosion").GetComponent<BossExplosion>().CreateExplosion();
        }
        ResetEveryHealthBarValue();
        healthBar[curHealthBarID].SetActive(true);
        healthBar[curHealthBarID].GetComponent<ResetHealthBar>().enabled = true;
        invokeBossBoltControl[curHealthBarID] = true;
    }

    private void ResetEveryHealthBarValue()
    {
        everyHealthBarValue = healthBarHealth;
    }

    public void TakeDamage(float hurtValue)
    {
        curHealth -= hurtValue;
        everyHealthBarValue -= hurtValue;
        UpdateHealthBar(currentHealthBarID);
    }

    public void UpdateHealthBar(int healthBarID)
    {
        healthBar[healthBarID].GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.green, Color.red, 1 - everyHealthBarValue * (1 / healthBarHealth));
        healthBar[healthBarID].transform.localScale = new Vector3(healthScale.x * everyHealthBarValue * (1 / healthBarHealth), healthScale.y, 1);
    }

    private void DropBonus()
    {
        for (int i = 0; i < bonusCountEveryHealthBar; i++ )
        {
            Instantiate(bonus_Yellow, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        }
    }
}
