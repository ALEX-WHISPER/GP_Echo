using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt4_EveryPointStraightShoot : MonoBehaviour {
    public GameObject purpleBolt_Bolt4;
    public float boltDelay;
    public int shootId;

    private bool ifStopShoot = true;

    void Start()
    {
        
    }

    public void StartShooting()
    {
        ifStopShoot = false;
        StartCoroutine(ShootPurpleBolt());
    }

    IEnumerator ShootPurpleBolt()
    {
        while(true)
        {
            if(ifStopShoot)
            {
                break;
            }
            else
            {
                Instantiate(purpleBolt_Bolt4, transform.position, transform.rotation);
                yield return new WaitForSeconds(boltDelay);
            }
        }
    }

    public void StopShooting()
    {
        ifStopShoot = true;
    }
}
