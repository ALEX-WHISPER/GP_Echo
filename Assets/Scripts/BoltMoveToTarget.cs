using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMoveToTarget : MonoBehaviour {
    public float speed;
    public Transform target;
    private Vector3 targetPoint;

    void Update()
    {
        targetPoint = target.position;

        //  根据目标物体的运动，时刻调整角度使自身始终指向目标物体
        transform.LookAt(targetPoint);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
        transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
        transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度

        transform.Translate(target.position * Time.deltaTime * speed);    //  以一定速度朝目标位置运动
    }
}
