using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndShootTest : MonoBehaviour {
    public float rotateRate;
    public GameObject bolt;
    public float shootRate;
    public Transform shotSpawn;
    public Transform rotateAround;
    public float nextShoot = 0f;
    [HideInInspector]
    public bool ifCanShoot = false;
    
    public bool ifBothDirection = false;

    private int ifClockwise = 1;
    

	void Update () {
        if (!ifCanShoot) return;

        else 
        {
            transform.RotateAround(rotateAround.position, Vector3.forward, ifClockwise * rotateRate * Time.deltaTime);

            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + shootRate;
                Instantiate(bolt, shotSpawn.position + new Vector3(0.1f, 0f, 0f), transform.rotation);

                if(ifBothDirection)
                {
                    Quaternion reverseRotation = Quaternion.identity;
                    reverseRotation.eulerAngles = transform.rotation.eulerAngles + new Vector3(0f, 0f, 180f);
                    Instantiate(bolt, shotSpawn.position + new Vector3(0.1f, 0f, 0f), reverseRotation);
                }
                
                bolt.transform.Rotate(new Vector3(0f, 0f, 180f));
            }
        }  
	}
}
