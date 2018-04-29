using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSetting : MonoBehaviour {
    public GameObject languagePan;
    public Vector3 moveGoTo;
    public Vector3 moveBackTo;
    public float duration;
    private bool ifCN = true;
    private string lanStr;
    private bool ifHidden = true;
    public void SelectLanguage_CN()
    {
        lanStr = "CN";
        GetComponent<AudioSource>().Play();
    }

    public void SelectLanguage_ENG()
    {
        lanStr = "ENG";
        GetComponent<AudioSource>().Play();
    }

    public void ConfirmLanguage()
    {
        LanguageManager.lanInstance.CurLanguage(lanStr);
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && !ifHidden)
        {
            TweenPosition.Begin(languagePan, duration, moveBackTo);
            ifHidden = true;
        }
    }

    public void SetActive()
    {
        ifHidden = false;
        TweenPosition.Begin(languagePan, duration, moveGoTo);
    }
}
