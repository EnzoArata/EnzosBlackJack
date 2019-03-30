﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    [SerializeField] GameObject gameAI;
    public GameObject hitGameObj;
    public GameObject standGameObj;
    public Button hitButton;
    public Button standButton;
    public GameObject increaseGameObj;
    public GameObject decreaseGameObj;
    public GameObject makeBetGameObj;
    public GameObject betAmountGameObj;
    public GameObject confirmGameObj;
    public Button increaseButton;
    public Button decreaseButton;
    public Button confirmButton;

    void Start()
    {
        hitGameObj.SetActive(false);
        standGameObj.SetActive(false);
        hitButton.onClick.AddListener(selectHit);
        standButton.onClick.AddListener(selectStand);
        increaseButton.onClick.AddListener(increaseBet);
        decreaseButton.onClick.AddListener(decreaseBet);
        confirmButton.onClick.AddListener(makeBet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateHitStand()
    {
        hitGameObj.SetActive(true);
        standGameObj.SetActive(true);
    }

    public void selectHit()
    {
       
        hitGameObj.SetActive(false);
        standGameObj.SetActive(false);
        gameAI.GetComponent<GameMaster>().continueRoundPlayer();
    }

    public void selectStand()
    {

        hitGameObj.SetActive(false);
        standGameObj.SetActive(false);
    }

    public void activateBet()
    {
        increaseGameObj.SetActive(true);
        decreaseGameObj.SetActive(true);
    }

    public void makeBet()
    {
        increaseGameObj.SetActive(false);
        decreaseGameObj.SetActive(false);
        makeBetGameObj.SetActive(false);
        betAmountGameObj.SetActive(false);
        confirmGameObj.SetActive(false);
        gameAI.GetComponent<GameMaster>().confirmBet();

    }

    public void increaseBet()
    {
        gameAI.GetComponent<GameMaster>().increaseBet();
    }

    public void decreaseBet()
    {
        gameAI.GetComponent<GameMaster>().decreaseBet();
    }
}

