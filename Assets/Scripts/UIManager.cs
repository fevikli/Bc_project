using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    // variables
    public float lerpValue = 0.5f;
    private int fuelAmount; 
    // end of variabless


    // components
    public Slider fuelSlider;
    // end of componenets


    // classes
    public Stacker stackerScript;
    public GameManager gameManagerScript;
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


    }

    // Update is called once per frame
    void Update()
    {

        fuelAmount = stackerScript.collectedGasCan;
        fuelSlider.value = Mathf.Lerp(fuelSlider.value, fuelAmount, lerpValue);

        if(!gameManagerScript.isMissionSucceed && stackerScript.didGasCansCount)
        {

            missionFailedPanel.gameObject.SetActive(true);

        }

        if (gameManagerScript.isMissionSucceed && stackerScript.didGasCansCount)
        {

            missionSucceedPanel.gameObject.SetActive(true);

        }

    }

    public void StartGame()
    {

        SceneManager.LoadScene("GameScene");

    }

    public void Quitgame()
    {
        Debug.Log("Quitted");
        Application.Quit();

    }

}
