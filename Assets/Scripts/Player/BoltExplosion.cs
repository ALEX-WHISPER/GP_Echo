using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltExplosion : MonoBehaviour {
    public GameObject explosion;

    private GameObject explosionObj;
    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.tag != "Finish" && other.tag != "Player" && other.tag != "SplitTrigger")
        if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "EnemyAndBolt")
        {
            explosionObj = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}
