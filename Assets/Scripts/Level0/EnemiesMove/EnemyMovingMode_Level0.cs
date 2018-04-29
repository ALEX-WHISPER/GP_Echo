using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  飞龙类
[System.Serializable]
public class DragonMoveMode
{
    public GameObject dragonEnemy;
    public Transform[] moveFrom;
    public Transform[] moveTo;
    public Transform transformParent;
    public float speed;
    public float sameSideDelay;
    public float oppSideDelay;
    public float stayDuration;
    [HideInInspector]
    public List<GameObject> dragonObjList = new List<GameObject>();
}

//  飞虫类
[System.Serializable]
public class WormMoveMode
{
    public GameObject wormEnemy;
    public int wormCount;
    public float wormDelay;
    public float waveDelay;
    public Transform[] moveFrom;
    public Transform[] moveTo;
    public Transform transformParent;
    public float speed;
    public float stayDuration;
    public int y_Direction;
    public int x_Direction;
    [HideInInspector]
    public List<GameObject> wormObjList = new List<GameObject>();
}

//  自爆蚊类
[System.Serializable]
public class MosquitoMode
{
    public GameObject mosquito_L;
    public GameObject mosquito_R;
    public int boltCount;
    public float boltDelay;
    public Transform transformParent;
}

//  女皇类
[System.Serializable]
public class QueenMode
{
    public GameObject queenEnemy;
    public float queenDelay;
    public Transform[] moveFrom;
    public Transform[] moveTo;
    public Transform transformParent;
    public float speed;
    [HideInInspector]
    public List<GameObject> queenObjList = new List<GameObject>();
}

//  腐化者类
[System.Serializable]
public class CorruptedMode
{
    public GameObject corruptedEnemy;
    public float waveDelay;
    public float stayDuration;
    public Transform[] moveFrom;
    public Transform[] moveTo;
    public Transform transformParent;
    public float speed;
    [HideInInspector]
    public List<GameObject> corruptedObjList = new List<GameObject>();
}

//  触手类
[System.Serializable]
public class TentacleMode
{
    public GameObject tentacle_Follow;
    public GameObject tentacle_Static;
    public Transform[] tentacleFollow_CreatePos;
    public float tentacleFollow_EnemyDelay;
}

//  炮台类
[System.Serializable]
public class BatteryMode
{
    public GameObject batteryEnemy;
    public Transform[] moveFrom;
    public Transform[] moveTo;
    public Transform transformParent;
    public float enemyDelay;
    public float speed;
    public float stayDuration;
    [HideInInspector]
    public List<GameObject> batteryObjList = new List<GameObject>();
}

//  陨石类
[System.Serializable]
public class StoneMode
{
    public GameObject[] stoneEnemies;
    public Transform[] createPos;
    public Transform transformParent;
    public float enemyDelay_Min;
    public float enemyDelay_Max;
}
public class EnemyMovingMode_Level0 : MonoBehaviour {
    public DragonMoveMode dragonMove_1;
    public DragonMoveMode dragonMove_2;

    public WormMoveMode wormMove_1;
    public WormMoveMode wormMove_2;
    public WormMoveMode wormMove_3_1;
    public WormMoveMode wormMove_3_2;

    public MosquitoMode mosquitoMode_1;
    public MosquitoMode mosquitoMode_2;
    public MosquitoMode mosquitoMode_3;
    public MosquitoMode mosquitoMode_4;
    public MosquitoMode mosquitoMode_5;
    public MosquitoMode mosquitoMode_6;

    public QueenMode queenMode_1;
    public QueenMode queenMode_2;
    public QueenMode queenMode_3;

    public CorruptedMode corrupted_1;
    public CorruptedMode corrupted_2;
    public CorruptedMode corrupted_3;

    public TentacleMode tentacle_1;
    public TentacleMode tentacle_2;
    public TentacleMode tentacle_3;
    public TentacleMode tentacle_4;
    public TentacleMode tentacle_5;

    public BatteryMode battery_1;
    public BatteryMode battery_2;
    public BatteryMode battery_3;
    public BatteryMode battery_4;

