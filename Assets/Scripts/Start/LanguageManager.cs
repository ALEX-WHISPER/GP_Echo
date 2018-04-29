using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour {
    public enum LanguageState
    {
        CN,
        ENG
    }

    public static LanguageManager lanInstance = null;
    public LanguageState languageState = LanguageState.CN;

    private string lanStr = "CN";

    void Awake()
    {
        //  单例
        if(lanInstance == null)
        {
            lanInstance = this;
        }
        else
        {
            if(lanInstance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    public void CurLanguage(string lan)
    {
        if(lan == "CN")
        {
            languageState = LanguageState.CN;
        }
        else if(lan == "ENG")
        {
            languageState = LanguageState.ENG;
        }
        lanStr = lan;
    }

    public bool GetLanguageIfCN()
    {
        return (languageState == LanguageState.CN) ? true : false;
    }

    public string GetLanguageStr()
    {
        return lanStr;
    }
}
