using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_RandomRotate : MonoBehaviour {
    public float tumble;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().angularVelocity = Random.insideUnitCircle.y * tumble;
	}
}
