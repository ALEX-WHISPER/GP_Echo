using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterTentacleBolt_Bolt2 : MonoBehaviour {
    private Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
        LookAtPlayer();
	}

    void LookAtPlayer()
    {
        transform.LookAt(player);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
        transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
        transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度
    }
}
