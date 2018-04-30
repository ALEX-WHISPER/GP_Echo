using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public GameObject loadingPanel;
    public GameObject enemyUIPanel;
    public Slider loadingBar;
    public string loadedHintText = "Hit 'SPACE' to continue...";

    private CountDownForWholeLevel_0 enemyManager;

    private void Awake() {
        enemyManager = GetComponent<CountDownForWholeLevel_0>();
    }

    private void OnEnable() {
        if (enemyManager == null) {
            return;
        }
        enemyManager.AllEnemyWavesEnded += LoadNextLevel;
    }

    private void OnDisable() {
        if (enemyManager == null) {
            return;
        }
        enemyManager.AllEnemyWavesEnded -= LoadNextLevel;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && Input.GetKeyDown(KeyCode.LeftShift)) {
            LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadNextLevel(int sceneIndex) {
        if (loadingPanel != null) {
            loadingPanel.SetActive(true);
        }
        if (enemyUIPanel != null) {
            enemyUIPanel.SetActive(false);
        }
        
        StartCoroutine(LoadLevelAsync(sceneIndex));
    }

    IEnumerator LoadLevelAsync(int sceneIndex) {
        yield return new WaitForSeconds(0.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while (!operation.isDone) {
            float progress = operation.progress;

            if (progress >= 0.9f) {
                progress = 1f;
            }

            loadingBar.value = progress;
            loadingBar.transform.Find("LoadingProgText").GetComponent<Text>().text = Mathf.Floor(progress) * 100f + "%";

            if (progress >= 1f) {
                loadingBar.transform.Find("LoadingHintText").GetComponent<Text>().text = loadedHintText;
                if (Input.GetKeyDown(KeyCode.Space)) {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
