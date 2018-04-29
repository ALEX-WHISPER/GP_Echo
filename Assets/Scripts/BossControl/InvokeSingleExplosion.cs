using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeSingleExplosion : MonoBehaviour {
    public GameObject explosion;
    public float delay;

    void Start()
    {
        Invoke("CreateExplosion", delay);
    }

    void CreateExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
