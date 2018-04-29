using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownForWholeLevel_2 : CountDownForWholeLevel_0
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

            //  5-25s: 飞龙2
            if (tmp > 5 && tmp <= 25)
            {
                enemyMovingMode.DragonMove_Mode1();  //  MINUS
                yield return new WaitForSeconds(10f);  //  MINUS

            }//  5-25s

            //  25-50s: 自爆蚊1 + 陨石1
            if (tmp >= 26 && tmp <= 50)
            {
                enemyMovingMode.Mosquito_Mode1();
                yield return new WaitForSeconds(3f);  //  MINUS
            }

            //  50-60s
            if (tmp >= 51 && tmp < maxTime)
            {
                yield return new WaitForSeconds(1f);  //  MINUS
                enemyMovingMode.Stone_Mode1();  //  MINUS
            }

            if (tmp >= maxTime) {
                ShowBoss();
                break;
            }

            #region MINUS
            /*
            //  60-90s: 自爆蚊2 + 陨石2
            if (tmp > 60 && tmp <= 90)
            {
                //enemyMovingMode.Mosquito_Mode2();
                enemyMovingMode.Stone_Mode2();
                yield return new WaitForSeconds(5f);
            }

            //  90-100s
            if (tmp > 90 && tmp <= 100)
            {
                yield return new WaitForSeconds(1f);
            }

            //  100-115s: 自爆蚊1、4、6
            if(tmp > 100 && tmp <= 115)
            {
                enemyMovingMode.Mosquito_Mode1();
                yield return new WaitForSeconds(1f);
                enemyMovingMode.Mosquito_Mode4();
                yield return new WaitForSeconds(1f);
                enemyMovingMode.Mosquito_Mode6();
                yield return new WaitForSeconds(waveDelay);
            }

            //  115-130s: 自爆蚊2、3、5
            if (tmp > 115 && tmp <= 130)
            {
                enemyMovingMode.Mosquito_Mode2();
                yield return new WaitForSeconds(1f);
                enemyMovingMode.Mosquito_Mode3();
                yield return new WaitForSeconds(1f);
                enemyMovingMode.Mosquito_Mode5();
                yield return new WaitForSeconds(waveDelay);
            }

            //  130-160s: 陨石1、2
            if (tmp > 130 && tmp <= 160)
            {
                enemyMovingMode.Stone_Mode1();
                enemyMovingMode.Stone_Mode2();
                yield return new WaitForSeconds(3f);
            }

            //  160-200s: 触手1
            if (tmp > 160 && tmp <= 200)
            {
                enemyMovingMode.Tentacle_Mode1();
                yield return new WaitForSeconds(waveDelay);
            }

            //  200-230s: 陨石1 + 触手1
            if(tmp > 200 && tmp <= 230)
            {
                enemyMovingMode.Stone_Mode1();
                enemyMovingMode.Tentacle_Mode1();
                yield return new WaitForSeconds(waveDelay);
            }

            //  230-250s:
            if (tmp > 230 && tmp <= 250)
            {
                yield return new WaitForSeconds(1f);
            }

            if (tmp >= maxTime)
            {
                break;
            }
            */
            #endregion
        }
    }

    protected new IEnumerator CountDown()
    {
        while (tmp < maxTime && !ifStop)
        {
            yield return new WaitForSeconds(1);
            tmp++;

            #region MINUS
            /*
            if (tmp == 10)
            {
                enemyMovingMode.Mosquito_Mode1(); enemyMovingMode.Tentacle_Mode2();
            } if (tmp == 15)
            {
                enemyMovingMode.Mosquito_Mode2(); enemyMovingMode.Tentacle_Mode3();
            } if (tmp == 20)
            {
                enemyMovingMode.Mosquito_Mode4(); enemyMovingMode.Tentacle_Mode4();
            } if (tmp == 25)
            {
                enemyMovingMode.Mosquito_Mode3(); enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 30)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 35)
            {
                enemyMovingMode.WormMove_Mode3();
            } if (tmp == 38)
            {
                //enemyMovingMode.Mosquito_Mode5();
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 45)
            {
                enemyMovingMode.Corrupted_Mode2();
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 50)
            {
                //enemyMovingMode.Mosquito_Mode6();
                enemyMovingMode.Tentacle_Mode3();
            } if (tmp == 53)
            {
                enemyMovingMode.Corrupted_Mode1();
            } if (tmp == 55)
            {
                //enemyMovingMode.WormMove_Mode1();
                enemyMovingMode.Battery_Mode1();
            } if (tmp == 60)
            {
                //enemyMovingMode.Corrupted_Mode1();
            } if (tmp == 65)
            {
                //enemyMovingMode.Battery_Mode1();
            } if (tmp == 69)
            {
                //enemyMovingMode.Mosquito_Mode6();
            } if (tmp == 70)
            {
                //enemyMovingMode.Tentacle_Mode2();
            } if (tmp == 72)
            {
                //enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 75)
            {
                enemyMovingMode.DrangonMove_Mode2();
            } if (tmp == 80)
            {
                enemyMovingMode.Corrupted_Mode3();
            } if (tmp == 82)
            {
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 85)
            {
                enemyMovingMode.WormMove_Mode2();
            } if (tmp == 90)
            {
                enemyMovingMode.Corrupted_Mode2();
                enemyMovingMode.Battery_Mode4();
            } if (tmp == 135)
            {
                enemyMovingMode.Corrupted_Mode1();
            } if (tmp == 141)
            {
                enemyMovingMode.Mosquito_Mode4();
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 145)
            {
                //enemyMovingMode.WormMove_Mode1();
            } if (tmp == 152)
            {
                enemyMovingMode.Corrupted_Mode3();
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 156)
            {
                //enemyMovingMode.Tentacle_Mode3();
            } if (tmp == 160)
            {
                //enemyMovingMode.Mosquito_Mode1();
                //enemyMovingMode.Mosquito_Mode3();
                enemyMovingMode.Mosquito_Mode5();
                enemyMovingMode.Battery_Mode3();
            } if (tmp == 170)
            {
                enemyMovingMode.Mosquito_Mode2();
                enemyMovingMode.Mosquito_Mode3();
            } if (tmp == 180)
            {
                enemyMovingMode.Tentacle_Mode2();
                enemyMovingMode.Tentacle_Mode4();
            } if (tmp == 190)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode4();
            } if (tmp == 200)
            {
                enemyMovingMode.Tentacle_Mode3();
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 215)
            {
                enemyMovingMode.Battery_Mode1();
            } if (tmp == 220)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 225)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Tentacle_Mode3();
            } if (tmp == 230)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Tentacle_Mode3();
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 235)
            {
                enemyMovingMode.Corrupted_Mode2();
            } if(tmp == 245)    //  小怪刷完，Boss出现
            {
                ShowBoss();
            }
            if (tmp >= maxTime)
            {
                ifStop = true;
            }
            */
            #endregion
            
            if (tmp >= 60) {
                ShowBoss();
                ifStop = true;
            }
        }
    }
}
