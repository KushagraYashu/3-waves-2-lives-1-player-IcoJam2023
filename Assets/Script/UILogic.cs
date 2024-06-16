using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{

    public SoundManager soundManager;

    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject instructionPanel;
    public GameObject deadScreen;


    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").gameObject.GetComponent<SoundManager>();
    }

    public void LoadGame()
    {
        soundManager.PlayBlip();
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        deadScreen.SetActive(false);
        soundManager.PlayBlip();
        SceneManager.LoadScene(1);
    }
    
    public void MainMenu()
    {
        soundManager.PlayBlip();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        soundManager.PlayBlip();
        Application.Quit();
    }

    public void LoadCredits()
    {
        soundManager.PlayBlip();
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void LoadInstructions()
    {
        soundManager.PlayBlip();
        mainMenuPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void GoBackFromCredits()
    {
        soundManager.PlayBlip();
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void GoBackFromIns()
    {
        soundManager.PlayBlip();
        instructionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

}
