using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Mover : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up * -1 * speed;	
	}
}
