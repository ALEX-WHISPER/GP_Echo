using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkillHurt : MonoBehaviour {
    public string enemyTag = "Enemy";
    public string enemyBoltTag = "EnemyBolt";
    public string enemyAndBoltTag = "EnemyAndBolt";
    public string bossTag = "Boss";
    public float damageAmount;

    void Start()
    {
       damageAmount = GetComponentInParent<PlayerMove>().GetUltimateDamageAmount();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == enemyBoltTag)
        {
            Destroy(other.gameObject);
        }
        else if(other.tag == enemyTag || other.tag == enemyAndBoltTag)
        {
            if(other.gameObject.GetComponent<EnemyHealth>() != null)
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            }
        }
        else if(other.tag == bossTag)
        {
            if(other.gameObject.GetComponent<BossHealth>() != null)
            {
                other.gameObject.GetComponent<BossHealth>().TakeDamage(damageAmount);
            }
        }
    }
}
