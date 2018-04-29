using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot_Boss1 : MonoBehaviour
{
    //  子弹1
    public GameObject bolt1_Prefab;
    public Transform[] shotSpawnsForBolt1;
    public int boltCount_Bolt1;
    public float boltDelay_Bolt1;
    public float shootDelay_Bolt1;
    public float bolt1Instance_Offset_X;
    public float bolt1_Instacne_Offset_Y;
    private bool ifStopBolt1 = true;

    //  子弹2
    public GameObject bolt2_Prefab;
    public Transform shotSpawn_Bolt2;
    public float tentacleGoDuation;  //  触手变大(向外戳)的持续时间
    public float tentacleBackDuration;  //  触手变小(向内收)的持续时间
    public Vector3 tentacleEndScaleValue;  //  触手在变化终点时的scale
    public Vector3 tentacleStartScaleValue; //  触手在变化起点时的scale
    public float tentacleStayDuration;      //  触手停留的时间
    public float tentacleHitDelay;          //  触手向外戳的延迟时间
    public float shootAngle_Min;
    public float shootAngle_Max;
    public float shootAngleGap;
    private List<float> shootRotation_Bolt2 = new List<float>();
    private List<GameObject> shootInstance_Obj = new List<GameObject>();
    private bool ifStopBolt2 = true;

    //  子弹3
    public GameObject[] shotSpawnsForBolt3;
    public GameObject bolt3_Mosquito;
    public float waveDelay_Bolt3;
    private bool ifStopBolt3 = true;

    //  子弹4
    public GameObject bolt4_Prefab;
    public Transform shotSpawnForBolt4;
    public float waveDelay_Bolt4;
    private List<float> shootRotation_Bolt4 = new List<float>();
    private bool ifStopBolt4 = true;

    //  子弹5
    public Transform shotSpawn_L_Bolt5;
    public Transform shotSpawn_R_Bolt5;
    public Transform shotSpawn_M_Bolt5;
    public float shootAngleOffset_LR;
    public float boltDelay_Bolt5;
    public float waveDelay_Bolt5;
    public int boltCount_Bolt5;

    public GameObject bolt5_LR;
    public GameObject bolt5_M_LookPlayer;
    private bool ifStopBolt5 = true;
    private Transform player;

    /* 子弹1操作
     */
    public void ShootBolt1_Start()
    {
        ifStopBolt1 = false;
        StartCoroutine(ShootBolt1_Operate());
    }

    IEnumerator ShootBolt1_Operate()
    {
        while(true)
        {
            if (!ifStopBolt1)
            {
                foreach (Transform shotSpawn in shotSpawnsForBolt1)
                {
                    for (int i = 0; i < boltCount_Bolt1; ++i)
                    {
                        Vector2 instancePosition = RandomPosition_Bolt1(shotSpawn.position);
                        Quaternion instanceRotation = RandomRotation_Bolt1(shotSpawn.rotation);
                        Instantiate(bolt1_Prefab, instancePosition, instanceRotation);

                        yield return new WaitForSeconds(boltDelay_Bolt1);
                    }

                    yield return new WaitForSeconds(shootDelay_Bolt1);
                }
            }

            else
            {
                break;
            }
        }
    }

    public void ShootBolt1_Stop()
    {
        ifStopBolt1 = true;
    }

    private Vector2 RandomPosition_Bolt1(Vector2 shotSpawnPos)
    {
        float randomPos_X = Random.Range(-1 * bolt1Instance_Offset_X, 1 * bolt1Instance_Offset_X);
        float randomPos_Y = Random.Range(-1 * bolt1_Instacne_Offset_Y, 1 * bolt1_Instacne_Offset_Y);

        Vector2 randomPosValue = new Vector2(shotSpawnPos.x + randomPos_X, shotSpawnPos.y + randomPos_Y);

        return randomPosValue;
    }

    private Quaternion RandomRotation_Bolt1(Quaternion shotSpawnRot)
    {
        Quaternion randomRotValue = Quaternion.identity;
        randomRotValue.eulerAngles = new Vector3(shotSpawnRot.eulerAngles.x, shotSpawnRot.eulerAngles.y, Random.Range(0, 360));

        return randomRotValue;
    }


    /*  子弹2操作
     * */
    public void ShootBolt2_Start()
    {
        ifStopBolt2 = false;
        InitTentacleObjs();
        StartCoroutine(ShootBolt2_Operate());
    }

    public void ShootBolt2_Stop()
    {
        ifStopBolt2 = true;
        ClearAndDestroyTentacles();
    }

    IEnumerator ShootBolt2_Operate()
    {
        while(true)
        {
            if (!ifStopBolt2)
            {
                TentacleGo();
                yield return new WaitForSeconds(tentacleStayDuration);

                TentacleBack();
                yield return new WaitForSeconds(tentacleHitDelay);

                ShotSpawnRotate();
            }
            else
            {
                break;
            }
        }
    }

    private void InitTentacleObjs()
    {
        float shootRotation_z = shootAngle_Min;

        do
        {
            shootRotation_Bolt2.Add(shootRotation_z);
            shootRotation_z += shootAngleGap;

        } while (shootRotation_z <= shootAngle_Max);

        foreach (float rotation_z in shootRotation_Bolt2)
        {
            Quaternion shootRotation = Quaternion.identity;
            shootRotation.eulerAngles = new Vector3(shotSpawn_Bolt2.rotation.eulerAngles.x, shotSpawn_Bolt2.rotation.eulerAngles.y, rotation_z);
            
            GameObject instance_Obj = Instantiate(bolt2_Prefab, shotSpawn_Bolt2.position, shootRotation) as GameObject;
            instance_Obj.transform.SetParent(shotSpawn_Bolt2);
            
            shootInstance_Obj.Add(instance_Obj);
        }
    }

    private void ClearAndDestroyTentacles()
    {
        shootRotation_Bolt2.Clear();

        foreach(GameObject instance_Obj in shootInstance_Obj)
        {
            Destroy(instance_Obj);
        }

        shootInstance_Obj.Clear();
    }

    private void ShotSpawnRotate()
    {
        float randomRotate = Random.Range(-1 * (shootAngleGap / 2), shootAngleGap / 2);
        shotSpawn_Bolt2.Rotate(new Vector3(0, 0, randomRotate));
    }

    private void TentacleGo()
    {
        foreach (GameObject shootInstance in shootInstance_Obj)
        {
            TweenScale.Begin(shootInstance, tentacleGoDuation, tentacleEndScaleValue);
        }
    }

    private void TentacleBack()
    {
        foreach (GameObject shootInstance in shootInstance_Obj)
        {
            TweenScale.Begin(shootInstance, tentacleBackDuration, tentacleStartScaleValue);
            shootInstance.GetComponent<Bolt2_TentacleToBolt>().CreateBolt();
        }
    }

    /*  子弹3操作
     * */
    public void ShootBolt3_Start()
    {
        ifStopBolt3 = false;
        StartCoroutine(ShootBolt3_Operate());
    }

    IEnumerator ShootBolt3_Operate()
    {
        while(true)
        {
            if (!ifStopBolt3)
            {
                foreach (GameObject shotSpawn in shotSpawnsForBolt3)
                {
                    Vector3 instancePosition = shotSpawn.transform.position;
                    Quaternion instanceRotation = shotSpawn.transform.rotation;

                    Instantiate(bolt3_Mosquito, instancePosition, instanceRotation);
                }

                yield return new WaitForSeconds(waveDelay_Bolt3);
            }
            else
            {
                break;
            }
        }
    }

    public void ShootBolt3_Stop()
    {
        ifStopBolt3 = true;
    }

    /*  子弹4操作
     * */
    public void ShootBolt4_Start()
    {
        ifStopBolt4 = false;
        InitShootRotation_Bolt4();
        StartCoroutine(ShootBolt4_Operate());
    }

    IEnumerator ShootBolt4_Operate()
    {
        while (true)
        {
            if (!ifStopBolt4)
            {
                foreach (float shootRotation in shootRotation_Bolt4)
                {
                    Vector3 instancePosition = shotSpawnForBolt4.position;
                    Quaternion instanceRotation = Quaternion.identity;
                    instanceRotation.eulerAngles = new Vector3(0, 0, shootRotation);

                    Instantiate(bolt4_Prefab, instancePosition, instanceRotation);
                }

                yield return new WaitForSeconds(waveDelay_Bolt4);
            }
            else
            {
                break;
            }
        }
    }

    private void InitShootRotation_Bolt4()
    {
        float shootRotation_z = shootAngle_Min;

        do
        {
            shootRotation_Bolt4.Add(shootRotation_z);
            shootRotation_z += shootAngleGap;

        } while (shootRotation_z <= shootAngle_Max);
    }

    public void ShootBolt4_Stop()
    {
        ifStopBolt4 = true;
        shootRotation_Bolt4.Clear();
    }

    public void ShootBolt5_Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        ifStopBolt5 = false;
        StartCoroutine(ShootBolt5_Operate());
    }

    IEnumerator ShootBolt5_Operate()
    {
        while(true)
        {
            if (!ifStopBolt5)
            {
                for (int i = 0; i < boltCount_Bolt5; i++)
                {
                    //  Left Shoot
                    Transform shootTransfrom_L = LookAtPlayer(shotSpawn_L_Bolt5);

                    //  Right Shoot
                    Transform shootTransfrom_R = LookAtPlayer(shotSpawn_R_Bolt5);

                    //  Middle Shoot
                    Transform shootTransform_M = LookAtPlayer(shotSpawn_M_Bolt5);

                    if (player.transform.position.y < shotSpawn_M_Bolt5.position.y)
                    {
                        shootTransfrom_L.Rotate(Vector3.forward, shootAngleOffset_LR);
                        shootTransfrom_R.Rotate(Vector3.forward, shootAngleOffset_LR);
                    }
                    else
                    {
                        shootTransfrom_L.Rotate(Vector3.forward, -1 * shootAngleOffset_LR);
                        shootTransfrom_R.Rotate(Vector3.forward, -1 * shootAngleOffset_LR);
                    }

                    Instantiate(bolt5_LR, shootTransfrom_L.position, shootTransfrom_L.rotation);
                    Instantiate(bolt5_LR, shootTransfrom_R.position, shootTransfrom_R.rotation);
                    Instantiate(bolt5_M_LookPlayer, shootTransform_M.position, shootTransform_M.rotation);

                    yield return new WaitForSeconds(boltDelay_Bolt5);
                }
                yield return new WaitForSeconds(waveDelay_Bolt5);
            }

            else 
            {
                break;
            }
        }
    }

    public void ShootBolt5_Stop()
    {
        ifStopBolt5 = true;
    }

    Transform LookAtPlayer(Transform transform_Obj)
    {
        transform_Obj.LookAt(player);  //  绕 y 轴顺时针（自上向下俯视）旋转90度
        transform_Obj.Rotate(new Vector3(90f, 0f, 0f));     //  绕 x 轴顺时针（自前向后正视）旋转 90 度 
        transform_Obj.Rotate(new Vector3(0f, 90f, 0f)); //  绕本地 y 轴顺时针（自右向左侧视）旋转 90 度

        return transform_Obj;
    }
}
