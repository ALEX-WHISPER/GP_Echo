using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownForWholeLevel_1 : CountDownForWholeLevel_0
{
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

    public void StopCountDown()
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
                //enemyMovingMode.Mosquito_Mode2();       //  MINUS
                enemyMovingMode.DrangonMove_Mode2();    //  MINUS

                yield return new WaitForSeconds(5f);

            }//  5-20s

            //  20-40s: 自爆蚊1
            if (tmp > 20 && tmp <= 40)
            {
                enemyMovingMode.Tentacle_Mode1(); //  MINUS

                //enemyMovingMode.Mosquito_Mode1(); //  MINUS
                yield return new WaitForSeconds(waveDelay);
            }

            //  40-60s: 触手1
            if (tmp > 40 && tmp <= 60)
            {
                //  50-60s: 自爆蚊5、6
                if (tmp > 50)
                {
                    //enemyMovingMode.Mosquito_Mode5(); //MINUS
                    enemyMovingMode.Mosquito_Mode6();
                    yield return new WaitForSeconds(1f);
                }
                //enemyMovingMode.Tentacle_Mode1(); //  MINUS
                yield return new WaitForSeconds(waveDelay);
            }

            //  MINUS: 2018/04/19
            if (tmp > 60) {
                break;
            }

            /*
            //  60-70s
            if (tmp > 60 && tmp <= 70)
            {
                yield return new WaitForSeconds(1f);
            }

            //  70-90s: 触手5、2交替
            if (tmp > 70 && tmp <= 90)
            {
                enemyMovingMode.Tentacle_Mode5();
                //yield return new WaitForSeconds(2f);
                enemyMovingMode.Tentacle_Mode2();
                yield return new WaitForSeconds(waveDelay);
            }

            //  90-110s: 触手4、3交替
            if (tmp > 90 && tmp <= 110)
            {
                enemyMovingMode.Tentacle_Mode4();
                yield return new WaitForSeconds(2f);
                enemyMovingMode.Tentacle_Mode3();
                yield return new WaitForSeconds(waveDelay);
            }

            //  110-130s: 飞龙2
            if (tmp > 110 && tmp <= 130)
            {
                //  115-130s: 触手1
                if (tmp > 115)
                {
                    enemyMovingMode.Tentacle_Mode1();
                    yield return new WaitForSeconds(5f);
                }
                enemyMovingMode.DrangonMove_Mode2();
                yield return new WaitForSeconds(6f);
            }

            //  130-140s:
            if (tmp > 130 && tmp <= 140)
            {
                yield return new WaitForSeconds(1f);
            }

            //  140-160s: 自爆蚊1、2、5、6
            if (tmp > 140 && tmp <= 160)
            {
                //enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
                //enemyMovingMode.Mosquito_Mode5();
                enemyMovingMode.Mosquito_Mode6();
                yield return new WaitForSeconds(2f);
            }

            //  160-180s: 触手1 + 自爆蚊1、2
            if (tmp > 160 && tmp <= 180)
            {
                enemyMovingMode.Tentacle_Mode1();
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
                yield return new WaitForSeconds(waveDelay);
            }

            //  180-200s: 触手2、5 + 自爆蚊1
            if (tmp > 180 && tmp <= 200)
            {
                enemyMovingMode.Mosquito_Mode1();

                enemyMovingMode.Tentacle_Mode5();
                yield return new WaitForSeconds(3f);
                enemyMovingMode.Tentacle_Mode2();

                yield return new WaitForSeconds(waveDelay);
            }

            //  200-220s: 触手4、3 + 自爆蚊2
            if(tmp > 200 && tmp <= 220)
            {
                enemyMovingMode.Tentacle_Mode4();
                yield return new WaitForSeconds(3f);
                enemyMovingMode.Tentacle_Mode3();

                enemyMovingMode.Mosquito_Mode2();
                yield return new WaitForSeconds(waveDelay);
            }

            //  220-240s:
            if(tmp > 220 && tmp <= 240)
            {
                enemyMovingMode.Mosquito_Mode1(); enemyMovingMode.Tentacle_Mode2(); yield return new WaitForSeconds(waveDelay);
                enemyMovingMode.Mosquito_Mode2(); enemyMovingMode.Tentacle_Mode3(); yield return new WaitForSeconds(waveDelay);
                enemyMovingMode.Mosquito_Mode3(); enemyMovingMode.Tentacle_Mode4(); yield return new WaitForSeconds(waveDelay);
                enemyMovingMode.Mosquito_Mode4(); enemyMovingMode.Tentacle_Mode5(); yield return new WaitForSeconds(waveDelay);
                enemyMovingMode.Mosquito_Mode5(); enemyMovingMode.Tentacle_Mode4(); yield return new WaitForSeconds(waveDelay);
                enemyMovingMode.Mosquito_Mode6(); enemyMovingMode.Tentacle_Mode5(); yield return new WaitForSeconds(waveDelay);
            }

            //  240-260s:
            if(tmp > 240 && tmp <= 260)
            {
                yield return new WaitForSeconds(1f);
            }

            if (tmp >= maxTime)
            {
                break;
            }
            */
        }
    }

    protected new IEnumerator CountDown()
    {
        while (tmp < maxTime && !ifStop)
        {
            yield return new WaitForSeconds(1);
            tmp++;

            #region MINUS
            /* MINUS
            if (tmp == 7)
            {
                enemyMovingMode.DragonMove_Mode1();
            } if (tmp == 12)
            {
                enemyMovingMode.WormMove_Mode3();
            } if (tmp == 17)
            {
                enemyMovingMode.DragonMove_Mode1();
            } if (tmp == 25)
            {
                enemyMovingMode.DrangonMove_Mode2();
            } if (tmp == 30)
            {
                //enemyMovingMode.WormMove_Mode1();
            } if (tmp == 33)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 36)
            {
                enemyMovingMode.Tentacle_Mode5();
            } if (tmp == 40)
            {
                enemyMovingMode.DragonMove_Mode1();
            } if (tmp == 43)
            {
                enemyMovingMode.Mosquito_Mode3();
                enemyMovingMode.Mosquito_Mode6();
            } if (tmp == 45)
            {
                enemyMovingMode.Mosquito_Mode4();
                enemyMovingMode.Mosquito_Mode5();
            } if (tmp == 48)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
            } if (tmp == 50)
            {
                enemyMovingMode.WormMove_Mode1();
            } if (tmp == 55)
            {
                enemyMovingMode.Corrupted_Mode1();
            } if (tmp == 65)
            {
                //enemyMovingMode.WormMove_Mode3();
            } if (tmp == 67)
            {
                //enemyMovingMode.Tentacle_Mode3();
            } if (tmp == 70)
            {
                //enemyMovingMode.Tentacle_Mode5();
            } if(tmp == 73)
            {
                //enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 75)
            {
                //enemyMovingMode.Mosquito_Mode3();
            } if (tmp == 78)
            {
                enemyMovingMode.DrangonMove_Mode2();
            } if (tmp == 80)
            {
                enemyMovingMode.Corrupted_Mode2();
            } if (tmp == 85)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 90)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
            } if (tmp == 93)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 95)
            {
                enemyMovingMode.Mosquito_Mode2();
                enemyMovingMode.Mosquito_Mode4();
            } if (tmp == 98)
            {
                enemyMovingMode.Corrupted_Mode3();
            } if (tmp == 100)
            {
                enemyMovingMode.Mosquito_Mode6();
            } if (tmp == 105)
            {
                enemyMovingMode.WormMove_Mode1();
            } if (tmp == 110)
            {
                enemyMovingMode.Corrupted_Mode2();
            } if (tmp == 120)
            {
                enemyMovingMode.Queen_Mode2();
            } if (tmp == 135)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 140)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 145)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 150)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 155)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 160)
            {
                enemyMovingMode.Tentacle_Mode1();
                enemyMovingMode.Quuen_Mode2_Destroy();
            } if (tmp == 165)
            {
                enemyMovingMode.WormMove_Mode2();
            } if (tmp == 170)
            {
                enemyMovingMode.Corrupted_Mode3();
            } if (tmp == 175)
            {
                enemyMovingMode.Tentacle_Mode3();
            } if (tmp == 180)
            {
                enemyMovingMode.Corrupted_Mode2();
            } if (tmp == 185)
            {
                enemyMovingMode.Mosquito_Mode3(); enemyMovingMode.Corrupted_Mode1();
            } if (tmp == 190)
            {
                enemyMovingMode.Mosquito_Mode4(); enemyMovingMode.Corrupted_Mode3();
            } if (tmp == 195)
            {
                enemyMovingMode.Mosquito_Mode2(); enemyMovingMode.Corrupted_Mode3();
            } if (tmp == 200)
            {
                enemyMovingMode.Mosquito_Mode1();
                enemyMovingMode.Mosquito_Mode2();
                enemyMovingMode.Mosquito_Mode4();
                enemyMovingMode.Mosquito_Mode6();
            } if (tmp == 205)
            {
                enemyMovingMode.Corrupted_Mode2();
            } if (tmp == 210)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if (tmp == 215)
            {
                enemyMovingMode.Corrupted_Mode2();
            } if (tmp == 220)
            {
                enemyMovingMode.Tentacle_Mode1();
            } if(tmp == 259)
            {
                ShowBoss();
            }

            if (tmp >= maxTime)
            {
                ifStop = true;
            }
            */
#endregion

            //  MINUS
            if (tmp >= 60) {
                ShowBoss();
                ifStop = true;
            }
        }
    }
}