    public StoneMode stone_1;
    public StoneMode stone_2;

    //  启动: 飞龙-1
    public void DragonMove_Mode1()
    {
        StartCoroutine(DragonMove_Mode1_Operate());
    }

    //  飞龙-1模式控制
    IEnumerator DragonMove_Mode1_Operate()
    {
        for (int i = 0; i < dragonMove_1.moveFrom.Length; ++i )
        {
            GameObject dragonObj = Instantiate(dragonMove_1.dragonEnemy, dragonMove_1.moveFrom[i].position, Quaternion.identity);
            dragonObj.transform.SetParent(dragonMove_1.transformParent);
            dragonMove_1.dragonObjList.Add(dragonObj);
            SetTweenPosition(dragonObj, dragonMove_1.moveTo[i].position, (Mathf.Abs(dragonMove_1.moveTo[i].position.y - dragonMove_1.moveFrom[i].position.y)) / dragonMove_1.speed);
            if (i != 2)
            {
                yield return new WaitForSeconds(dragonMove_1.sameSideDelay);
            }
            else
            {
                yield return new WaitForSeconds(dragonMove_1.oppSideDelay);
            }
        }
        
        yield return new WaitForSeconds(dragonMove_1.stayDuration);

        foreach(GameObject dragonObj in dragonMove_1.dragonObjList)
        {
            dragonObj.AddComponent<Bolt_Ordinary>();
            dragonObj.GetComponent<Bolt_Ordinary>().speed = dragonMove_1.speed;
            dragonObj.GetComponent<Bolt_Ordinary>().direction_Y = -1;
            dragonObj.GetComponent<DragonShoot>().enabled = true;
        }
        dragonMove_1.dragonObjList.Clear();
    }

    //  启动: 飞龙-2
    public void DrangonMove_Mode2()
    {
        StartCoroutine(DragonMove_Mode2_Operate());
    }

    //  飞龙-2模式控制
    IEnumerator DragonMove_Mode2_Operate()
    {
        for (int i = 0; i < dragonMove_2.moveFrom.Length; ++i)
        {
            GameObject dragonObj = Instantiate(dragonMove_2.dragonEnemy, dragonMove_2.moveFrom[i].position, Quaternion.identity);
            dragonObj.transform.SetParent(dragonMove_2.transformParent);
            dragonMove_2.dragonObjList.Add(dragonObj);
            SetTweenPosition(dragonObj, dragonMove_2.moveTo[i].position, (Mathf.Abs(dragonMove_2.moveTo[i].position.y - dragonMove_2.moveFrom[i].position.y)) / dragonMove_1.speed);
               
            yield return new WaitForSeconds(dragonMove_2.oppSideDelay);
        }
        yield return new WaitForSeconds(dragonMove_2.stayDuration);
        
        foreach (GameObject dragonObj in dragonMove_2.dragonObjList)
        {
            dragonObj.AddComponent<Bolt_Ordinary>();
            dragonObj.GetComponent<Bolt_Ordinary>().speed = dragonMove_2.speed;
            dragonObj.GetComponent<Bolt_Ordinary>().direction_Y = -1;
        }
        dragonMove_2.dragonObjList.Clear();
    }

    //  启动: 飞虫-1
    public void WormMove_Mode1()
    {
        StartCoroutine(WormMoveMode1_Operate(wormMove_1));
    }

    //  飞虫-1模式控制
    IEnumerator WormMoveMode1_Operate(WormMoveMode wormMoveMode)
    {
        for (int i = 0; i < wormMoveMode.moveFrom.Length; ++i )
        {
            for (int j = 0; j < wormMoveMode.wormCount; ++j )
            {
                GameObject wormObj = Instantiate(wormMoveMode.wormEnemy, wormMoveMode.moveFrom[i].position, Quaternion.identity);
                wormObj.transform.SetParent(wormMoveMode.transformParent);
                SetTweenPosition(wormObj, wormMoveMode.moveTo[i].position, (Mathf.Abs(wormMoveMode.moveTo[i].position.x - wormMoveMode.moveFrom[i].position.x)) / wormMoveMode.speed);
                yield return new WaitForSeconds(wormMoveMode.wormDelay);
            }
            yield return new WaitForSeconds(wormMoveMode.waveDelay);
        }
    }

