using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot_Boss2 : MonoBehaviour {

//  子弹1
    public GameObject[] shotSpawnsForBolt_1;    //  Bolt1-1: 往返运动的直射子弹发射口
    public GameObject bolt1_Prefab; //  子弹1-1预设体
    public float boltDelay;     //  子弹1-1的发射间隔

    public GameObject[] mouthShotSpawns;    //  Bolt1-2: 圆周运动的散射子弹发射口(口腔处)
    public float rotateRate_Bolt1;  //  子弹 1-2 预设体
    public float shootRate_Bolt1;   //  子弹1-2的发射间隔

//  子弹2
    public GameObject[] shotSpawnsForBolt_2;    //  Bolt2: 圆周运动的散射子弹(SL、SR、LL、LR 4根钳内部)发射口
    public GameObject bolt2_Prefab;     //  子弹2预设体
    public float rotateRate_Bolt2;      //  单位时间内的旋转量
    public float shootRate_Bolt2;       //  子弹的发射间隔
    public float shotSpawnDelay;        //  子弹2的发射口的激活间隔

//  子弹3
    public GameObject[] shotSpawnsForBolt_3;    //  Bolt3: 运动轨迹与所在钳子（S、L 两对）相垂直的子弹的发射口
    public GameObject[] wavePincers_Bolt4;  //  Bolt3: 挥舞的钳子

    //  触手
    public GameObject tentacle;
    private GameObject tentacle_Obj;

//  子弹4
    public GameObject bolt4_Prefab;
    public int bolt4Prefab_Count;
    public float x_Max, x_Min, yPos;
    public float instanceDelay;
    private bool ifStopBolt4 = true;

//  子弹5
    public GameObject bolt5_Prefab;
    public GameObject[] shootBack_Obj;
    public GameObject mouthShoot;
    public Transform shotPoint_Bolt5;
    public int bolt5_boltCount;
    public float shootAngleGap;
    public float shootAngle_Min;
    public float shootAngle_Max;
    public float bolt5_BoltDelay;
    public float bolt5_ShootDelay;
    private bool ifStopBolt5 = true;
    private List<float> shootRotations_bolt5 = new List<float>();

    /*  子弹1操作   
     */

    //  开始发射：子弹_1
    public void ShootBolt1_Start()
    {
        ShootBolt_1_StraightBolt();
        ShootBolt_1_RotateAround();
    }

    //  子弹 1-1
    void ShootBolt_1_StraightBolt()
    {
        //  往返运动的直射子弹(6根钳尾处)
        foreach (GameObject shotSpawn in shotSpawnsForBolt_1)
        {
            if (shotSpawn.GetComponent<ShotBolt1>() == null)
            {
                ShotBolt1 shotBolt1 = shotSpawn.AddComponent<ShotBolt1>() as ShotBolt1;

                shotBolt1.bolt_1_Prefab = bolt1_Prefab;
                shotBolt1.boltDelay = boltDelay;
                shotBolt1.shotSpawn = shotSpawn.transform;
            }
            else
            {
                shotSpawn.GetComponent<ShotBolt1>().ifCanShoot = true;
            }
        }
    }

    //  子弹 1-2
    void ShootBolt_1_RotateAround()
    {
        foreach(GameObject mouthShotSpawn in mouthShotSpawns)
        {
            if (mouthShotSpawn.GetComponent<RotateAndShootTest>() == null)
            {
                //  圆周运动的散射子弹(口腔处)
                RotateAndShootTest rotate = mouthShotSpawn.AddComponent<RotateAndShootTest>() as RotateAndShootTest;

                rotate.rotateRate = this.rotateRate_Bolt1;
                rotate.shootRate = this.shootRate_Bolt1;
                rotate.rotateAround = mouthShotSpawn.transform;
                rotate.shotSpawn = mouthShotSpawn.transform;
                rotate.bolt = this.bolt2_Prefab;
                rotate.ifCanShoot = true;
            }
            else
            {
                mouthShotSpawn.GetComponent<RotateAndShootTest>().ifCanShoot = true;
            }
        }      
    }

    //  停止发射：子弹_1
    public void ShootBolt1_Stop()
    {
        //  停止发射直线型子弹
        foreach (GameObject shotSpawn in shotSpawnsForBolt_1)
        {
            if (shotSpawn.GetComponent<ShotBolt1>() != null)
                shotSpawn.GetComponent<ShotBolt1>().ifCanShoot = false;
            else
                break;
        }

        foreach(GameObject mouthShotSpawn in mouthShotSpawns)
        {
            if (mouthShotSpawn.GetComponent<RotateAndShootTest>() != null)
            {
                //  停止发射散射型子弹
                mouthShotSpawn.GetComponent<RotateAndShootTest>().ifCanShoot = false;
            }
            else
                break;
        }
    }

    /*  子弹2操作   
     */

    //  开始发射：子弹_2
    public void ShootBolt2_Start()
    {
        StartCoroutine(ShootBolt_2_RotateAround());
    }

    //  子弹2
    IEnumerator ShootBolt_2_RotateAround()
    {
        //  圆周运动的散射子弹(SL、SR、LL、LR 4根钳内部)
        foreach (GameObject shotSpawn in shotSpawnsForBolt_2)
        {
            if (shotSpawn.GetComponent<RotateAndShootTest>() == null)
            {
                RotateAndShootTest rotate = shotSpawn.AddComponent<RotateAndShootTest>() as RotateAndShootTest;
                rotate.rotateRate = this.rotateRate_Bolt2;
                rotate.shootRate = this.shootRate_Bolt2;
                rotate.rotateAround = shotSpawn.transform;
                rotate.shotSpawn = shotSpawn.transform;
                rotate.bolt = this.bolt2_Prefab;
                rotate.ifCanShoot = true;
                yield return new WaitForSeconds(shotSpawnDelay);
            }
            else
            {
                shotSpawn.GetComponent<RotateAndShootTest>().ifCanShoot = true;
            }
        }
    }

    //  停止发射：子弹_2
    public void ShootBolt2_Stop()
    {
        foreach (GameObject shotSpawn in shotSpawnsForBolt_2)
        {
            if (shotSpawn.GetComponent<RotateAndShootTest>() != null)
                shotSpawn.GetComponent<RotateAndShootTest>().ifCanShoot = false;
            else
                break;
        }
    }

    /*  子弹3操作   
     */

    //  开始发射：子弹3
    public void ShootBolt3_Start()
    {
        //  钳子开始挥舞
        foreach(GameObject wavePincer in wavePincers_Bolt4)
        {
            wavePincer.GetComponent<RotateAround>().enabled = true;
        }

        //  开启子弹功能
        foreach (GameObject shotSpawn in shotSpawnsForBolt_3)
        {
            //  若是第一次开启，则需要对每个发射口添加发射脚本
            if (shotSpawn.GetComponent<ShotBolt1>() == null)
            {
                ShotBolt1 shotBolt1 = shotSpawn.AddComponent<ShotBolt1>() as ShotBolt1;

                shotBolt1.bolt_1_Prefab = bolt2_Prefab;
                shotBolt1.boltDelay = boltDelay;
                shotBolt1.shotSpawn = shotSpawn.transform;
            }
            //  若不是第一次开启，说明各发射口已有发射脚本，无需重复添加，仅需打开发射开关即可
            else
            {
                shotSpawn.GetComponent<ShotBolt1>().ifCanShoot = true;
            }
        }

        //  开启触手功能
        tentacle_Obj = Instantiate(tentacle, tentacle.transform.position, tentacle.transform.rotation) as GameObject;
    }

    //  停止发射：子弹3
    public void ShootBolt3_Stop()
    {
        //  钳子停止挥舞
        foreach (GameObject wavePincer in wavePincers_Bolt4)
        {
            wavePincer.GetComponent<RotateAround>().enabled = false;
        }

        //  停止发射直线型子弹
        foreach (GameObject shotSpawn in shotSpawnsForBolt_3)
        {
            //  将发射口的发射开关关闭即停止了发射，再次开启时仅需打开开关即可
            if (shotSpawn.GetComponent<ShotBolt1>() != null)
                shotSpawn.GetComponent<ShotBolt1>().ifCanShoot = false;
            else
                break;
        }

        //  关闭触手
        if(tentacle_Obj != null)
        {
            Destroy(tentacle_Obj);
        }  
    }

    /*  子弹4操作   
     */
    public void ShootBolt4_Start()
    {
        ifStopBolt4 = false;
        StartCoroutine(ShootBolt4_Operate());
    }

    IEnumerator ShootBolt4_Operate()
    {
        while(true)
        {
            if (!ifStopBolt4)
            {        
                for (int i = 0; i < bolt4Prefab_Count; i++)
                {
                    float x_Pos = Random.Range(x_Min, x_Max);
                    Vector3 instance_Pos = new Vector3(x_Pos, yPos, 0f);
                    Instantiate(bolt4_Prefab, instance_Pos, bolt4_Prefab.transform.rotation);
                }
                yield return new WaitForSeconds(instanceDelay);
            }
            else
            {
                break;
            }
        }
    }

    public void ShootBolt4_Stop()
    {
        ifStopBolt4 = true;
    }

    /*子弹 5 操作
     * */
    public void ShootBolt5_Start()
    {
        ifStopBolt5 = false;
        InitShotSpawnsForBolt5();
        StartCoroutine(ShootBolt5_Operate());
        mouthShoot.GetComponent<RotateAndShootTest>().enabled = true;
    }

    IEnumerator ShootBolt5_Operate()
    {
        while(true)
        {
            if(!ifStopBolt5)
            {
                foreach (float shootRot_z in shootRotations_bolt5)
                {
                    if(ifStopBolt5)
                    {
                        break;
                    }
                    Quaternion shootRotation = Quaternion.identity;
                    shootRotation.eulerAngles = new Vector3(shotPoint_Bolt5.rotation.x, shotPoint_Bolt5.rotation.y, shootRot_z);

                    for (int i = 0; i < bolt5_boltCount; ++i )
                    {
                        Instantiate(bolt5_Prefab, shotPoint_Bolt5.position, shootRotation);
                        yield return new WaitForSeconds(bolt5_BoltDelay);
                    }
                    yield return new WaitForSeconds(bolt5_ShootDelay);
                    ShootBack_Bolt5();
                }
            }
            else
            {
                break;
            }
        }
    }

    private void ShootBack_Bolt5()
    {
        if (!ifStopBolt5)
        {
            foreach (GameObject shootBack in shootBack_Obj)
            {
                shootBack.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject shootBack in shootBack_Obj)
            {
                shootBack.SetActive(false);
            }
        }
    }

    private void InitShotSpawnsForBolt5()
    {
        float shootRotation_z = shootAngle_Min;

        do
        {
            shootRotations_bolt5.Add(shootRotation_z);
            shootRotation_z += shootAngleGap;

        } while (shootRotation_z <= shootAngle_Max);
    }

    public void ShootBolt5_Stop()
    {
        ifStopBolt5 = true;
        ShootBack_Bolt5();
        mouthShoot.GetComponent<RotateAndShootTest>().enabled = false;
    }
}
