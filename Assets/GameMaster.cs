using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{


    [SerializeField] List<GameObject> cardDeck;
    public List<GameObject> playerHand;
    public List<GameObject> dealerHand;
    public GameObject buttonMgr;
    private static Random randomized = new Random();
    public int playerHealth;
    public int dealerHealth;
    public int playerLoot;
    public int currentBet;
    int playerScore = 0;
    int dealerScore = 0;

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
        if (Input.GetKeyDown("1"))
        {
            startRound();
        }

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
        Invoke("displayPlayerCard", 0.3f);
        Invoke("askHitStand", .8f);
    }


    public void continueRoundDealer()
    {

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
        Instantiate(playerHand[playerHand.Count - 1], new Vector2(261 + moveFactor, 119), Quaternion.identity);
    }

    public void displayDealerCard()
    {
        int moveFactor = playerHand.Count * 100;
        Instantiate(dealerHand[dealerHand.Count - 1], new Vector2(261 + moveFactor, 290), Quaternion.identity);
    }

    public void calculateScore()
    {
        playerScore = 0;
        dealerScore = 0;
        int tempScore1 = 0;
        int tempScore2 = 0;

        bool playerAce = false;
        bool dealerAce = false;
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
            playerWins();
        }
        if (playerScore != 21 && dealerScore == 21)
        {
            dealerWins();
        }
        if (playerScore == 21 && dealerScore == 21)
        {
            staleMate();
        }

    }
    public void playerWins()
    {

    }

    public void dealerWins()
    {

    }

    public void staleMate()
    {

    }

    public void increaseBet()
    {
        if(currentBet+5 < playerLoot)
        {
            currentBet += 5;
        }
    }

    public void decreaseBet()
    {
        if(currentBet>5)
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
