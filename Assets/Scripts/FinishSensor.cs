using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSensor : MonoBehaviour
{

    // variables
    public bool isGameRunning;
    // end of variables




    // Start is called before the first frame update
    void Start()
    {

        isGameRunning = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        isGameRunning = false;

    }

}
