using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt1_SubBoltMoveToStart : MonoBehaviour {
    public float moveDuration;
    public Vector3 moveTo;
    public float blindDelay;

    private Vector3 originalPos;

    void Start() {
        originalPos = transform.position;
    }
    public void MoveToStartPos()
    {
        TweenPosition.Begin(gameObject, moveDuration, moveTo);
    }

    public void HideAndDestroy()
    {
        TweenPosition.Begin(gameObject, moveDuration, originalPos);
        Invoke("SetBlind", blindDelay);
    }

    void SetBlind()
    {
        gameObject.SetActive(false);
    }
}
