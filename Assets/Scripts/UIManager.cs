using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{

    // variables
    public float lerpValue = 0.5f;
    public int fuelAmount;
    // end of variabless


    // components
    public Slider fuelSlider;
    // end of componenets


    // classes
    public Stacker stackerScript;
    public GameManager gameManagerScript;
    public PlayerController playerControllerScript;
    // end of classes


    // gama objects
    public GameObject missionFailedPanel;
    public GameObject missionSucceedPanel;
    // end of game objects


    // Start is called before the first frame update
    void Start()
    {

        fuelAmount = 0;
        fuelSlider.value = 0;
        fuelSlider.minValue = 0;
        fuelSlider.maxValue = GameObject.FindGameObjectsWithTag("Gas Can").Length;

    }

    // Update is called once per frame
    void Update()
    {


        fuelBarController(gameManagerScript.fuelAmount);

        if (!gameManagerScript.isMissionSucceed && stackerScript.didGasCansCount)
        {

            missionFailedPanel.gameObject.SetActive(true);

        }

        if (gameManagerScript.isMissionSucceed && stackerScript.didGasCansCount && gameManagerScript.finishBonusStage)
        {

            missionSucceedPanel.gameObject.SetActive(true);

        }

    }

    public void fuelBarController(int fuelAmount)
    {

        fuelSlider.value = Mathf.Lerp(fuelSlider.value, fuelAmount, lerpValue);

    }

    public void StartGame()
    {

        SceneManager.LoadScene("GameScene");

    }


    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void BackToMainMenu()
    {

        SceneManager.LoadScene("MainMenu");

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
