using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    public static PlayerInfo instance = null;

    private int charIndex;
    private int macIndex;
    private int[] tackleIndexArray;

    void Awake()
    {
        //  单例
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetCharacterIndex(int charIndexValue)
    {
        this.charIndex = charIndexValue;
        //Debug.Log("Character: " + this.charIndex);
    }

    public void SetMacIndex(int macIndexValue)
    {
        this.macIndex = macIndexValue;
        //Debug.Log("Machine: " + this.macIndex);
    }

    public void SetTackleIndex(int[] tackleIndexArray)
    {
        this.tackleIndexArray = tackleIndexArray;
        
        for(int i = 0; i < this.tackleIndexArray.Length; i++)
        {
            //Debug.Log("Tackle: " + tackleIndexArray[i]);
        }
    }

    public int GetCharacterIndex()
    {
        return this.charIndex;
    }

    public int GetMacIndex()
    {
        return this.macIndex;
    }

    public int[] GetTacklesIndex()
    {
        return this.tackleIndexArray;
    }
}
