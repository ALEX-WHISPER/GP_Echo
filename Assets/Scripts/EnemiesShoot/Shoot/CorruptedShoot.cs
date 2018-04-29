using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedShoot : MonoBehaviour {
    public GameObject corruptedBolt;
    public float shootDelay;
    public float boltDelay;
    [HideInInspector]
    public bool ifStopShoot = false;

    void Start()
    {
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(shootDelay);

        while(true)
        {
            if (ifStopShoot)
            {
                break;
            }
            else
            {
                Instantiate(corruptedBolt, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(boltDelay);
            }
        }
    }
}
