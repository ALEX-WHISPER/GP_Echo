using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    public GameObject[] activateObjsArr;
    public GameObject[] deactivateObjsArr;
    public LevelLoader levelLoader;

    private PlayerMove playerControl;
    private bool gameOverTrigger;

    private void Awake() {
        if (GameObject.FindWithTag("Player") != null) {
            playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        }

        if (playerControl == null) {
            Debug.LogError("there is no PlayerMove.cs attached to player!");
            return;
        }
    }

    private void OnEnable() {
        if (playerControl == null) {
            return;
        }
        playerControl.GameOver_PlayerDead += OnGameOver;
    }

    private void OnDisable() {
        if (playerControl == null) {
            return;
        }
        playerControl.GameOver_PlayerDead -= OnGameOver;
    }

    private void Update() {
        if (!gameOverTrigger) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            levelLoader.LoadNextLevel(0);
        }
    }

    private void OnGameOver() {
        for (int i = 0; i < activateObjsArr.Length; i++) {
            if (!activateObjsArr[i].activeSelf) {
                activateObjsArr[i].SetActive(true);
            }
        }

        for (int i = 0; i < deactivateObjsArr.Length; i++) {
            if (deactivateObjsArr[i].activeSelf) {
                deactivateObjsArr[i].SetActive(false);
            }
        }

        PlayerPrefs.SetInt("StuckSceneIndex", SceneManager.GetActiveScene().buildIndex);
        gameOverTrigger = true;
    }
}
