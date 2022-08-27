using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStageFinishSensor : MonoBehaviour
{

    // classes
    public GameManager gameManagerScript;
    // end of classes


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            gameManagerScript.finishBonusStage = true;

        }

    }

}