    //  启动: 飞虫-2
    public void WormMove_Mode2()
    {
        StartCoroutine(WormMoveMode2_Operate(wormMove_2));
    }

    //  飞虫-2模式控制
    IEnumerator WormMoveMode2_Operate(WormMoveMode wormMoveMode)
    {
        //  生成并移动至指定位置
        for (int i = 0; i < wormMoveMode.moveFrom.Length; ++i)
        {
            GameObject wormObj = Instantiate(wormMoveMode.wormEnemy, wormMoveMode.moveFrom[i].position, Quaternion.identity);
            wormObj.transform.SetParent(wormMoveMode.transformParent);
            wormMoveMode.wormObjList.Add(wormObj);
            SetTweenPosition(wormObj, wormMoveMode.moveTo[i].position, (Mathf.Abs(wormMoveMode.moveTo[i].position.y - wormMoveMode.moveFrom[i].position.y)) / wormMoveMode.speed);
            yield return new WaitForSeconds(wormMoveMode.wormDelay);
        }

        yield return new WaitForSeconds(wormMoveMode.stayDuration); //  停留

        //  继续运动
        foreach (GameObject wormObj in wormMoveMode.wormObjList)
        {
            wormObj.AddComponent<Bolt_Ordinary>();
            wormObj.GetComponent<Bolt_Ordinary>().speed = wormMoveMode.speed;
            wormObj.GetComponent<Bolt_Ordinary>().direction_Y = wormMoveMode.y_Direction;
        }
        wormMoveMode.wormObjList.Clear();
    }

    //  启动: 飞虫-3
    public void WormMove_Mode3()
    {
        StartCoroutine(WormMoveMode3_Operate(wormMove_3_1));
        StartCoroutine(WormMoveMode3_Operate(wormMove_3_2));
    }

    //  飞虫-3模式控制
    IEnumerator WormMoveMode3_Operate(WormMoveMode wormMoveMode)
    {
        //  实例化，每个怪物物体根据其自身运动模式，从某一位置运动到另一位置
        for (int i = 0; i < wormMoveMode.moveFrom.Length; ++i)
        {
            GameObject wormObj = Instantiate(wormMoveMode.wormEnemy, wormMoveMode.moveFrom[i].position, Quaternion.identity);
            wormObj.transform.SetParent(wormMoveMode.transformParent);
            wormMoveMode.wormObjList.Add(wormObj);

            //  为每个实例化的怪物的运动终点属性赋值
            SetTweenPosition(wormObj, wormMoveMode.moveTo[i].position, (Mathf.Abs(wormMoveMode.moveTo[i].position.x - wormMoveMode.moveFrom[i].position.x)) / wormMoveMode.speed);
            yield return new WaitForSeconds(wormMoveMode.wormDelay);
        }

        yield return new WaitForSeconds(wormMoveMode.stayDuration); //  运动到指定位置后，停留一段时间

        //  集体向某一方向(水平或垂直)继续运动
        foreach (GameObject wormObj in wormMoveMode.wormObjList)
        {
            wormObj.AddComponent<Bolt_Ordinary>();
            wormObj.GetComponent<Bolt_Ordinary>().speed = wormMoveMode.speed;
            wormObj.GetComponent<Bolt_Ordinary>().direction_X = wormMoveMode.x_Direction;
            wormObj.GetComponent<Bolt_Ordinary>().direction_Y = wormMoveMode.y_Direction;
        }
        wormMoveMode.wormObjList.Clear();
    }

    //  设置怪物的运动终点
    private void SetTweenPosition(GameObject gameObj, Vector3 moveTo, float duration)
    {
        gameObj.GetComponent<TweenPositionMove>().moveTo = moveTo;
        gameObj.GetComponent<TweenPositionMove>().duration = duration;
    }

