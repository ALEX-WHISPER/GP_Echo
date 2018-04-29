using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownForWholeLevel_1 : CountDownForWholeLevel_0
{
    new void OnEnable() {
        base.OnEnable();
    }

    new void OnDisable() {
        base.OnDisable();
    }

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
    }

    public new void StartCountDown()
    {
        ifStop = false;
        StartCoroutine(CountDown());
        StartCoroutine(InvokeMovingModes());
    }

    public new void StopCountDown()
    {
        ifStop = true;
    }

    protected new IEnumerator InvokeMovingModes()
    {
        while (true)
        {
            //  0-5s:
            if (tmp >= 0 && tmp <= 5)
            {
                yield return new WaitForSeconds(1f);
            }

            //  5-20s: 自爆蚊2
            if (tmp > 5 && tmp <= 20)
            {
                enemyMovingMode.DrangonMove_Mode2();    //  MINUS
                yield return new WaitForSeconds(5f);

            }//  5-20s

            //  20-40s: 自爆蚊1
            if (tmp > 20 && tmp <= 40)
            {
                enemyMovingMode.Tentacle_Mode1(); //  MINUS
                yield return new WaitForSeconds(waveDelay);
            }

            //  40-60s: 触手1
            if (tmp > 40 && tmp <= 60)
            {
                enemyMovingMode.Mosquito_Mode6();
                yield return new WaitForSeconds(waveDelay);
            }

            //  MINUS: 2018/04/19
            if (tmp > 60) {
                break;
            }
        }
    }
}
