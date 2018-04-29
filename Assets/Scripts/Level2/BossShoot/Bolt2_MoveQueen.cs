using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt2_MoveQueen : MonoBehaviour {
    public float startDelay;
    public float moveDuration;
    public Vector3 moveTo;

    public void QueenMove()
    {
        Invoke("MovePingpong", startDelay);
    }

    void MovePingpong()
    {
        TweenPosition.Begin(gameObject, moveDuration, moveTo);
        GetComponent<TweenPosition>().style = TweenPosition.Style.PingPong;
    }
}