    //  启动: 自爆蚊-1
    public void Mosquito_Mode1()
    {
        StartCoroutine(CreateMosquito(mosquitoMode_1));
    }

    //  启动: 自爆蚊-2
    public void Mosquito_Mode2()
    {
        StartCoroutine(CreateMosquito(mosquitoMode_2));
    }

    //  启动: 自爆蚊-3
    public void Mosquito_Mode3()
    {
        StartCoroutine(CreateMosquito(mosquitoMode_3));
    }

    //  启动: 自爆蚊-4
    public void Mosquito_Mode4()
    {
        StartCoroutine(CreateMosquito(mosquitoMode_4));
    }

    //  启动: 自爆蚊-5
    public void Mosquito_Mode5()
    {
        StartCoroutine(CreateMosquito(mosquitoMode_5));
    }

    //  启动: 自爆蚊-6
    public void Mosquito_Mode6()
    {
        StartCoroutine(CreateMosquito(mosquitoMode_6));
    }

    //  自爆蚊模式创建
    IEnumerator CreateMosquito(MosquitoMode mosquitoMode)
    {
        for (int j = 0; j < mosquitoMode.boltCount; ++j)
        {
            GameObject instance_L = Instantiate(mosquitoMode.mosquito_L);
            instance_L.transform.SetParent(mosquitoMode.transformParent);

            GameObject instance_R = Instantiate(mosquitoMode.mosquito_R);
            instance_R.transform.SetParent(mosquitoMode.transformParent);

            yield return new WaitForSeconds(mosquitoMode.boltDelay);
        } 
    }

    //  启动: 女皇-1
    public void Queen_Mode1()
    {
        StartCoroutine(QueenMode_Operate(queenMode_1));
    }

    //  启动: 女皇-2
    public void Queen_Mode2()
    {
        StartCoroutine(QueenMode_Operate(queenMode_2));
    }

    //  启动: 女皇-3
    public void Queen_Mode3()
    {
        StartCoroutine(QueenMode_Operate(queenMode_3));
    }

    public void Quuen_Mode1_Destroy() 
    {
        DestroyQueenObj(queenMode_1);
    }

    public void Quuen_Mode2_Destroy()
    {
        DestroyQueenObj(queenMode_2);
    }

    public void Quuen_Mode3_Destroy()
    {
        DestroyQueenObj(queenMode_3);
    }

    //  女皇模式创建
    IEnumerator QueenMode_Operate(QueenMode queenMoveMode)
    {
        for (int i = 0; i < queenMoveMode.moveFrom.Length; ++i)
        {
            GameObject queenObj = Instantiate(queenMoveMode.queenEnemy, queenMoveMode.moveFrom[i].position, Quaternion.identity);
            queenObj.transform.SetParent(queenMoveMode.transformParent);
            queenMoveMode.queenObjList.Add(queenObj);
            SetTweenPosition(queenObj, queenMoveMode.moveTo[i].position, (Mathf.Abs(queenMoveMode.moveTo[i].position.y - queenMoveMode.moveFrom[i].position.y)) / queenMoveMode.speed);
            yield return new WaitForSeconds(queenMoveMode.queenDelay);
        }
    }

    //  女皇模式销毁
    private void DestroyQueenObj(QueenMode queenMoveMode)
    {
        foreach(GameObject queenObj in queenMoveMode.queenObjList)
        {
            Destroy(queenObj);
        }
        queenMoveMode.queenObjList.Clear();
    }

    public void Corrupted_Mode1()
    {
        StartCoroutine(CorruptedMove_Operate(corrupted_1));
    }

    public void Corrupted_Mode2()
    {
        StartCoroutine(CorruptedMove_Operate(corrupted_2));
    }

    public void Corrupted_Mode3()
    {
        StartCoroutine(CorruptedMove_Operate(corrupted_3));
    }

