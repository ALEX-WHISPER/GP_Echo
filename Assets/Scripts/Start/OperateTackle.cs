using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OperateTackle : MonoBehaviour, IPointerClickHandler {
    public int cell_ID;
    public Sprite[] tackleSprites = new Sprite[8];
    private UIControl_Start UIControl;

    void Start()
    {
        UIControl = GameObject.FindWithTag("UI").GetComponent<UIControl_Start>();
    }

    public void AddTackle(int spriteIndex)
    {
        if(GetComponent<Image>().enabled == false)
        {
            GetComponent<Image>().enabled = true;
        }
        GetComponent<Image>().sprite = tackleSprites[spriteIndex];
    }

    public void DeSelectThisTackle()
    {
        if (!UIControl.IfCellIsFull(cell_ID))
        {
            return;
        }
        else
        {
            GetComponent<Image>().enabled = false;
            UIControl.TackleDeSelectedIndex(cell_ID);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            DeSelectThisTackle();
        }
    }
}
