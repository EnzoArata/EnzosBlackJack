using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public Text playerScore;
    
    public Text playerLoot;
    public Text playerHealth;
    public Slider healthBar;
    public Text playerBet;
    public Text playerSpentBet;
    public Text winLose;
    public GameObject winLoseObj;
    
    [SerializeField] GameObject gameAI;

    // Start is called before the first frame update
    void Start()
    {
        playerScore.text = "Player's Hand Score : " + gameAI.GetComponent<GameMaster>().getPlayerScore();
        healthBar.value = gameAI.GetComponent<GameMaster>().getDealerHealth()/100f;
        playerHealth.text = "Player's Health is : " + gameAI.GetComponent<GameMaster>().getPlayerHealth();
      
        playerLoot.text = "Player's Loot : " + gameAI.GetComponent<GameMaster>().getPlayerLoot();
        playerBet.text = ":" + gameAI.GetComponent<GameMaster>().getCurrentBet() + ":";
        playerSpentBet.text = "Player Bet : " + gameAI.GetComponent<GameMaster>().getCurrentBet();
        winLoseObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Player's Hand Score : " + gameAI.GetComponent<GameMaster>().getPlayerScore();
        healthBar.value = gameAI.GetComponent<GameMaster>().getDealerHealth() / 100f;
        playerHealth.text = "Player's Health is : " + gameAI.GetComponent<GameMaster>().getPlayerHealth();
       
        playerLoot.text = "Player's Loot : " + gameAI.GetComponent<GameMaster>().getPlayerLoot();
        playerBet.text = " " + gameAI.GetComponent<GameMaster>().getCurrentBet();
        playerSpentBet.text = "Player Bet : " + gameAI.GetComponent<GameMaster>().getCurrentBet();
    }

    public void turnOnWinLose(int win)
    {
        if(win == 0)
        {
            winLoseObj.SetActive(true);
            winLose.text = "You won the Round!!! \nYou have gained " + gameAI.GetComponent<GameMaster>().getCurrentBet() + " coins" ;
        }
        else if(win == 1)
        {
            winLoseObj.SetActive(true);
            winLose.text = "You lost the Round!!! \nYou have lost " + gameAI.GetComponent<GameMaster>().getCurrentBet() + " coins";
        }
        else if(win ==2)
        {
            winLoseObj.SetActive(true);
            winLose.text = "Stalemate!!! \nNo gain or loss";
        }
        
    }

    public void turnOffWinLose()
    {
        winLoseObj.SetActive(false);
    }

}
