using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    // variables
    private int fuelAmount; 
    // end of variabless


    // components
    public TextMeshProUGUI fuelAmountText;
    // end of componenets


    // classes
    public Stacker stackerScript;
    // end of classes



    // Start is called before the first frame update
    void Start()
    {

        fuelAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {

        fuelAmount = stackerScript.stackSize;
        fuelAmountText.text = "Score :" + fuelAmount;

    }
}
