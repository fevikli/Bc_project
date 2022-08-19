using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    // end of classes



    // Start is called before the first frame update
    void Start()
    {

        fuelAmount = 0;
        fuelSlider.value = 0;
        //fuelSlider.maxValue = 10;
        fuelSlider.minValue = 0;


    }

    // Update is called once per frame
    void Update()
    {

        fuelAmount = stackerScript.stackSize;
        fuelSlider.value = Mathf.Lerp(fuelSlider.value, fuelAmount, lerpValue);

    }
}
