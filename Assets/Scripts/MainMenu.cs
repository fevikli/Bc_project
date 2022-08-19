using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    // game objects
    public GameObject mainMenuPanel;
    public GameObject creditPanel;
    // end of gameobjects


    public void StartGame()
    {

        SceneManager.LoadScene("GameScene");

    }
    public void OpenCreditPanel()
    {

        mainMenuPanel.gameObject.SetActive(false);
        creditPanel.gameObject.SetActive(true);

    }

    public void closeCreditPanel()
    {

        mainMenuPanel.gameObject.SetActive(true);
        creditPanel.gameObject.SetActive(false);

    }
    public void Quitgame()
    {
        Debug.Log("Quitted");
        Application.Quit();

    }

}
