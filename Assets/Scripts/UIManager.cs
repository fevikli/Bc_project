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
    public int score;
    private int scoreMultiplier = 5;
    // end of variabless


    // components
    public Slider fuelSlider;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelStatsScoreText;
    // end of componenets


    // classes
    public Stacker stackerScript;
    public GameManager gameManagerScript;
    public PlayerController playerControllerScript;
    // end of classes


    // game objects
    public GameObject missionFailedPanel;
    public GameObject missionSucceedPanel;
    // end of game objects


    // Start is called before the first frame update
    void Start()
    {

        score = 0;

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
            float rocketAltitude = playerControllerScript.transform.position.y; 

            if(rocketAltitude < 160)
            {

                levelStatsScoreText.text = "YOU REACHED TO THERMOSPHERE \n\n" + "YOUR SCORE IS " + score;

            }
            else if(rocketAltitude < 200)
            {

                levelStatsScoreText.text = "YOU REACHED TO EXOSPHERE \n\n" + "YOUR SCORE IS " + score;

            }

            missionSucceedPanel.gameObject.SetActive(true);

        }

    }


    // This method manages to fuel bar.
    public void fuelBarController(int fuelAmount)
    {

        fuelSlider.value = Mathf.Lerp(fuelSlider.value, fuelAmount, lerpValue);

        AddScore();
    }


    public void AddScore()
    {
        if (stackerScript.stackSize > 0)
        {

            score = gameManagerScript.fuelAmount * scoreMultiplier;

            scoreText.text = "Score : " + score;

        }

    }

    public void MultiplScore(int value)
    {

        score *= value;

        scoreText.text = "Score : " + score;

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
