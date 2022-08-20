using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // variables
    public bool isGameRunning;
    public bool isMissionSucceed;
    private int stackSize;
    private int collectedGasCan;
    private int countOfGasCansAtScene;
    // end of variables


    // game objects
    public GameObject playerStatsPanel;
    // end of game objects


    // classes
    public Stacker stackerScript;
    // end of classes



    // Start is called before the first frame update
    void Start()
    {

        isGameRunning = true;
        countOfGasCansAtScene = GameObject.FindGameObjectsWithTag("Gas Can").Length;

    }

    // Update is called once per frame
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
