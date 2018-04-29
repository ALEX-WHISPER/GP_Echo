using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSpaceShip : MonoBehaviour {

    public Button btn_Next;
    public Button btn_Last;
    public Button btn_EnterGame;
    
    public Sprite[] sprites_SpaceShip;
    public Image[] imgs_Char;

    private Image img_SpaceShip;
    private int curSpaceIndex;

    private void Awake() {
        img_SpaceShip = GetComponent<Image>();
        if (img_SpaceShip == null) {
            Debug.LogError("this node does not have component: Image");
            return;
        }
    }

    private void OnEnable() {
        btn_Next.onClick.AddListener(NextPage);
        btn_Last.onClick.AddListener(LastPage);
        btn_EnterGame.onClick.AddListener(EnterGame);
    }

    private void Start() {
        SwitchSpaceShipImg(0);
    }

    private void OnDisable() {
        btn_Next.onClick.RemoveListener(NextPage);
        btn_Last.onClick.RemoveListener(LastPage);
        btn_EnterGame.onClick.RemoveListener(EnterGame);
    }

    private void NextPage() {
       if (this.curSpaceIndex >= this.sprites_SpaceShip.Length - 1) {
            return;
       } else {
            curSpaceIndex++;
        }
        SwitchSpaceShipImg(curSpaceIndex);
    }

    private void LastPage() {
        if (this.curSpaceIndex <= 0) {
            return;
        } else {
            curSpaceIndex--;
        }
        SwitchSpaceShipImg(curSpaceIndex);
    }

    private void GetAndSavePlayerInfo()
    {
        PlayerInfo.instance.SetCharacterIndex(curSpaceIndex + 1);
        PlayerInfo.instance.SetMacIndex(curSpaceIndex + 1);
    }

    private void EnterGame()
    {
        GetAndSavePlayerInfo();

        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1) {
            Debug.LogError("this is the last scene in build settings!");
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SwitchSpaceShipImg(int index) {
        this.img_SpaceShip.sprite = this.sprites_SpaceShip[index];

        for (int i = 0; i < this.imgs_Char.Length; i++) {
            float opacity = (i == index) ? 255f / 255f : 100f / 255f;
            Color newColor = new Color(imgs_Char[i].color.r, imgs_Char[i].color.g, imgs_Char[i].color.b, opacity);
            imgs_Char[i].color = newColor;
        }
    }
}
