using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHit : MonoBehaviour {
    public float hitDelay;
    public float hitStay;
    public float hitDuration;
    public float backDuration;
    public float hitRate;
    public bool ifLoop = true;

    private Transform player;
    private bool ifCanHit = false;
    private bool ifCanBack = false;
    private Vector3 playerBeHitPos;
    private Vector3 startPosVec3;
    private float nextHit = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
        startPosVec3 = transform.position;
        StartCoroutine(HitPlayer());
	}
	
	// Update is called once per frame
	void Update () {

        if(ifCanHit && !ifCanBack)
        {
            LookAtPlayer(); //  面向主角
            TweenPosition.Begin(gameObject, hitDuration, playerBeHitPos);   //  朝目标位置戳去
        }

        if(ifCanBack && !ifCanHit)
        {
            TweenPosition.Begin(gameObject, backDuration, startPosVec3);    //  返回
        }
	}

    void LookAtPlayer()
    {
        if(Time.time > nextHit)
        {
            nextHit = Time.time + hitRate;

            transform.LookAt(player);  //  调整朝向，面向主角
            transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
            transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度
            playerBeHitPos = player.position;
        }
    }

    IEnumerator HitPlayer()
    {
        while(true)
        {
            yield return new WaitForSeconds(hitDelay);
            ifCanHit = true; ifCanBack = false;     //  开关：戳向主角
            yield return new WaitForSeconds(hitStay);   //  停留一段时间后
            ifCanBack = true; ifCanHit = false; //  开关：从主角处缩回触手

            if(!ifLoop)
            {
                break;
            }
        }    
    }
}
