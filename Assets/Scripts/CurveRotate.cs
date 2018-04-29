using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRotate : MonoBehaviour {
    public float rotateSpeed;
    public float rotateDelay;
    void Start()
    {
        //Invoke("Rotate", rotateDelay);
    }

    void Update()
    {
        if (Time.time > rotateDelay)
            transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
    }
}
