using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PurpleBolt
{
    public GameObject[] shootSpawns;
    public float startDelay;
    public float shootDuration;
    public float waveDelay;
}

public class EnemyShoot_Boss3 : MonoBehaviour {
    //  子弹1
    public GameObject[] shotObjs_Bolt1;
    private bool ifStopBolt1 = true;

    //  子弹2
    public GameObject[] vertexes_Bolt2;
    public GameObject[] movingQueen_Bolt2;
    private bool ifStopBolt2 = true;

    //  子弹3
    public GameObject radialShoot_Bolt3;
    public GameObject tentacle_Bolt3;
    private bool ifStopBolt3 = true;

    //  子弹4
    public PurpleBolt purpleShoot_147;
    public PurpleBolt purpleShoot_258;
    public PurpleBolt purpleShoot_369;
    public GameObject shootRadial_Bolt4;

    private bool ifStopBolt4 = true;
    private Transform player;

    //  子弹5
    public GameObject singleRotateBolt;
    public GameObject mosquitoBolt;
    public GameObject radialBolt;
    public float radialWaveDelay;
    public Transform downRadial;
    public Transform leftRadial;
    public Transform rightRadial;
    public Transform[] mosquitoTransform;
    public Transform singleRotateShotSpawn;
    public float mosquitoWaveDelay;
    private List<GameObject> singleRotate = new List<GameObject>();
    private bool ifStopBolt5 = true;

    private bool ifAlreadyStep1 = false;
    private bool ifAlreadyStep2 = false;
    private bool ifAlreadyStep3 = false;
    private bool ifAlreadyStep4 = false;
    private bool ifAlreadyStep5 = false;
    private bool ifAlreadyStep6 = false;

    public void ShootBolt1_Start()
    {
        ifStopBolt1 = false;
        
        foreach(GameObject shotObj in shotObjs_Bolt1)
        {
            if (shotObj.activeSelf && shotObj != shotObjs_Bolt1[0])
            {
                break;
            }
            else
            {
                shotObj.SetActive(true);

                Bolt1_SubBossShootCross crossBoltObj = new Bolt1_SubBossShootCross();
                Bolt1_SubBoltMoveToStart subBoltMove = new Bolt1_SubBoltMoveToStart();
                RotateAndShootTest rotateObj = new RotateAndShootTest();
                
                if((crossBoltObj = shotObj.GetComponent<Bolt1_SubBossShootCross>()) != null)
                {
                    crossBoltObj.StartShooting();
                }
                if ((subBoltMove = shotObj.GetComponent<Bolt1_SubBoltMoveToStart>()) != null)
                {
                    shotObj.GetComponent<Bolt1_SubBoltMoveToStart>().MoveToStartPos();
                }

                if((rotateObj = shotObj.GetComponentInChildren<RotateAndShootTest>()) != null)
                {
                    rotateObj.ifCanShoot = true;
                }
            }
        }
    }

    public void ShootBolt1_Stop()
    {
        ifStopBolt1 = true;

        foreach(GameObject shotObj in shotObjs_Bolt1)
        {
            if (!shotObj.activeSelf)
            {
                break;
            }
            else
            {
                Bolt1_SubBossShootCross crossBoltObj = new Bolt1_SubBossShootCross();
                RotateAndShootTest rotateBoltObj = new RotateAndShootTest();
                Bolt1_SubBoltMoveToStart subBoltMove = new Bolt1_SubBoltMoveToStart();

                if ((crossBoltObj = shotObj.GetComponent<Bolt1_SubBossShootCross>()) != null)
                {
                    crossBoltObj.StopShooting();
                }

                if((rotateBoltObj = shotObj.GetComponentInChildren<RotateAndShootTest>()) != null)
                {
                    rotateBoltObj.ifCanShoot = false;
                }

                if ((subBoltMove = shotObj.GetComponent<Bolt1_SubBoltMoveToStart>()) != null)
                {
                    shotObj.GetComponent<Bolt1_SubBoltMoveToStart>().HideAndDestroy();
                }
            }
        }
    }

