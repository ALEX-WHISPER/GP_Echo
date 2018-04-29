using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenOutsideRotateControl : MonoBehaviour {
    void Start()
    {
        GetComponent<RotateAndShootTest>().ifCanShoot = true;
    }
}
