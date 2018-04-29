using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt3_Tentacle : MonoBehaviour {
    public GameObject bolt3_TentacleObj;
    public GameObject splitObj;
    public Transform tentacleVertex;

    public Vector3 startScale;
    public Vector3 endScale;
    public float goDuration;
    public float backDuration;
    public float splitDelay;
    public float hitDelay;

    private bool ifStopHit = true;

    public void TentacleStartHit()
    {
        ifStopHit = false;
        
    }
}
