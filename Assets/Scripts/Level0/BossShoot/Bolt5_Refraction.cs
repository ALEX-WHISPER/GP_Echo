using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt5_Refraction : MonoBehaviour {
    public Sprite original_Green;
    public Sprite firstRefraction_Red;
    public Sprite secondRefraction_Purple;
    public string triggerTagName;
    public bool ifMiddle_LookPlayer = false;
    public float redSpeedRate;
    public float purpleSpeedRate;

    private int refractCount = 0;
    private float triggerEulerAngle;
    private float boltEulerAngle;
    private Transform player;
    private float originalSpeed;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        originalSpeed = GetComponent<Bolt_Ordinary>().speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == triggerTagName)
        {
            refractCount++;

            if(refractCount == 0)
            {
                GetComponent<SpriteRenderer>().sprite = original_Green;
                GetComponent<Bolt_Ordinary>().speed = originalSpeed;
            }

            if(refractCount == 1)
            {
                GetComponent<SpriteRenderer>().sprite = firstRefraction_Red;
                GetComponent<Bolt_Ordinary>().speed = originalSpeed * redSpeedRate;
            }
            else if (refractCount == 2)
            {
                GetComponent<SpriteRenderer>().sprite = secondRefraction_Purple;
                GetComponent<Bolt_Ordinary>().speed = originalSpeed * purpleSpeedRate;
                refractCount = -1;
            }

            if (ifMiddle_LookPlayer)
            {
                LookAtPlayer();
            }

            else
            {
                triggerEulerAngle = other.gameObject.transform.rotation.eulerAngles.z;
                boltEulerAngle = transform.rotation.eulerAngles.z;
                float angleOffset = boltEulerAngle - triggerEulerAngle;

                if (angleOffset == 90)
                {
                    Vector3 newScale = transform.localScale;
                    newScale.y *= -1;
                    transform.localScale = newScale;

                    GetComponent<Bolt_Ordinary>().direction_Y *= -1;
                }
                else
                {
                    Quaternion afterRefraction = Quaternion.identity;

                    if (angleOffset > 0 && angleOffset < 90)
                    {
                        afterRefraction.eulerAngles = new Vector3(0, 0, boltEulerAngle - 90);
                    }
                    else if (angleOffset > 90)
                    {
                        afterRefraction.eulerAngles = new Vector3(0, 0, boltEulerAngle + 90);
                    }
                    transform.rotation = afterRefraction;
                }
            } 
        }
    }

    void LookAtPlayer()
    {
        transform.LookAt(player);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
        transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
        transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度
    }
}
