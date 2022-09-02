using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // variables
    public bool isGameRunning;
    public bool isMissionSucceed;
    public bool finishBonusStage;
    public int fuelAmount;
    private int collectedGasCan;
    private int stackSize;
    public int countOfGasCansAtScene;
    // end of variables


    // game objects
    public GameObject playerStatsPanel;
    // end of game objects


    // classes
    public Stacker stackerScript;
    public UIManager UIManagerScript;
    // end of classes


    void Start()
    {

        isGameRunning = true;
        isMissionSucceed = false;
        finishBonusStage = false;
        countOfGasCansAtScene = GameObject.FindGameObjectsWithTag("Gas Can").Length;

    }

    void Update()
    {

        CheckStateOfMission();

        if(!isGameRunning)
        {

            playerStatsPanel.gameObject.SetActive(true);

        }

    }


    //If player collected gas cans greater than 60% of all gas can  at scene mission is succeed.
    private void CheckStateOfMission()
    {

        stackSize = stackerScript.stackSize;
        collectedGasCan = stackerScript.collectedGasCan;

        if(stackSize > 0)
        {

            fuelAmount = collectedGasCan;

        }


        if (stackSize <= 0 && !isGameRunning)
        {

            if (collectedGasCan >= ((countOfGasCansAtScene * 60) / 100))
            {

                Debug.Log("Görev baþarýlý.");
                isMissionSucceed = true;

            }
            else
            {

                Debug.Log("Görev baþarýsýz.");
                isMissionSucceed = false;
                

            }

        }

    }

}
