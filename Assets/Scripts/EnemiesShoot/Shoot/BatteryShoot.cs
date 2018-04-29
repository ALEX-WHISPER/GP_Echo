using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryShoot : MonoBehaviour {
    public GameObject bolt1_Radial;
    public GameObject bolt2_Radial;
    public float shootGap_Bolt1;
    public float shootGap_Bolt2;
    public float rotateRate;
    public float betweenBoltDelay;
    public float waveDelay;
    public float startDelay;

    [HideInInspector]
    public bool ifStopShoot = false;

    void Start()
    {
        Invoke("StartShooting", startDelay);
    }

    void StartShooting()
    {
        StartCoroutine(ShootBolt3_Operate());
    }

    IEnumerator ShootBolt3_Operate()
    {
        while (true)
        {
            if (ifStopShoot)
            {
                break;
            }
            else
            {
                ShootMosquito_Bolt1();
                yield return new WaitForSeconds(betweenBoltDelay);
                ShootRotatePurple_Bolt2();
                yield return new WaitForSeconds(waveDelay);
            }
        }
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, rotateRate * Time.deltaTime);
    }

    private void ShootMosquito_Bolt1()
    {
        ShootRadialBolt(bolt1_Radial, shootGap_Bolt1);
    }

    private void ShootRotatePurple_Bolt2()
    {
        ShootRadialBolt(bolt2_Radial, shootGap_Bolt2);
    }

    private void ShootRadialBolt(GameObject radialBolt, float shootGap)
    {
        GameObject radialObj = Instantiate(radialBolt, transform.position, radialBolt.transform.rotation) as GameObject;
        radialObj.GetComponent<Bolt3_Radial_Single>().shootAngleGap = shootGap;
        radialObj.transform.SetParent(gameObject.transform);
    }
}
