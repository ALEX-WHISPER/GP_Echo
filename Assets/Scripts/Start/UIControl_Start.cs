using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl_Start : MonoBehaviour {
    public string startSceneName;
    public GameObject steelPanel;
    public GameObject levelPanel;
    public float steelPanel_Duration;
    public float levelPanel_Duration;
    public Vector3 steelPanel_MoveTo;
    public Vector3 levelPanel_MoveTo;
    public AudioClip[] audioClips;

    public GameObject characterCell;    //  人物格子
    public GameObject characterInfoCell;    //  人物介绍
    public Sprite[] charSprites = new Sprite[3];    //  人物图片
    public Sprite[] charInfoSprites = new Sprite[3];    //  人物介绍图片
    public Sprite[] charInfoSprites_English = new Sprite[3];    //  人物介绍图片-英文

    public GameObject machineCell;      //  主角机格子
    public Sprite[] machineSprites = new Sprite[3]; //  主角机图片

    public GameObject[] bagCells = new GameObject[5];   //  背包格子
    public GameObject tackleInfoCell;   //  道具介绍格子
    public GameObject[] selectCells = new GameObject[6];    //  道具栏
    public Sprite[] tackleSprites = new Sprite[6];  //  道具图片
    public Sprite[] tackleInfoSprites = new Sprite[6];  //  道具介绍图片
    public Sprite[] tackleInfoSprites_English = new Sprite[6];  //  道具介绍图片-英文

    [HideInInspector]
    public bool ifBagFull = false;

    private Vector3 steelPanel_StartPos;
    private Vector3 levelPanel_StartPos;
    private Dictionary<int, bool> bagCellIsFullDic = new Dictionary<int,bool>();  //  Key: 格子id, Value: 是否已填
    private Dictionary<int, int> bagCellSpriteDic = new Dictionary<int, int>();     //  Key: 格子id, Value: 对应的图片id

    void Start()
    {
        steelPanel_StartPos = steelPanel.transform.position;
        levelPanel_StartPos = levelPanel.transform.position;

        InitBagCellDic();
    }

    //  选择关卡
    public void ClickChooseLevel()
    {
        TweenPosition.Begin(steelPanel, steelPanel_Duration, steelPanel_MoveTo);
        TweenPosition.Begin(levelPanel, levelPanel_Duration, levelPanel_MoveTo);

        GetComponent<AudioSource>().clip = audioClips[0];
        GetComponent<AudioSource>().Play();
    }

    //  返回仓库
    public void ClickBackToWarehouse()
    {
        TweenPosition.Begin(steelPanel, steelPanel_Duration, steelPanel_StartPos);
        TweenPosition.Begin(levelPanel, levelPanel_Duration, levelPanel_StartPos);

        GetComponent<AudioSource>().clip = audioClips[0];
        GetComponent<AudioSource>().Play();
    }

/* 人物 */
    public void CharacterSelectingIndex(int charIndex)
    {
        GetComponent<AudioSource>().clip = audioClips[1];
        GetComponent<AudioSource>().Play();

        if(characterCell.GetComponent<Image>().enabled == false)
        {
            characterCell.GetComponent<Image>().enabled = true;
        }
        if (characterInfoCell.GetComponent<Image>().enabled == false)
        {
            characterInfoCell.GetComponent<Image>().enabled = true;
        }
        characterCell.GetComponent<Image>().sprite = charSprites[charIndex];

        if (LanguageManager.lanInstance.GetLanguageIfCN())
            characterInfoCell.GetComponent<Image>().sprite = charInfoSprites[charIndex];
        else if(!LanguageManager.lanInstance.GetLanguageIfCN())
            characterInfoCell.GetComponent<Image>().sprite = charInfoSprites_English[charIndex];
    }
/* 人物 */

/* 道具 */
    //  双击选中道具后，将对应的道具从道具栏移除，放至背包中
    public void TackleSelectingIndex(int tackleIndex)  //  参数为点击的道具对应的 id
    {
        GetComponent<AudioSource>().clip = audioClips[1];
        GetComponent<AudioSource>().Play();

        foreach(int index in bagCellIsFullDic.Keys)   //  在背包格子字典中遍历
        {
            if (!bagCellIsFullDic[index]) //  如果格子是空的
            {
                //bagCells[index].GetComponent<Image>().sprite = tackleSprites[tackleIndex];  //  将 id 号对应的道具(图片)放入该格子中
                bagCells[index].GetComponent<OperateTackle>().AddTackle(tackleIndex);
                bagCellIsFullDic[index] = true;   //  格子已填
                bagCellSpriteDic[index] = tackleIndex;  //  index: 当前格子id, tackleIndex: 道具id/图片id
                
                break;  //  一次选择对应一次放置，放置结束后退出
            }
            else
            {
                continue;
            }
        }
    }

    public void TackleSelectingIndex_Info(int tackleIndex)
    {
        if(tackleInfoCell.GetComponent<Image>().enabled == false)
        {
            tackleInfoCell.GetComponent<Image>().enabled = true;
        }
        if(LanguageManager.lanInstance.GetLanguageIfCN())
            tackleInfoCell.GetComponent<Image>().sprite = tackleInfoSprites[tackleIndex];
        else if(!LanguageManager.lanInstance.GetLanguageIfCN())
            tackleInfoCell.GetComponent<Image>().sprite = tackleInfoSprites_English[tackleIndex];
    }

    //  对背包格子右键后，将对应的道具从背包中移除，填入道具栏中
    public void TackleDeSelectedIndex(int cell_ID)  //  右键的格子 id 
    {
        bagCellIsFullDic[cell_ID] = false;  //  此时该格子未填
        //selectCells[bagCellSpriteDic[cell_ID]].GetComponent<Image>().enabled = true;   //  将对应道具填入道具栏
        selectCells[bagCellSpriteDic[cell_ID]].SetActive(true);
    }

    //  初始化格子字典
    private void InitBagCellDic()
    {
        for (int i = 0; i < 5; i++ )
        {
            bagCellIsFullDic.Add(i, false);
        }
    }

    //  检查背包是否已满
    public bool IfBagIsFull()
    {
        foreach (int index in bagCellIsFullDic.Keys)   //  遍历字典
        {
            if (!bagCellIsFullDic[index])  //  存在没满的格子
            {
                ifBagFull = false;  //  则背包未满
                return false;
            }
            else
            {
                continue;
            }
        }

        ifBagFull = true;
        return true;
    }

    //  检查格子是否已满
    public bool IfCellIsFull(int cellIndex)
    {
        return bagCellIsFullDic[cellIndex];
    }
/* 道具 */

/* 主角机 */
    public void MachineSelectingIndex(int charIndex)
    {
        GetComponent<AudioSource>().clip = audioClips[1];
        GetComponent<AudioSource>().Play();

        if (machineCell.GetComponent<Image>().enabled == false)
        {
            machineCell.GetComponent<Image>().enabled = true;
        }
        machineCell.GetComponent<Image>().sprite = machineSprites[charIndex];
    }
/* 主角机 */

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(startSceneName);
        }
    }
}
