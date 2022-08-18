using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HammerMovement : MonoBehaviour
{

    // variables
    public float period;
    public bool isHammerRightSide;// if "true" hammer is right side, if "false" hammer is left side.
    private float hammerAngle;
    // end of variables


    // Start is called before the first frame update
    void Start()
    {

        if(isHammerRightSide)
        {

            hammerAngle = 60;

        }
        else
        {
            transform.eulerAngles = new Vector3(60, transform.eulerAngles.y, transform.eulerAngles.z); 
            hammerAngle = -60;

        }


        transform.DORotate(new Vector3(hammerAngle, 0, 0), period).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutQuart);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        print("Hammer");

    }

}
