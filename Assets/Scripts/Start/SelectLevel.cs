using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour, IPointerClickHandler {
    public enum SelectingLevel
    {
        LEVEL_0,
        LEVEL_1,
        LEVEL_2
    }

    public string[] levelsName;
    public Sprite[] levelSprites;
    public Sprite[] levelSprites_English;
    public Sprite[] levelSprites_Selected;
    public Sprite[] levelSprites_Selected_English;

    public GameObject characterInfo;
    public GameObject machineInfo;
    public GameObject[] tackleInfo;

    private SelectingLevel curLevel = SelectingLevel.LEVEL_0;

    void Start()
    {
        UpdateLevelImage(curLevel);
    }

    public void NextPage()
    {
        GetComponent<AudioSource>().Play();

        if(curLevel == SelectingLevel.LEVEL_0)
        {
            curLevel = SelectingLevel.LEVEL_1;
        }
        else if(curLevel == SelectingLevel.LEVEL_1)
        {
            curLevel = SelectingLevel.LEVEL_2;
        }
        else if(curLevel == SelectingLevel.LEVEL_2)
        {
            curLevel = SelectingLevel.LEVEL_0;
        }
        UpdateLevelImage(curLevel);
    }

    public void LastPage()
    {
        GetComponent<AudioSource>().Play();

        if (curLevel == SelectingLevel.LEVEL_0)
        {
            curLevel = SelectingLevel.LEVEL_2;
        }
        else if (curLevel == SelectingLevel.LEVEL_2)
        {
            curLevel = SelectingLevel.LEVEL_1;
        }
        else if (curLevel == SelectingLevel.LEVEL_1)
        {
            curLevel = SelectingLevel.LEVEL_0;
        }
        UpdateLevelImage(curLevel);
    }

    private void UpdateLevelImage(SelectingLevel curLevelState)
    {
        if(curLevelState == SelectingLevel.LEVEL_0)
        {
            GetComponent<Image>().sprite = (LanguageManager.lanInstance.GetLanguageIfCN()) ? levelSprites[0] : levelSprites_English[0];
        }
        else if(curLevelState == SelectingLevel.LEVEL_1)
        {
            GetComponent<Image>().sprite = (LanguageManager.lanInstance.GetLanguageIfCN()) ? levelSprites[1] : levelSprites_English[1];
        }
        else if (curLevelState == SelectingLevel.LEVEL_2)
        {
            GetComponent<Image>().sprite = (LanguageManager.lanInstance.GetLanguageIfCN()) ? levelSprites[2] : levelSprites_English[2];
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)   //  双击
        {
            //  进入当前选中的关卡
            EnterLevel_SpriteChange();
            GetAndSavePlayerInfo();
            EnterSelectedLevel();
        }
    }

    private void EnterLevel_SpriteChange()
    {
        if(curLevel == SelectingLevel.LEVEL_0)
        {
            GetComponent<Image>().sprite = (LanguageManager.lanInstance.GetLanguageIfCN()) ? levelSprites_Selected[0] : levelSprites_Selected_English[0];
        }
        else if (curLevel == SelectingLevel.LEVEL_1)
        {
            GetComponent<Image>().sprite = (LanguageManager.lanInstance.GetLanguageIfCN()) ? levelSprites_Selected[1] : levelSprites_Selected_English[1];
        }
        else if (curLevel == SelectingLevel.LEVEL_2)
        {
            GetComponent<Image>().sprite = (LanguageManager.lanInstance.GetLanguageIfCN()) ? levelSprites_Selected[2] : levelSprites_Selected_English[2];
        }
    }

    private void GetAndSavePlayerInfo()
    {
        int charIndex = characterInfo.GetComponent<GetSourceImage>().GetSourceImageID();
        PlayerInfo.instance.SetCharacterIndex(charIndex);

        int macIndex = machineInfo.GetComponent<GetSourceImage>().GetSourceImageID();
        PlayerInfo.instance.SetMacIndex(macIndex);

        int[] tackleIndexArray = new int[5];
        for (int i = 0; i < tackleIndexArray.Length; i++ )
        {
            tackleIndexArray[i] = tackleInfo[i].GetComponent<GetSourceImage>().GetSourceImageID();
        }
        PlayerInfo.instance.SetTackleIndex(tackleIndexArray);
    }

    private void EnterSelectedLevel()
    {
        if(curLevel == SelectingLevel.LEVEL_0)
        {
            SceneManager.LoadScene(levelsName[0]);
        }
        else if (curLevel == SelectingLevel.LEVEL_1)
        {
            SceneManager.LoadScene(levelsName[1]);
        }
        else if (curLevel == SelectingLevel.LEVEL_2)
        {
            SceneManager.LoadScene(levelsName[2]);
        }
    }
}
