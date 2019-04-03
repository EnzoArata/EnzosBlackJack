using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button rulesButton;
    public Button homeButton;
    public GameObject playGameObj;
    public GameObject rulesGameObj;
    public GameObject homeGameObj;
    public GameObject titleObj;
    public GameObject descriptionObj;

    // Start is called before the first frame update
    void Start()
    {
        homeGameObj.SetActive(false);
        descriptionObj.SetActive(false);
        playButton.onClick.AddListener(selectPlay);
        rulesButton.onClick.AddListener(selectRules);
        homeButton.onClick.AddListener(selectHome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectPlay()
    {
        SceneManager.LoadScene("BlackJackGame");
        
    }

    public void selectRules()
    {
        playGameObj.SetActive(false);
        rulesGameObj.SetActive(false);
        homeGameObj.SetActive(true);
        titleObj.SetActive(false);
        descriptionObj.SetActive(true);
    }

    public void selectHome()
    {
        playGameObj.SetActive(true);
        rulesGameObj.SetActive(true);
        homeGameObj.SetActive(false);
        titleObj.SetActive(true);
        descriptionObj.SetActive(false);
    }
}
