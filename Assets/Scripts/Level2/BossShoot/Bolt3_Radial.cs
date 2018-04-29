using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt3_Radial : MonoBehaviour {
    //  子弹3
    public GameObject bolt3_Radial;
    public float waveDelay_Bolt3;
    
    private bool ifStopBolt3 = true;

    public void StartShooting()
    {
        ifStopBolt3 = false;
        StartCoroutine(ShootBolt3_Operate());
    }

    public void StopShooting()
    {
        ifStopBolt3 = true;
    }

    IEnumerator ShootBolt3_Operate()
    {
        while (true)
        {
            if (!ifStopBolt3)
            {
                GameObject radialObj = Instantiate(bolt3_Radial, transform.position, bolt3_Radial.transform.rotation) as GameObject;
                radialObj.transform.SetParent(gameObject.transform);
                
                yield return new WaitForSeconds(waveDelay_Bolt3);
            }
            else
            {
                break;
            }
        }
    }
}
