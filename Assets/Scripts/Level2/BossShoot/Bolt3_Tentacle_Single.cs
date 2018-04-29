using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt3_Tentacle_Single : MonoBehaviour {
    public GameObject radialBoltObj;
    public Transform splitPos;

    public Vector3 MAX_ENDSCALE;
    public Vector3 NOR_ENDSCALE;
    public Vector3 SMALL_ENDSCALE;
    public Vector3 MIN_ENDSCALE;
    public float goDuration;
    public float backDuration;
    public float hitDelay;

    private Transform player;
    private Vector3 startScale;
    private Vector3 endScale;
    private bool ifStopHit = true;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startScale = transform.localScale;
        endScale = transform.localScale;
    }
    public void StartTentacleHit()
    {
        ifStopHit = false;
        StartCoroutine(HitPlayer());
    }

    public void StopTentacleHit()
    {
        ifStopHit = true;
    }
    void LookAtPlayer()
    {
        transform.LookAt(player);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
        transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
        transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度
    }
    IEnumerator HitPlayer()
    {
        while(true)
        {
            if (!ifStopHit)
            {
                yield return new WaitForSeconds(hitDelay);

                LookAtPlayer();
                CalcEndScale();

                //  Go
                TweenScale.Begin(gameObject, goDuration, endScale);

                yield return new WaitForSeconds(goDuration);
                //  Split
                Instantiate(radialBoltObj, splitPos.position, radialBoltObj.transform.rotation);

                //  Back
                TweenScale.Begin(gameObject, backDuration, startScale);
            }
            else
            {
                break;
            }
        }  
    }

    void CalcEndScale()
    {
        float offset_Vertical = Mathf.Abs(transform.position.y - player.position.y);

        if (offset_Vertical > 12)
        {
            endScale = MAX_ENDSCALE;
        }
        else if (offset_Vertical > 8 && offset_Vertical <= 12)
        {
            endScale = NOR_ENDSCALE;
        }
        else if (offset_Vertical > 4 && offset_Vertical <= 8)
        {
            endScale = SMALL_ENDSCALE;
        }
        else
            endScale = MIN_ENDSCALE;
    }
}