    public void ShootBolt2_Start()
    {
        ifStopBolt2 = false;

        foreach (GameObject shotObj in movingQueen_Bolt2)
        {
            if(!shotObj.activeSelf)
            {
                shotObj.SetActive(true);
                Bolt1_SubBossShootCross crossBoltObj = new Bolt1_SubBossShootCross();
                Bolt1_SubBoltMoveToStart subBoltMove = new Bolt1_SubBoltMoveToStart();
                Bolt2_MoveQueen moveQueen = new Bolt2_MoveQueen();
                if ((crossBoltObj = shotObj.GetComponent<Bolt1_SubBossShootCross>()) != null)
                {
                    crossBoltObj.StartShooting();
                }
                if ((subBoltMove = shotObj.GetComponent<Bolt1_SubBoltMoveToStart>()) != null)
                {
                    subBoltMove.MoveToStartPos();
                }
                if((moveQueen = shotObj.GetComponent<Bolt2_MoveQueen>()) != null)
                {
                    moveQueen.QueenMove();
                }
            }
        }

        foreach(GameObject shotObj in vertexes_Bolt2)
        {
            if (!shotObj.activeSelf)
            {
                shotObj.SetActive(true);
            }
        }
        
    }

    public void ShootBolt2_Stop()
    {
        ifStopBolt2 = true;

        foreach (GameObject shotObj in movingQueen_Bolt2)
        {
            if (!shotObj.activeSelf)
            {
                break;
            }
            else
            {
                Bolt1_SubBossShootCross crossBoltObj = new Bolt1_SubBossShootCross();
                Bolt1_SubBoltMoveToStart subBoltMove = new Bolt1_SubBoltMoveToStart();
                if ((crossBoltObj = shotObj.GetComponent<Bolt1_SubBossShootCross>()) != null)
                {
                    crossBoltObj.StopShooting();
                }
                if ((subBoltMove = shotObj.GetComponent<Bolt1_SubBoltMoveToStart>()) != null)
                {
                    subBoltMove.HideAndDestroy();
                }
            }
        }

        foreach (GameObject shotObj in vertexes_Bolt2)
        {
            if (!shotObj.activeSelf)
            {
                break;
            }
            else
            {
                shotObj.SetActive(false);
            }
        }
    }

    public void ShootBolt3_Start()
    {
        ifStopBolt3 = false;

        if(!radialShoot_Bolt3.activeSelf)
        {
            radialShoot_Bolt3.SetActive(true);
            radialShoot_Bolt3.GetComponent<Bolt3_Radial>().StartShooting();
        }
        if(!tentacle_Bolt3.activeSelf)
        {
            tentacle_Bolt3.SetActive(true);
            tentacle_Bolt3.GetComponent<Bolt3_Tentacle_Single>().StartTentacleHit();
        }
    }

    public void ShootBolt3_Stop()
    {
        ifStopBolt3 = true;

        if(radialShoot_Bolt3.activeSelf)
        {
            radialShoot_Bolt3.GetComponent<Bolt3_Radial>().StopShooting();
            radialShoot_Bolt3.SetActive(false);
        }
        if(tentacle_Bolt3.activeSelf)
        {
            tentacle_Bolt3.GetComponent<Bolt3_Tentacle_Single>().StopTentacleHit();
            tentacle_Bolt3.SetActive(false);
        }
    }

    public void ShootBolt4_Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        ifStopBolt4 = false;

        StartCoroutine(StartShootBolt4(purpleShoot_147));
        StartCoroutine(StartShootBolt4(purpleShoot_258));
        StartCoroutine(StartShootBolt4(purpleShoot_369));

