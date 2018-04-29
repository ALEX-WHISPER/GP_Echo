using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaCurve : MonoBehaviour {
    public GameObject t1;    //开始位置  
    public GameObject t2;     //结束位置
    public float speed;
    public bool move_vertical;
    public bool move_horizontal;
    void Start()
    {
        //transform.Rotate(,);
    }

    // Update is called once per frame
    void Update()
    {

        //两者中心点  
        Vector3 center = (t1.transform.position + t2.transform.position) * 0.5f;

        center -= move_horizontal ? new Vector3(0, 1, 0) : new Vector3(1, 0, 0);

        Vector3 start = t1.transform.position - center;
        Vector3 end = t2.transform.position - center;

        //弧形插值  
        transform.position = Vector3.Slerp(start, end, Time.time * speed);
        transform.position += center;    
        //transform.Translate((transform.position + center) * Time.deltaTime * speed);
    }  
}
