using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPositionMove : MonoBehaviour {
    public Vector3 moveTo;
    public float duration;

    void Start()
    {
        TweenPosition.Begin(gameObject, duration, moveTo);
    }
}
