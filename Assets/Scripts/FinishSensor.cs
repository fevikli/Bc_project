using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSensor : MonoBehaviour
{

    // variables
    public bool isGameRunning;
    // end of variables


    // classes
    public GameManager gameManagerScript;
    // end of classes


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            gameManagerScript.isGameRunning = false;

        }

    }

}
