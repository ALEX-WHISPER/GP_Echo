using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public int initialScore;
    public int scoreAmountToAddRed;
    public int scoreAmountToAddBlue;

    private PlayerMove playerControl;
    public int scoreValue;

    void Start()
    {
        playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (playerControl == null) {
            Debug.Log("Player is null");
            return;
        }
        scoreValue = initialScore;
        scoreText.text = scoreValue.ToString();
    }

    public void AddScore(int scoreIncrement)
    {
        scoreValue += scoreIncrement;
        scoreText.text = scoreValue.ToString();
        UpdatePlayerProperties();
    }
    
    private void UpdatePlayerProperties()
    {
        if(scoreValue % scoreAmountToAddRed == 0)
        {
            playerControl.RedSqureAdd();
        }
        if(scoreValue % scoreAmountToAddBlue == 0)
        {
            playerControl.BlueSqureAdd();
        }
    }
}
