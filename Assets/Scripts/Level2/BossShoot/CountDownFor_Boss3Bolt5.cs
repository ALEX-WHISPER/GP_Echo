using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownFor_Boss3Bolt5 : MonoBehaviour {
    public int tmp;
    public Text timeText;
    public EnemyShoot_Boss3 boss3Shoot;

    public float firstNode;     //  100~80
    public float secondNode;    //  80~70
    public float thirdNode;     //  70~60
    public float fourthNode;    //  60~40
    public float fifthNode;     //  40~15

    private bool ifStop = true;

    private int totalTime;
    void Start()
    {
        totalTime = tmp;
    }
    void Update()
    {
        if(ifStop)
        {
            return;
        }

        timeText.text = tmp.ToString();

        if (tmp < totalTime && tmp > firstNode)
        {
            boss3Shoot.ShootBolt5_Step1();
        }
        else if (tmp <= firstNode && tmp > secondNode)
        {
            boss3Shoot.ShootBolt5_Step2();
        }
        else if (tmp <= secondNode && tmp > thirdNode)
        {
            boss3Shoot.ShootBolt5_Step3();
        }
        else if(tmp <= thirdNode && tmp > fourthNode)
        {
            boss3Shoot.ShootBolt5_Step4();
        }
        else if(tmp <= fourthNode && tmp > fifthNode)
        {
            boss3Shoot.ShootBolt5_Step5();
        }
        else if(tmp <= fifthNode && tmp > 0)
        {
            boss3Shoot.ShootBolt5_Step6();
        }
    }

    public void StartCountDown()
    {
        tmp = totalTime;
        ifStop = false;
        StartCoroutine(changeTime());
    }

    IEnumerator changeTime()
    {
        while (tmp > 0 && !ifStop)
        {
            //暂停一秒
            yield return new WaitForSeconds(1);
            tmp--;
        }
    }

    public void StopCountDown()
    {
        ifStop = true;
    }
}
