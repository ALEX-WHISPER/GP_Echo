using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt2_RotateVertexes : MonoBehaviour {
    public GameObject bolt2_Rotate;
    public float shootRate;

    [HideInInspector]
    public bool ifCanShoot = true;
    private float nextShoot = 0f;

    void Update()
    {
        if(!ifCanShoot)
        {
            return;
        }
        else
        {
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + shootRate;
                Instantiate(bolt2_Rotate, transform.position, transform.rotation);
                bolt2_Rotate.transform.Rotate(new Vector3(0f, 0f, 180f));
            }
        }
    }
}
