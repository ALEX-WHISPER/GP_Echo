using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMultiBolt : MonoBehaviour {
    public GameObject bolt;
    public float boltCount;
    public float boltDelay;
    public float shootDelay;
    
    void Start()
    {
        StartCoroutine(ShootMutiBolt());
    }

    IEnumerator ShootMutiBolt()
    {
        for (int i = 0; i < boltCount; ++i )
        {
            yield return new WaitForSeconds(boltDelay);
            Instantiate(bolt, transform.position, transform.rotation);
        }
    }
}
