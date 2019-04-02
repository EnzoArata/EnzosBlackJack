﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public Text playerScore;
    public Text dealerScore;
    public Text playerLoot;
    public Text playerHealth;
    public Text dealerHealth;
    public Text playerBet;
    public Text playerSpentBet;
    public Text winLose;
    public GameObject winLoseObj;
    [SerializeField] GameObject gameAI;

    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = "Player's Hand Score : " + gameAI.GetComponent<GameMaster>().getPlayerScore();
        dealerScore.text = "Dealer's Hand Score : " + gameAI.GetComponent<GameMaster>().getDealerScore();
        playerHealth.text = "Player's Health is : " + gameAI.GetComponent<GameMaster>().getPlayerHealth();
        dealerHealth.text = "Dealer's Health is : " + gameAI.GetComponent<GameMaster>().getDealerHealth();
        playerLoot.text = "Player's Loot : " + gameAI.GetComponent<GameMaster>().getPlayerLoot();
        playerBet.text = ":" + gameAI.GetComponent<GameMaster>().getCurrentBet() + ":";
        playerSpentBet.text = "Player Bet : " + gameAI.GetComponent<GameMaster>().getCurrentBet();
        winLoseObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Player's Hand Score : " + gameAI.GetComponent<GameMaster>().getPlayerScore();
        dealerScore.text = "Dealer's Hand Score : " + gameAI.GetComponent<GameMaster>().getDealerScore();
        playerHealth.text = "Player's Health is : " + gameAI.GetComponent<GameMaster>().getPlayerHealth();
        dealerHealth.text = "Dealer's Health is : " + gameAI.GetComponent<GameMaster>().getDealerHealth();
        playerLoot.text = "Player's Loot : " + gameAI.GetComponent<GameMaster>().getPlayerLoot();
        playerBet.text = ":" + gameAI.GetComponent<GameMaster>().getCurrentBet() + ":";
        playerSpentBet.text = "Player Bet : " + gameAI.GetComponent<GameMaster>().getCurrentBet();
    }

    public void turnOnWinLose(int win)
    {
        if(win == 0)
        {
            winLoseObj.SetActive(true);
            winLose.text = "You won the Round!!!";
        }
        else if(win == 1)
        {
            winLoseObj.SetActive(true);
            winLose.text = "You lost the Round!!!";
        }
        else if(win ==2)
        {
            winLoseObj.SetActive(true);
            winLose.text = "Stalemate!!!";
        }
        Invoke("turnOffWinLose", 2f);
    }

    public void turnOffWinLose()
    {
        winLoseObj.SetActive(false);
    }

}
