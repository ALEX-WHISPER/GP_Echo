using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoReadAndSet : MonoBehaviour {
    public GameObject[] players;

    public GameObject machineCell;
    public Sprite[] machineSprites;
    
    public GameObject characterCell;
    public Sprite[] characterSprites;

    private GameObject player;
    private int charIndex;
    private int macIndex;
    private int[] tacklesIndexArray;

    void Start()
    {
        GetPlayerInfo();
    }

    private void GetPlayerInfo()    //  获取预选的角色、道具信息
    {
        this.charIndex = PlayerInfo.instance.GetCharacterIndex();
        this.macIndex = PlayerInfo.instance.GetMacIndex();
        this.tacklesIndexArray = PlayerInfo.instance.GetTacklesIndex();

        SetPlayerProperties();  //  根据获取的信息进行相关设置
    }

    private void SetPlayerProperties()
    {
        SetPlayerLooking();
        SetPlayerDataInfo();
    }

    private void SetPlayerLooking() //  外观设置
    {
        if (machineCell.GetComponent<Image>().enabled == false)
            machineCell.GetComponent<Image>().enabled = true;
        machineCell.GetComponent<Image>().sprite = machineSprites[this.macIndex];

        if (characterCell.GetComponent<Image>().enabled == false)
            characterCell.GetComponent<Image>().enabled = true;
        characterCell.GetComponent<Image>().sprite = characterSprites[this.charIndex];

        for (int i = 0; i < players.Length; i++ )
        {
            if (i == macIndex)
            {
                players[i].SetActive(true);
                player = players[i];
            }
            else
                players[i].SetActive(false);
        }
    }

    private void SetPlayerDataInfo()    //  数值设置
    {
        CheckBasicInfo(this.charIndex);

        for (int i = 0; i < this.tacklesIndexArray.Length; i++ )    //  对道具逐一检测，根据其下标设定对应的加成数据
        {
            CheckTackleFunction(i);
        }
    }

    private void CheckBasicInfo(int charIndexValue) //  根据选择人物设置红、蓝基础数量
    {

        if (charIndexValue == 0)        //  人物0：3 + 3
        {
            player.GetComponent<PlayerMove>().livesInitialCount = 3;
            player.GetComponent<PlayerMove>().ultimateInitialCount = 3;
        }
        else if(charIndexValue == 1)   //   人物1：4 + 2
        {
            player.GetComponent<PlayerMove>().livesInitialCount = 4;
            player.GetComponent<PlayerMove>().ultimateInitialCount = 2;
        }
        else if(charIndexValue == 2)   //   人物2：2 + 4
        {
            player.GetComponent<PlayerMove>().livesInitialCount = 2;
            player.GetComponent<PlayerMove>().ultimateInitialCount = 4;
        }
    }

    private void CheckTackleFunction(int tackleIndex)
    {
        if(tackleIndex == 0)    //  No.0 先兆火控系统：射击频率 + 10%
        {
            player.GetComponent<PlayerMove>().fireRate -= player.GetComponent<PlayerMove>().fireRate * 0.1f;
        }
        else if(tackleIndex == 1)   //  No.1 幽能反应炉：蓝 + 2
        {
            player.GetComponent<PlayerMove>().ultimateInitialCount += 2;
        }
        else if(tackleIndex == 2)   //  No.2 幽能爆弹：大招伤害 + 50%
        {
            float ulDamageAmount = player.GetComponent<PlayerMove>().GetUltimateDamageAmount();
            player.GetComponent<PlayerMove>().SetUltimateDamageAmount(ulDamageAmount + ulDamageAmount * 0.5f);
        }
        else if(tackleIndex == 3)   //  No.3 星金石装甲：红 + 1
        {
            player.GetComponent<PlayerMove>().livesInitialCount += 1;
        }
        else if(tackleIndex == 4)   //  No.4 维度推进器: 常规速度 + 20%
        {
            player.GetComponent<PlayerMove>().normalSpeed += player.GetComponent<PlayerMove>().normalSpeed * 0.2f;
        }
        else if(tackleIndex == 5)   //  No.5 高效提取器：黄 + 1
        {
            player.GetComponent<PlayerMove>().level += 1;
        }
    }
}
