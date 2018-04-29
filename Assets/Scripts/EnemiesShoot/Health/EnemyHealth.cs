using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropOut
{
    public GameObject dropOutObj;
    public float dropOutRate;
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

    public DropOut redDropOut;
    public DropOut blueDropOut;
    public DropOut yellowDropOut;

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

    protected virtual void EnemyDestroy()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().isTrigger = false;
        GameObject.Find("UI").GetComponent<ScoreManager>().AddScore(this.scoreIncrement);
        DropOut();
    }

    private void DropOut()
    {
        DropOutBonus(redDropOut);
        DropOutBonus(blueDropOut);
        DropOutBonus(yellowDropOut);
    }

    private void DropOutBonus(DropOut bonusType)
    {
        float randomRate = Random.Range(0, 100);
        //Debug.Log("random: " + randomRate + ", " + "rate:" + bonusType.dropOutRate * 100);
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
