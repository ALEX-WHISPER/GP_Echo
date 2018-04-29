using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShoot : MonoBehaviour {
    //  子弹3
    public GameObject bolt3_Radial;
    public float shootGap;
    public float waveDelay_Bolt3;
    public float startDelay;

    [HideInInspector]
    public bool ifStopBolt3 = true;

    private GameObject radialObj;
    void Start()
    {
        Invoke("StartShooting", startDelay);
    }

    void StartShooting()
    {
        ifStopBolt3 = false;
        StartCoroutine(ShootBolt3_Operate());
    }

    public void StopShooting()
    {
        ifStopBolt3 = true;
        if(radialObj != null)
        {
            radialObj.SetActive(false);
        }
    }

    IEnumerator ShootBolt3_Operate()
    {
        while (true)
        {
            if (!ifStopBolt3)
            {
                radialObj = Instantiate(bolt3_Radial, transform.position, bolt3_Radial.transform.rotation) as GameObject;
                radialObj.GetComponent<Bolt3_Radial_Single>().shootAngleGap = this.shootGap;
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
