using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBolt1 : MonoBehaviour {
    public GameObject bolt_1_Prefab;
    public float boltDelay;
    public Transform shotSpawn;
    public bool ifCanShoot = true;

    private float nextShoot;

    void Update()
    {
        if (!ifCanShoot) return;

        if(Time.time > nextShoot)
        {
            nextShoot = Time.time + boltDelay;
            Instantiate(bolt_1_Prefab, gameObject.transform.position, shotSpawn.rotation);
        }
    }
}
