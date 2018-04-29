using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectTackle : MonoBehaviour, IPointerClickHandler {
    public int tackle_ID;
    private UIControl_Start UIControl;

    void Start()
    {
        UIControl = GameObject.FindWithTag("UI").GetComponent<UIControl_Start>();
    }

    public void SelectThisTackle()
    {
        if (UIControl.IfBagIsFull())
        {
            return;
        }
        else
        {
            UIControl.TackleSelectingIndex(this.tackle_ID);
            gameObject.SetActive(false);
        }
    }

    public void ShowSelectedTackleInfo()
    {
        UIControl.TackleSelectingIndex_Info(this.tackle_ID);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            SelectThisTackle();
        }
        if(eventData.clickCount == 1)
        {
            ShowSelectedTackleInfo();
        }
    }
}
