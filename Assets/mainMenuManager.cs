using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button rulesButton;
    public GameObject playGameObj;
    public GameObject rulesGameObj;
    // Start is called before the first frame update
    void Start()
    {
        playGameObj.SetActive(true);
        rulesGameObj.SetActive(true);
        playButton.onClick.AddListener(selectPlay);
        rulesButton.onClick.AddListener(selectRules);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectPlay()
    {
        SceneManager.LoadScene("BlackJackGame");
        print("button Pressed");
    }

    public void selectRules()
    {

    }
}
