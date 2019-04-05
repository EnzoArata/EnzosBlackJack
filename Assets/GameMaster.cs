using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{


    [SerializeField] List<GameObject> cardDeck;
    public List<GameObject> playerHand;
    public List<GameObject> dealerHand;
    public GameObject buttonMgr;
    public GameObject ScoreMgr;
    public GameObject cardBack;
    private static Random randomized = new Random();
    public int playerHealth;
    public int dealerHealth;
    public int playerLoot;
    public int currentBet;
    int playerScore = 0;
    int dealerScore = 0;
    bool playerAce = false;
    bool dealerAce = false;
    List<GameObject> placedObjects;
    bool waitNext = false;

    void Start()
    {
        playerHealth = 100;
        dealerHealth = 100;
        playerLoot = 100;
        currentBet = 5;
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < cardDeck.Count; i++)
        {
            GameObject tempGameObject = cardDeck[i];
            int randomIndex = Random.Range(i, cardDeck.Count);
            cardDeck[i] = cardDeck[randomIndex];
            cardDeck[randomIndex] = tempGameObject;

        }



    }

    public void startRound()
    {
        for (int i = 0; i < 5; i++)
        {
            ShuffleDeck();
        }
        givePlayerCard();
        Invoke("displayPlayerCard", 0.1f);


        Invoke("giveDealerCard", 0.2f);
        Invoke("displayDealerCard", 0.3f);


        Invoke("givePlayerCard", 0.3f);
        Invoke("displayPlayerCard", 0.6f);

        Invoke("giveDealerCard", 0.5f);
        Invoke("displayDealerCard", 0.9f);

        Invoke("calculateScore", 1f);

        Invoke("askHitStand", 1.5f);

    }

    public void continueRoundPlayer()
    {
        givePlayerCard();
        Invoke("displayPlayerCard", 0.2f);
        
        calculateNewScore("player");
        if (playerScore > 21)
        {
            Invoke("revealDealerHand", 0.4f);
            Invoke("dealerWins", 0.5f);
        }
        else if (playerScore == 21)
        {
            Invoke("playerWins", 0.5f);
        }
        else
        {
            Invoke("askHitStand", .8f);
        }
    }


    public void continueRoundDealer()
    {
        revealDealerHand();
        if (dealerScore < 17)
        {
            giveDealerCard();
            calculateNewScore("dealer");
            Invoke("displayDealerCard", 0.3f);
            
            Invoke("continueRoundDealer", 0.5f);
        }
        else
        {
            Invoke("checkWinLose", 1f);
        }
    }

  
    public void givePlayerCard()
    {
        GameObject tempCard = cardDeck[cardDeck.Count - 1];
        playerHand.Add(tempCard);
        cardDeck.RemoveAt(cardDeck.Count - 1);

    }

    public void giveDealerCard()
    {
        GameObject tempCard = cardDeck[cardDeck.Count - 1];
        dealerHand.Add(tempCard);
        cardDeck.RemoveAt(cardDeck.Count - 1);
    }

    public void displayPlayerCard()
    {

        int moveFactor = playerHand.Count * 100;
        Instantiate(playerHand[playerHand.Count - 1], new Vector2(200 + moveFactor, 119), Quaternion.identity);
    }

    public void displayDealerCard()
    {

        int moveFactor = dealerHand.Count * 100;
        
        
        Instantiate(dealerHand[dealerHand.Count - 1], new Vector2(200 + moveFactor, 290), Quaternion.identity);

        
        if (dealerHand.Count == 2)
        {
            Instantiate(cardBack, new Vector3(200 + moveFactor, 290, -3), Quaternion.identity);
        }

    }
    /*
    public void moveCard(GameObject objectToMove, Vector3 destination)
    {
        Vector3 tempPosition = objectToMove.transform.position;
        
        if (objectToMove.transform.position.x > destination.x)
        {
            tempPosition.x = objectToMove.transform.position.x - 10;
            objectToMove.transform.position = tempPosition;
            cardMoveWait();
            moveCard(objectToMove, destination);
        }
    }*/

      

    public void calculateScore()
    {
        playerScore = 0;
        dealerScore = 0;
        int tempScore1 = 0;
        int tempScore2 = 0;

        playerAce = false;
        dealerAce = false;
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (playerHand[i].GetComponent<CardData>().getAce())
            {
                playerAce = true;
            }
            else
            {
                playerScore += playerHand[i].GetComponent<CardData>().getValue();
            }
        }
        for (int i = 0; i < dealerHand.Count; i++)
        {
            if (dealerHand[i].GetComponent<CardData>().getAce())
            {
                dealerAce = true;
            }
            else
            {
                dealerScore += dealerHand[i].GetComponent<CardData>().getValue();
            }
        }
        if (playerAce)
        {
            print("You have an Ace, you have two scores:   ");
            print(playerScore + 1);
            tempScore1 = playerScore + 1;
            print("   :Youre Second score is: ");
            print(playerScore + 11);
            tempScore2 = playerScore + 11;
            playerScore = calulateAceScore(tempScore1, tempScore2);
            print("The better score is: ");
            print(playerScore);

        }
        else
        {
            print("Youre score:  ");
            print(playerScore);
        }

        if (dealerAce)
        {
            print("The dealer has an Ace, he gets two scores:   ");
            print(dealerScore + 1);
            tempScore1 = dealerScore + 1;
            print("   :His Second score is: ");
            print(dealerScore + 11);
            tempScore2 = dealerScore + 11;
            dealerScore = calulateAceScore(tempScore1, tempScore2);
            print("The better score is: ");
            print(dealerScore);
        }
        else
        {
            print("The dealers score:  ");
            print(dealerScore);
        }
        if (playerScore == 21 && dealerScore != 21)
        {
            buttonMgr.GetComponent<buttonManager>().deactivateHitStand();
            playerWins();
        }
        if (playerScore == 21 && dealerScore == 21)
        {
            buttonMgr.GetComponent<buttonManager>().deactivateHitStand();
            staleMate();
        }

    }

    public void calculateNewScore(string choice)
    {
        bool newAce = false;
        if(choice == "player")
        {
            if (playerHand[playerHand.Count-1].GetComponent<CardData>().getAce())
            {
                newAce = true;
            }
            if(newAce)
            {
                playerScore = calulateAceScore(playerScore + 1, playerScore + 11);
            }
            else
            {
                playerScore += playerHand[playerHand.Count-1].GetComponent<CardData>().getValue();
            }
        }
        if (choice == "dealer")
        {
            if (dealerHand[dealerHand.Count-1].GetComponent<CardData>().getAce())
            {
                newAce = true;
            }
            if (newAce)
            {
                dealerScore = calulateAceScore(dealerScore + 1, dealerScore + 11);
            }
            else
            {
                dealerScore += dealerHand[dealerHand.Count-1].GetComponent<CardData>().getValue();
            }
        }

    }

    public void checkWinLose()
    {
        if (playerScore == 21 && dealerScore != 21)
        {
            playerWins();
        }
        else if (playerScore != 21 && dealerScore == 21)
        {
            dealerWins();
        }
        else if (playerScore == 21 && dealerScore == 21)
        {
            staleMate();
        }
        else if (playerScore > 21 && dealerScore < 21)
        {
            dealerWins();
        }
        else if (playerScore < 21 && dealerScore > 21)
        {
            playerWins();
        }
        else if (playerScore > 21 && dealerScore > 21)
        {
            staleMate();
        }
        else if(playerScore > dealerScore)
        {
            playerWins();
        }
        else if(dealerScore > playerScore)
        {
            dealerWins();
        }
        else if(playerScore == dealerScore)
        {
            staleMate();
        }


        if (dealerHealth <= 0)
        {
            //Go to win Screen
            SceneManager.LoadScene("WinScreen");
        }
        if (playerLoot <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
            //Go to lose Screen
        }
    }
    public void playerWins()
    {
        ScoreMgr.GetComponent<scoreManager>().turnOnWinLose(0);
        buttonMgr.GetComponent<buttonManager>().activateNextRound();
        playerLoot += currentBet + currentBet;
        dealerHealth -= calculateDmg();
     
        
    }

    public void dealerWins()
    {
        ScoreMgr.GetComponent<scoreManager>().turnOnWinLose(1);
        buttonMgr.GetComponent<buttonManager>().activateNextRound();
        
       
    }

    public void staleMate()
    {
        ScoreMgr.GetComponent<scoreManager>().turnOnWinLose(2);
        buttonMgr.GetComponent<buttonManager>().activateNextRound();
        playerLoot += currentBet;
      
       
    }

    public void nextRoundButton()
    {
        resetDeck();
    }

    public int calculateDmg()
    {
        int damage = 0;
        if(currentBet < 20)
        {
            damage = 5;
        }
        else if(currentBet > 20 && currentBet < 40)
        {
            damage = 10;
        }
        else if (currentBet > 40 && currentBet < 60)
        {
            damage = 20;
        }
        else if (currentBet > 60 && currentBet < 80)
        {
            damage = 30;
        }
        else if (currentBet > 80 && currentBet < 90)
        {
            damage = 40;
        }
        else if (currentBet > 90 && currentBet < 100)
        {
            damage = 50;
        }
        else if (currentBet >= 100 )
        {
            damage = 100;
        }

        return damage;
    }
   

    public void increaseBet()
    {
        if (currentBet + 5 <= playerLoot)
        {
            currentBet += 5;
        }
    }

    public void decreaseBet()
    {
        if (currentBet > 5)
        {
            currentBet -= 5;
        }
    }

    public void confirmBet()
    {
        playerLoot -= currentBet;
        startRound();
    }

    public int calulateAceScore(int score1, int score2)
    {
        int finalScore = 0;
        if (score1 > 21)
        {
            finalScore = score2;
        }
        else if (score2 > 21)
        {
            finalScore = score1;
        }
        else if (score1 > score2)
        {
            finalScore = score1;
        }
        else
        {
            finalScore = score2;
        }
        return finalScore;
    }

    public void askHitStand()
    {
        buttonMgr.GetComponent<buttonManager>().activateHitStand();
    }

    public void revealDealerHand()
    {
        GameObject[]  tempObjects = GameObject.FindGameObjectsWithTag("CardBack");
        for (int j = 0; j < tempObjects.Length; j++)
        {
            Destroy(tempObjects[j]);
        }
    }

    public void resetDeck()
    {
        buttonMgr.GetComponent<buttonManager>().deactivateHitStand();
    
        GameObject[] tempObjects;
        GameObject tempCard;
        playerScore = 0;
        dealerScore = 0;
        string[] suits = { "Diamonds", "Clubs", "Hearts", "Spades" , "CardBack"};
        
        for (int i= playerHand.Count-1; i>= 0; i--)
        {
            tempCard = playerHand[i];
            cardDeck.Add(tempCard);
            playerHand.RemoveAt(i);
        }
        for (int i = dealerHand.Count - 1; i >= 0; i--)
        {
            tempCard = dealerHand[i];
            cardDeck.Add(tempCard);
            dealerHand.RemoveAt(i);
        }

        for (int i =0;i<5;i++)
        {
            tempObjects = GameObject.FindGameObjectsWithTag(suits[i]);
            for(int j =0;j<tempObjects.Length;j++)
            {
                Destroy(tempObjects[j]);
            }
        }

        currentBet = 5;
        buttonMgr.GetComponent<buttonManager>().activateBet();
        if (dealerHealth <= 0)
        {
            //Go to win Screen
            SceneManager.LoadScene("WinScreen");
        }
        if (playerLoot <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
            //Go to lose Screen
        }

    }

    public int getPlayerScore()
    {
        return playerScore;
    }
    public int getDealerScore()
    {
        return dealerScore;
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    public int getDealerHealth()
    {
        return dealerHealth;
    }

    public int getPlayerLoot()
    {
        return playerLoot;
    }

    public int getCurrentBet()
    {
        return currentBet;
    }

}