    IEnumerator CorruptedMove_Operate(CorruptedMode corruptedMove)
    {
        //  腐化者-1
        if(corruptedMove == corrupted_1)
        {
            float moveDuration = CalcMoveDuration((corruptedMove.moveFrom[0].position.x - corruptedMove.moveTo[0].position.x),
                (corruptedMove.moveFrom[0].position.y - corruptedMove.moveTo[0].position.y), corruptedMove.speed);

            for (int i = 0; i < corruptedMove.moveFrom.Length; i = i + 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    GameObject corruptedObj = Instantiate(corruptedMove.corruptedEnemy, corruptedMove.moveFrom[i + j].position, Quaternion.identity);
                    corruptedObj.transform.SetParent(corruptedMove.transformParent);
                    corruptedMove.corruptedObjList.Add(corruptedObj);

                    SetTweenPosition(corruptedObj, corruptedMove.moveTo[i + j].position, moveDuration);
                }
                yield return new WaitForSeconds(corruptedMove.waveDelay);
            }
            yield return new WaitForSeconds(corruptedMove.stayDuration);

            for (int n = 0; n < corruptedMove.corruptedObjList.Count; n++)
            {
                TweenPosition.Begin(corruptedMove.corruptedObjList[n], moveDuration, corruptedMove.moveFrom[n].position);
            }
            corruptedMove.corruptedObjList.Clear();
        }

