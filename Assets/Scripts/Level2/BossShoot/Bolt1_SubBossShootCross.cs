using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt1_SubBossShootCross : MonoBehaviour {
    public Vector2[] boltDirection = new Vector2[4]; 
    public GameObject crossBolt_Prefab;
    public Transform instancePos;
    public int boltCount;
    public float boltDelay;
    public float shootDelay;

    [HideInInspector]
    public bool ifShoot = false;


    IEnumerator ShootCrossBolt() {

        yield return new WaitForSeconds(shootDelay);
        while(true)
        {
            if (ifShoot)
            {
                for (int j = 0; j < boltCount; ++j)
                {
                    for (int i = 0; i < boltDirection.Length; i++)
                    {
                        Instantiate(crossBolt_Prefab, instancePos.position, crossBolt_Prefab.transform.rotation);
                        crossBolt_Prefab.GetComponent<Bolt_Ordinary>().direction_X = (int)boltDirection[i].x;
                        crossBolt_Prefab.GetComponent<Bolt_Ordinary>().direction_Y = (int)boltDirection[i].y;
                    }
                    yield return new WaitForSeconds(boltDelay);
                }
            }
            else {
                break;
            }
        }
            
    }

    public void StartShooting()
    {
        ifShoot = true;
        StartCoroutine(ShootCrossBolt());
    }

    public void StopShooting() 
    {
        ifShoot = false;
    }
}
