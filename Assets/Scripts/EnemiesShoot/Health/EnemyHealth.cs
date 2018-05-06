using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  掉落物品类
[System.Serializable]
public class DropOut
{
    public GameObject dropOutObj;   //  掉落类型
    public float dropOutRate;       //  掉落概率
}

public class EnemyHealth : MonoBehaviour {
    public float healthValue;
    public float damageAmount;
    public float reDamagePeriod;
    public float curHealth;
    public int scoreIncrement;
    public GameObject deadExplosion;
    [HideInInspector]
    public bool ifCanBeHit = false;

    public DropOut redDropOut;  //  HP
    public DropOut blueDropOut; //  MP
    public DropOut yellowDropOut;   //  BP

    private float nextDamage = 0f;
    private bool ifHadExploded = false;

    protected void Start()
    {
        curHealth = healthValue;
    }

    protected void Update()
    {
        if (curHealth <= 0 && !ifHadExploded)
        {
            HitControl();
            ifHadExploded = true;
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBolt")
        {
            if(curHealth > 0)
            {
                if(Time.time > nextDamage)
                {
                    TakeDamage(damageAmount);
                    nextDamage += reDamagePeriod;
                } 
            }
        }
    }

    void HitControl()
    {
        Instantiate(deadExplosion, transform.position, Quaternion.identity);
        EnemyDestroy();
    }

    //  敌人被击杀
    protected virtual void EnemyDestroy()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().isTrigger = false;
        GameObject.Find("UI").GetComponent<ScoreManager>().AddScore(this.scoreIncrement);
        DropOut();  //  触发掉落条件
    }

    private void DropOut()
    {
        DropOutBonus(redDropOut);   //  HP
        DropOutBonus(blueDropOut);  //  MP
        DropOutBonus(yellowDropOut);    //  BP
    }

    private void DropOutBonus(DropOut bonusType)
    {
        float randomRate = Random.Range(0, 100);
        if(randomRate <= bonusType.dropOutRate * 100)
        {
            Instantiate(bonusType.dropOutObj, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)), Quaternion.identity);
        }
    }

    public void TakeDamage(float hurtValue)
    {
        curHealth -= hurtValue;
    }
}
