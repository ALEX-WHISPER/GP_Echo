using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl_Start0 : MonoBehaviour {
    public GameObject upSteel;
    public GameObject downSteel;
    public Vector3 upSteelMoveTo;
    public Vector3 downSteelMoveTo;
    public float moveDuration;
    public float steelShowDelay;
    public string nextLevelName;

    void Start()
    {
        Invoke("SteelOpen", steelShowDelay);
    }

    private void SteelOpen()
    {
        TweenPosition.Begin(upSteel, moveDuration, upSteelMoveTo);
        TweenPosition.Begin(downSteel, moveDuration, downSteelMoveTo);
        GetComponent<AudioSource>().Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextLevelName);
        GetComponent<AudioSource>().Play();
    }

    public void Setting()
    {
        GetComponent<LanguageSetting>().SetActive();
        GetComponent<AudioSource>().Play();
    }

    public void QuitGame()
    {
        Application.Quit();
        GetComponent<AudioSource>().Play();
    }
}
