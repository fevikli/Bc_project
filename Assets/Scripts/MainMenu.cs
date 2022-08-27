using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenu : MonoBehaviour
{

    // game objects
    public GameObject mainMenuPanel;
    public GameObject creditPanel;
    public GameObject levelsPanel;
    // end of gameobjects


    public void StartGame() // 1.level
    {

        SceneManager.LoadScene("GameScene");

    }

    public void SatartLevel2()
    {

        SceneManager.LoadScene("Level2");

    }

    public void SatartLevel3()
    {

        SceneManager.LoadScene("Level3");

    }

    public void OpenLevelsPanel()
    {

        mainMenuPanel.gameObject.SetActive(false);
        levelsPanel.gameObject.SetActive(true);

    }

    public void CloseLevelsPanel()
    {

        mainMenuPanel.gameObject.SetActive(true);
        levelsPanel.gameObject.SetActive(false);

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
#if UNITY_EDITOR
        Debug.Log("Quit game");
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