        //  腐化者-2
        else if(corruptedMove == corrupted_2)
        {
            for (int i = 0; i < corruptedMove.moveFrom.Length; i++ )
            {
                GameObject corruptedObj = Instantiate(corruptedMove.corruptedEnemy, corruptedMove.moveFrom[i].position, Quaternion.identity);
                corruptedObj.transform.SetParent(corruptedMove.transformParent);
                corruptedMove.corruptedObjList.Add(corruptedObj);

                float moveDuration = CalcMoveDuration(0, (corruptedMove.moveFrom[i].position.y - corruptedMove.moveTo[i].position.y), corruptedMove.speed);
                SetTweenPosition(corruptedObj, corruptedMove.moveTo[i].position, moveDuration);

                if(i == 0 || i == 2)
                {
                    yield return new WaitForSeconds(corruptedMove.waveDelay);
                }
            }
            yield return new WaitForSeconds(corruptedMove.stayDuration);

            //  集体向某一方向(水平或垂直)继续运动
            foreach (GameObject corruptedObj in corruptedMove.corruptedObjList)
            {
                corruptedObj.AddComponent<Bolt_Ordinary>();
                corruptedObj.GetComponent<Bolt_Ordinary>().speed = corruptedMove.speed;
                corruptedObj.GetComponent<Bolt_Ordinary>().direction_X = 0;
                corruptedObj.GetComponent<Bolt_Ordinary>().direction_Y = -1;
            }
            corruptedMove.corruptedObjList.Clear();
        }
        //  腐化者-3
        else if(corruptedMove == corrupted_3)
        {
            for (int i = 0; i < corruptedMove.moveFrom.Length; i++ )
            {
                float moveDuration = CalcMoveDuration((corruptedMove.moveFrom[0].position.x - corruptedMove.moveTo[0].position.x), 0, corruptedMove.speed);
                GameObject corruptedObj = Instantiate(corruptedMove.corruptedEnemy, corruptedMove.moveFrom[i].position, Quaternion.identity);
                corruptedObj.transform.SetParent(corruptedMove.transformParent);
                corruptedMove.corruptedObjList.Add(corruptedObj);

                SetTweenPosition(corruptedObj, corruptedMove.moveTo[i].position, moveDuration);
            }
        }
    }

    float CalcMoveDuration(float x_Move, float y_Move, float speed)
    {
        float xMove_Squre = Mathf.Pow(x_Move, 2);
        float yMove_Squre = Mathf.Pow(y_Move, 2);
        float distance = Mathf.Sqrt(xMove_Squre + yMove_Squre);

        return (distance / speed);
    }

    public void Tentacle_Mode1()
    {
        StartCoroutine(TentacleMove_Operate(tentacle_1));
    }

    public void Tentacle_Mode2()
    {
        StartCoroutine(TentacleMove_Operate(tentacle_2));
    }

    public void Tentacle_Mode3()
    {
        StartCoroutine(TentacleMove_Operate(tentacle_3));
    }

    public void Tentacle_Mode4()
    {
        StartCoroutine(TentacleMove_Operate(tentacle_4));
    }

    public void Tentacle_Mode5()
    {
        StartCoroutine(TentacleMove_Operate(tentacle_5));
    }

    IEnumerator TentacleMove_Operate(TentacleMode tentacleMove)
    {
        if(tentacleMove == tentacle_1)
        {
            for (int i = 0; i < tentacle_1.tentacleFollow_CreatePos.Length; i++ )
            {
                Instantiate(tentacle_1.tentacle_Follow, tentacle_1.tentacleFollow_CreatePos[i].position, Quaternion.identity);
                yield return new WaitForSeconds(tentacle_1.tentacleFollow_EnemyDelay);
            }
        }
        else
        {
            Instantiate(tentacleMove.tentacle_Static);
        }
    }

    public void Battery_Mode1()
    {
        StartCoroutine(BatteryMove_Operate(battery_1));
    }

    public void Battery_Mode2()
    {
        StartCoroutine(BatteryMove_Operate(battery_2));
    }
    public void Battery_Mode3()
    {
        StartCoroutine(BatteryMove_Operate(battery_3));
    }
    public void Battery_Mode4()
    {
        StartCoroutine(BatteryMove_Operate(battery_4));
    }
    IEnumerator BatteryMove_Operate(BatteryMode batteryMove)
    {
        float moveDuration = 0f;

        if(batteryMove == battery_1 || batteryMove == battery_2)
        {
            moveDuration = CalcMoveDuration(0, (batteryMove.moveFrom[0].position.y - batteryMove.moveTo[0].position.y), batteryMove.speed);
        }
        else if (batteryMove == battery_3 || batteryMove == battery_4)
        {
            moveDuration = CalcMoveDuration((batteryMove.moveFrom[0].position.x - batteryMove.moveTo[0].position.x), 0, batteryMove.speed);
        }

        for (int i = 0; i < batteryMove.moveFrom.Length; i++ )
        {
            GameObject batteryObj = Instantiate(batteryMove.batteryEnemy, batteryMove.moveFrom[i].position, Quaternion.identity);
            batteryObj.transform.SetParent(batteryMove.transformParent);
            batteryMove.batteryObjList.Add(batteryObj);
            SetTweenPosition(batteryObj, batteryMove.moveTo[i].position, moveDuration);
            yield return new WaitForSeconds(batteryMove.enemyDelay);
        }
        if (batteryMove == battery_3 || batteryMove == battery_4)
        {
            yield return new WaitForSeconds(batteryMove.stayDuration);

            for (int n = 0; n < batteryMove.batteryObjList.Count; n++)
            {
                TweenPosition.Begin(batteryMove.batteryObjList[n], moveDuration, batteryMove.moveFrom[n].position);
            }
            batteryMove.batteryObjList.Clear();
        }
    }

    public void Stone_Mode1()
    {
        StartCoroutine(StoneMove_Operate(stone_1));
    }

    public void Stone_Mode2()
    {
        StartCoroutine(StoneMove_Operate(stone_2));
    }

    IEnumerator StoneMove_Operate(StoneMode stoneMove)
    {
        float stoneSpeed = stoneMove.stoneEnemies[0].GetComponent<Stone_Mover>().speed;
        if (stoneMove == stone_2)
        {
            stoneSpeed *= -1;
        }

        for (int i = 0; i < stoneMove.createPos.Length; i++ )
        {
            GameObject stoneObj = Instantiate
                (stoneMove.stoneEnemies[Random.Range(0, stoneMove.stoneEnemies.Length)], 
                stoneMove.createPos[Random.Range(i, stoneMove.createPos.Length)].position, 
                Quaternion.identity);
            stoneObj.GetComponent<Stone_Mover>().speed = stoneSpeed;
            yield return new WaitForSeconds(Random.Range(stoneMove.enemyDelay_Min, stoneMove.enemyDelay_Max));
        }
    }
}
