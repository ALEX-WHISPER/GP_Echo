using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CountDownForWholeLevel_0 : MonoBehaviour
{
    public event Action<int> AllEnemyWavesEnded;

    public int tmp;
    public int maxTime = 60;
    public int minTime;
    public Text timeText;
    public float waveDelay;
    public GameObject bossBody;
    public Vector3 bossMoveTo;
    public float bossMoveDuration;

    protected EnemyMovingMode_Level0 enemyMovingMode;
    protected bool ifStop = true;
    private AsyncOperation async = null;
    private PlayerMove playerControl;

    protected void OnEnable() {
        if (GameObject.FindWithTag("Player") != null) {
            playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
            if (playerControl == null) {
                Debug.Log("there is no PlayerMove.cs attached in Player");
                return;
            }

            playerControl.GameOver_PlayerDead += OnGameOver_PlayerDead;
        }
    }
    protected void OnDisable() {
        playerControl.GameOver_PlayerDead -= OnGameOver_PlayerDead;
    }
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
        while (true && !ifStop)
        {
            //  0-5s:
            if (tmp >= 0 && tmp <= 5)
            {
                yield return new WaitForSeconds(1f);
            }

            //  5-20s:
            if (tmp > 5 && tmp <= 30)
            {
                enemyMovingMode.WormMove_Mode2();
                yield return new WaitForSeconds(waveDelay);

            }//  5-20s

            //  20-40s:
            if (tmp > 30 && tmp < maxTime)
            {
                enemyMovingMode.DragonMove_Mode1();
                yield return new WaitForSeconds(10);
            }

            if (tmp >= maxTime)
            {
                break;
            }
        }
    }
    protected IEnumerator CountDown() {
        while (tmp < maxTime && !ifStop) {
            tmp++;
            yield return new WaitForSeconds(1f);

            if (tmp >= maxTime) {
                if (AllEnemyWavesEnded != null) {
                    AllEnemyWavesEnded(SceneManager.GetActiveScene().buildIndex + 1);
                }
                ifStop = true;
            }
        }
    }

    protected void OnGameOver_PlayerDead() {
        StopCoroutine(CountDown());
        StopCoroutine(InvokeMovingModes());
        ifStop = true;
    }
    protected virtual void ShowBoss() {
        bossBody.SetActive(true);
        TweenPosition.Begin(bossBody, bossMoveDuration, bossMoveTo);
        Invoke("StartAttack", 1f);
    }
    private void StartAttack() {
        bossBody.GetComponent<BossHealth>().enabled = true;
    }
}