        if (shootRadial_Bolt4.activeSelf)
        {
            return;
        }
        else
        {
            shootRadial_Bolt4.SetActive(true);
            shootRadial_Bolt4.GetComponent<Bolt3_Radial>().StartShooting();
        }
    }

    public void ShootBolt4_Stop()
    {
        ifStopBolt4 = true;

        if (!shootRadial_Bolt4.activeSelf)
        {
            return;
        }
        else
        {
            shootRadial_Bolt4.GetComponent<Bolt3_Radial>().StopShooting();
            shootRadial_Bolt4.SetActive(false);
        }
    }

    IEnumerator StartShootBolt4(PurpleBolt purpleShootType)
    {
        yield return new WaitForSeconds(purpleShootType.startDelay);

        while(true)
        {
            if (ifStopBolt4)
            {
                foreach (GameObject purpleShot in purpleShootType.shootSpawns)
                {
                    Bolt4_EveryPointStraightShoot purpleShootManager = purpleShot.GetComponent<Bolt4_EveryPointStraightShoot>();
                    purpleShootManager.StopShooting();
                }
                break;
            }
            else
            {
                foreach (GameObject purpleShot in purpleShootType.shootSpawns)
                {
                    Bolt4_EveryPointStraightShoot purpleShootManager = purpleShot.GetComponent<Bolt4_EveryPointStraightShoot>();

                    purpleShot.transform.LookAt(player);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
                    purpleShot.transform.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
                    purpleShot.transform.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度

                    purpleShootManager.StartShooting();
                }

                yield return new WaitForSeconds(purpleShootType.shootDuration);

                foreach (GameObject purpleShot in purpleShootType.shootSpawns)
                {
                    Bolt4_EveryPointStraightShoot purpleShootManager = purpleShot.GetComponent<Bolt4_EveryPointStraightShoot>();
                    purpleShootManager.StopShooting();
                }

                yield return new WaitForSeconds(purpleShootType.waveDelay);
            }
        }
    }

    public void ShootBolt5_Start()
    {
        ifStopBolt5 = false;
        GetComponent<CountDownFor_Boss3Bolt5>().StartCountDown();
    }

    public void ShootBolt5_Stop()
    {
        ifStopBolt5 = true;

        GetComponent<CountDownFor_Boss3Bolt5>().StopCountDown();

        if(singleRotate.Count > 0)
        {
            foreach (GameObject singleRotateObj in singleRotate)
            {
                singleRotateObj.GetComponent<RotateAndShootTest>().ifCanShoot = false;
            }
            singleRotate.Clear();
        }
        ClearInvokeBools();
    }

    public void ShootBolt5_Step1()
    {
        if (!ifAlreadyStep1 && !ifStopBolt5)
        {
            ShootBolt5_SingleRotate(0f);
            ifAlreadyStep1 = true;
        }
        else
        {
            return;
        } 
    }

    public void ShootBolt5_Step2()
    {
        if (!ifAlreadyStep2 && !ifStopBolt5)
        {
            ShootBolt5_SingleRotate(60f);
            ifAlreadyStep2 = true;
        }
        else
        {
            return;
        } 
    }

    public void ShootBolt5_Step3()
    {
        if (!ifAlreadyStep3 && !ifStopBolt5)
        {
            ShootBolt5_SingleRotate(120f);
            ifAlreadyStep3 = true;
        }
        else
        {
            return;
        } 
    }

    public void ShootBolt5_Step4()
    {
        if (!ifAlreadyStep4 && !ifStopBolt5)
        {
            StartCoroutine(ShootBolt5_Mosquito());
            ifAlreadyStep4 = true;
        }
        else
        {
            return;
        }
    }

    public void ShootBolt5_Step5()
    {
        if (!ifAlreadyStep5)
        {
            StartCoroutine(ShootBolt5_Radial(downRadial));
            ifAlreadyStep5 = true;
        }
        else
        {
            return;
        }
    }

    public void ShootBolt5_Step6()
    {
        if(!ifAlreadyStep6)
        {
            StartCoroutine(ShootBolt5_Radial(leftRadial));
            StartCoroutine(ShootBolt5_Radial(rightRadial));
            ifAlreadyStep6 = true;
        }
        else
        {
            return;
        }
    }

    void ShootBolt5_SingleRotate(float rotation_Z)
    {
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0f, 0f, rotation_Z);

        GameObject instance = Instantiate(singleRotateBolt, singleRotateShotSpawn.position, rotation);
        singleRotate.Add(instance);
        instance.transform.SetParent(singleRotateShotSpawn.transform);
        instance.GetComponent<RotateAndShootTest>().ifCanShoot = true;
    }

    IEnumerator ShootBolt5_Radial(Transform shotSpawn)
    {
        while(true)
        {
            if(ifStopBolt5)
            {
                break;
            }
            Instantiate(radialBolt, shotSpawn.position, radialBolt.transform.rotation);
            yield return new WaitForSeconds(radialWaveDelay);
        }
    }

    IEnumerator ShootBolt5_Mosquito()
    {
        while(true)
        {
            if(ifStopBolt5)
            {
                break;
            }
            foreach (Transform mosquitoShotSpawn in mosquitoTransform)
            {
                GameObject instance = Instantiate(mosquitoBolt, mosquitoShotSpawn.position, mosquitoShotSpawn.rotation);
                instance.GetComponent<MosquitoTransform_Bolt4>().ifFollowPlayer = true;
                instance.transform.SetParent(mosquitoShotSpawn);
            }
            yield return new WaitForSeconds(mosquitoWaveDelay);
        }
    }

    void ClearInvokeBools()
    {
        ifAlreadyStep1 = false;
        ifAlreadyStep2 = false;
        ifAlreadyStep3 = false;
        ifAlreadyStep4 = false;
        ifAlreadyStep5 = false;
        ifAlreadyStep6 = false;
    }
}
