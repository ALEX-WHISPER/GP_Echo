using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour, IPointerClickHandler {
    public int char_ID;
    public bool ifMachine = false;
    private UIControl_Start UIControl;

    void Start()
    {
        UIControl = GameObject.FindWithTag("UI").GetComponent<UIControl_Start>();
    }

    public void SelectThisCharacter()
    {
        if (!ifMachine)
        {
            UIControl.CharacterSelectingIndex(char_ID);
        }
        else
        {
            UIControl.MachineSelectingIndex(char_ID);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            SelectThisCharacter();
        }
    }
}
