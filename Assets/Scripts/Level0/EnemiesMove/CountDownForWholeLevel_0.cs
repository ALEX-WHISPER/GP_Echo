﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownForWholeLevel_0 : MonoBehaviour
{
    public int tmp;
    public int maxTime;
    public int minTime;
    public Text timeText;
    public float waveDelay;
    public GameObject bossBody;
    public Vector3 bossMoveTo;
    public float bossMoveDuration;

    protected EnemyMovingMode_Level0 enemyMovingMode;
    protected bool ifStop = true;

    protected void Start()
    {
        this.enemyMovingMode = GetComponent<EnemyMovingMode_Level0>();
    }
    protected void Update()
    {
        if (ifStop)
        {
            return;
        }

        timeText.text = tmp.ToString();
    }
    public void StartCountDown()
    {
        ifStop = false;
        StartCoroutine(CountDown());
        StartCoroutine(InvokeMovingModes());
    }
    public void StopCountDown()
    {
        ifStop = true;
    }
    protected IEnumerator InvokeMovingModes()
    {
        while (true)
        {
            //  0-5s:
            if (tmp >= 0 && tmp <= 5)
            {
                yield return new WaitForSeconds(1f);
            }

            //  5-20s:
            if (tmp > 5 && tmp <= 20)
            {
                enemyMovingMode.WormMove_Mode2();
                yield return new WaitForSeconds(waveDelay);

            }//  5-20s

            //  20-40s:
            if (tmp > 20 && tmp <= 40)
            {
                enemyMovingMode.WormMove_Mode3();
                yield return new WaitForSeconds(10);
            }

            //  40-60s:
            if (tmp > 40 && tmp <= 60)
            {
                //  50-60s:
                if (tmp > 50)
                {
                    enemyMovingMode.Mosquito_Mode5();
                    //enemyMovingMode.Mosquito_Mode6();
                    yield return new WaitForSeconds(5f);
                }
                enemyMovingMode.DrangonMove_Mode2();
                yield return new WaitForSeconds(waveDelay);
            }

            //  60-70s:
            if (tmp > 60 && tmp <= 70)
            {
                yield return new WaitForSeconds(1f);
            }

            //  70-90s:
            if (tmp > 70 && tmp <= 90)
            {
                if (tmp > 80)
                {
                    enemyMovingMode.DragonMove_Mode1();
                    yield return new WaitForSeconds(6f);
                }
                //enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
                yield return new WaitForSeconds(waveDelay);
            }

            //  90-110s:
            if (tmp > 90 && tmp <= 110)
            {
                enemyMovingMode.DragonMove_Mode1();
                yield return new WaitForSeconds(6f);
                //  95-110s:
                if (tmp > 95)
                {
                    //enemyMovingMode.Mosquito_Mode1();
                    enemyMovingMode.Mosquito_Mode2();
                    yield return new WaitForSeconds(5f);
                }
            }

            //  110-130s:
            if (tmp > 110 && tmp <= 130)
            {
                //if (tmp > 115)
                //{
                //    enemyMovingMode.Mosquito_Mode1();
                //    yield return new WaitForSeconds(5f);
                //}
                //enemyMovingMode.WormMove_Mode1();
                yield return new WaitForSeconds(8f);
            }

            //  130-140s:
            if (tmp > 130 && tmp <= 140)
            {
                yield return new WaitForSeconds(1f);
            }

            //  140-160s:
            if (tmp > 140 && tmp <= 160)
            {
                //enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
                //enemyMovingMode.Mosquito_Mode5();
                enemyMovingMode.Mosquito_Mode6();
                yield return new WaitForSeconds(waveDelay);
            }

            //  160-180s:
            if (tmp > 160 && tmp <= 180)
            {
                enemyMovingMode.WormMove_Mode1();
                //enemyMovingMode.Mosquito_Mode5();
                //enemyMovingMode.Mosquito_Mode6();
                yield return new WaitForSeconds(10f);
            }

            //  180-200s:
            if (tmp > 180 && tmp <= 200)
            {
                //enemyMovingMode.WormMove_Mode3();
                enemyMovingMode.Mosquito_Mode1();
                yield return new WaitForSeconds(10f);
            }

            //  200-235s:
            if (tmp > 200 && tmp <= 235)
            {
                enemyMovingMode.DrangonMove_Mode2();
                //enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode6();
                yield return new WaitForSeconds(10f);
            }

            //  235-250s:
            if (tmp > 235 && tmp <= 250)
            {
                yield return new WaitForSeconds(1f);
            }

            //  250-280s:
            if (tmp > 250 && tmp <= 280)
            {
                //enemyMovingMode.Mosquito_Mode1();
                //enemyMovingMode.Mosquito_Mode5();
                enemyMovingMode.Mosquito_Mode2();
                enemyMovingMode.DragonMove_Mode1();
                //enemyMovingMode.Mosquito_Mode6();

                yield return new WaitForSeconds(10f);
            }

            //  280-290s:
            if (tmp > 280 && tmp <= 290)
            {
                //enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.WormMove_Mode3();
                //enemyMovingMode.Mosquito_Mode3();
                yield return new WaitForSeconds(10f);
            }

            //  290-305:
            if(tmp > 290 && tmp <= 300)
            {
                yield return new WaitForSeconds(1f);
            }

            if (tmp >= maxTime)
            {
                break;
            }
        }
    }
    protected IEnumerator CountDown()
    {
        while (tmp < maxTime && !ifStop)
        {
            yield return new WaitForSeconds(1);
            tmp++;

            if (tmp == 10){
                enemyMovingMode.Mosquito_Mode1();
            } if(tmp == 15){
                enemyMovingMode.Mosquito_Mode2();
            } if(tmp == 20){
                enemyMovingMode.Mosquito_Mode1();
                //enemyMovingMode.Mosquito_Mode2();
            } if(tmp == 25){
                //enemyMovingMode.Mosquito_Mode3();
            } if(tmp == 30){
                //enemyMovingMode.Mosquito_Mode4();
            } if(tmp == 33){
                ///enemyMovingMode.Mosquito_Mode1();
            } if(tmp == 36){
                //enemyMovingMode.Mosquito_Mode5();
            } if(tmp == 40){
                //enemyMovingMode.Mosquito_Mode2();
                enemyMovingMode.Mosquito_Mode6();
            } if(tmp == 43){
                //enemyMovingMode.WormMove_Mode1();
            } if(tmp == 45){
                enemyMovingMode.Mosquito_Mode4();
            } if(tmp == 48){
                //enemyMovingMode.WormMove_Mode3();
            } if(tmp == 50){
                enemyMovingMode.Mosquito_Mode3();
            } if(tmp == 60){
                enemyMovingMode.Queen_Mode1();
            } if (tmp == 90){
                enemyMovingMode.Quuen_Mode1_Destroy();
            } if (tmp == 95){
                enemyMovingMode.WormMove_Mode1();
            } if(tmp == 120){
                enemyMovingMode.Queen_Mode2();
            } if(tmp == 150){
                enemyMovingMode.Quuen_Mode2_Destroy();
            } if(tmp == 170){
                //enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
            } if (tmp == 180){
                //enemyMovingMode.Mosquito_Mode3();
                enemyMovingMode.Mosquito_Mode5();
            } if(tmp == 185){
                enemyMovingMode.Mosquito_Mode3();
                //enemyMovingMode.DrangonMove_Mode2();
            } if(tmp == 190){
                enemyMovingMode.Mosquito_Mode4();
                //enemyMovingMode.DragonMove_Mode1();
            } if(tmp == 195){
                //enemyMovingMode.Mosquito_Mode2();
                //enemyMovingMode.DrangonMove_Mode2();
            } if(tmp == 200){
                //enemyMovingMode.Mosquito_Mode1();
                //enemyMovingMode.Mosquito_Mode2();
                //enemyMovingMode.Mosquito_Mode4();
                //enemyMovingMode.Mosquito_Mode6();
            } if(tmp == 210){
                enemyMovingMode.WormMove_Mode1();
            } if(tmp == 220){
                //enemyMovingMode.WormMove_Mode3();
            } if(tmp == 240){
                enemyMovingMode.Queen_Mode3();
            } if(tmp == 280){
                enemyMovingMode.Quuen_Mode3_Destroy();
            } if(tmp == 300)
            {
                ShowBoss();
            }

            if(tmp >= maxTime)
            {
                ifStop = true;
            }
        }
    }

    protected void ShowBoss()
    {
        bossBody.SetActive(true);
        TweenPosition.Begin(bossBody, bossMoveDuration, bossMoveTo);
        Invoke("StartAttack", 3f);
    }

    private void StartAttack()
    {
        bossBody.GetComponent<BossHealth>().enabled = true;
    }
}
