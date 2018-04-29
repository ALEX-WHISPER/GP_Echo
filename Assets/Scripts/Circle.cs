using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {
    public bool ifCircleLoop = false;
    public bool ifQueenUse = false;
    public float _radius_length;
    public float _angle_speed;
    public float createRate;
    public int boltCount = 20;
    public GameObject freezeBolt;

    private float nextCreate = 0f;
    private float temp_angle;
    private Vector3 _pos_new;
    private float time = 0f;
  
    public GameObject _center_pos;
    public bool _round_its_center;

    public bool moveUp_R;
    public bool moveUp_L;
    
    public bool moveDown_R;
    public bool moveDown_L;

    public bool moveLeft_U;
    public bool moveLeft_D;

    public bool moveRight_U;
    public bool moveRight_D;

    // Use this for initialization
    void Start()
    {
        if (_round_its_center)
        {
            _center_pos.transform.position = transform.localPosition;
        }
        //StartCoroutine(StartCircleCreate());
    }

    // Update is called once per frame
    void Update()
    {
        if(!ifCircleLoop)
        {
            if (temp_angle >= Mathf.PI) return;
        }
        temp_angle += _angle_speed * Time.deltaTime;

        Vector3 offset = CalcOffsetByDirection();
        Vector3 originalPos = ifQueenUse ? new Vector3(0,0,0) : _center_pos.transform.position;
        _pos_new = originalPos + offset * _radius_length;
        transform.localPosition = _pos_new;
    }

    //IEnumerator StartCircleCreate()
    //{
    //    while(true)
    //    {
    //        if(temp_angle >= Mathf.PI)
    //        {
    //            break;
    //        }
    //        for (int i = 0; i < boltCount; ++i )
    //        {
    //            GameObject bolt = Instantiate(freezeBolt, transform.localPosition, freezeBolt.transform.rotation) as GameObject;

    //            yield return new WaitForSeconds(createRate);
    //            temp_angle += _angle_speed * Time.deltaTime;

    //            Vector3 offset = CalcOffsetByDirection();
    //            _pos_new = _center_pos.transform.position + offset * _radius_length;
    //            transform.localPosition = _pos_new;
    //        }
    //    }
    //}

    Vector3 CalcOffsetByDirection()
    {
        if (moveUp_R)
            return new Vector3(Mathf.Sin(temp_angle), Mathf.Cos(temp_angle) * -1, 0f);
        if (moveUp_L)
            return new Vector3(Mathf.Sin(temp_angle) * -1, Mathf.Cos(temp_angle) * -1, 0f);

        if(moveDown_R)
            return new Vector3(Mathf.Sin(temp_angle), Mathf.Cos(temp_angle), 0f);
        if (moveDown_L)
            return new Vector3(Mathf.Sin(temp_angle) * -1, Mathf.Cos(temp_angle), 0f);

        if (moveLeft_U)
            return new Vector3(Mathf.Cos(temp_angle), Mathf.Sin(temp_angle), 0f);
        if(moveLeft_D)
            return new Vector3(Mathf.Cos(temp_angle), Mathf.Sin(temp_angle) * -1, 0f);
        
        if(moveRight_U)
            return new Vector3(Mathf.Cos(temp_angle) * -1, Mathf.Sin(temp_angle), 0f);
        if (moveRight_D)
            return new Vector3(Mathf.Cos(temp_angle) * -1, Mathf.Sin(temp_angle) * -1, 0f);

        else
            return new Vector3(0f, 0f, 0f);
    }
}
