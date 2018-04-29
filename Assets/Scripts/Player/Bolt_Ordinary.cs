using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt_Ordinary : MonoBehaviour, BoltMoveStraight{
    public float speed;
    public int direction_Y = 1;
    public int direction_X = 0;

    void Update()
    {
        BoltMove();
    }

    public void BoltMove()
    {
        //GetComponent<Rigidbody2D>().velocity = direction * speed;
        transform.Translate(Vector3.up * direction_Y * speed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.right * direction_X * speed * Time.deltaTime, Space.Self);
    }
}
