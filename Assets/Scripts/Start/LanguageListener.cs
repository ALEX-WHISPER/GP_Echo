using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageListener : MonoBehaviour {
    public Sprite ENGEdition;
    public Sprite CNEdition;

    void Start()
    {
        UpdateImageByLanguage();
    }
    void Update()
    {
        UpdateImageByLanguage();
    }

    private void UpdateImageByLanguage()
    {
        if (LanguageManager.lanInstance.GetLanguageIfCN())
        {
            GetComponent<Image>().sprite = CNEdition;
        }
        else
        {
            GetComponent<Image>().sprite = ENGEdition;
        }
    }
}
