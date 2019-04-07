using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Button playButton;
    public Button menuButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(selectPlay);
        menuButton.onClick.AddListener(selectMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void selectPlay()
    {
        SceneManager.LoadScene("BlackJackGame");
    }

    void selectMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
