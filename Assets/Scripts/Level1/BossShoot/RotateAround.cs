using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
    public Transform rotateAnchor;
    public float rotateRate;
    public float rotationLimit_Start;
    public float rotationLimit_End;
    private int ifAntiClockwise;    //  是否为逆时针，1：逆时针， -1：顺时针
    public bool ifRotateStartPositive;  //  初始转向是否逆时针

    void Start()
    {
        ifAntiClockwise = ifRotateStartPositive ? 1 : -1;
    }

	// Update is called once per frame
	void Update () {
        if (ifRotateStartPositive)  //  若初始转向是逆时针，则 eulerAngles.z 在持续增大，增大到 end 时，变为顺时针，数值开始减小，减小至 start 时，再变为逆时针
        {
            if (transform.rotation.eulerAngles.z <= rotationLimit_Start)
                ifAntiClockwise = 1;
            if (transform.rotation.eulerAngles.z >= rotationLimit_End)
                ifAntiClockwise = -1;
        }
        else // 若初始转向是顺时针， 则 eulerAngles.z 在减小，减小到 end 时，变为逆时针，增大到 start 时，变为顺时针
        {
            if (transform.rotation.eulerAngles.z >= rotationLimit_Start)
                ifAntiClockwise = -1;
            if (transform.rotation.eulerAngles.z <= rotationLimit_End)
                ifAntiClockwise = 1;
        }

        transform.RotateAround(rotateAnchor.position, Vector3.forward, ifAntiClockwise * rotateRate * Time.deltaTime);
        //Debug.Log(transform.rotation.eulerAngles.z);
    }
}
