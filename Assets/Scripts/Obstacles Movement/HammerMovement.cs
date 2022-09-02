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

    public AnimationCurve customEase;

    void Start()
    {

        if (isHammerRightSide)
        {

            hammerAngle = 60;

        }
        else
        {
            transform.eulerAngles = new Vector3(60, transform.eulerAngles.y, transform.eulerAngles.z);
            hammerAngle = -60;

        }

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(new Vector3(hammerAngle, 0, 0), period + 0.5f).SetRelative());
        mySequence.Append(transform.DORotate(new Vector3(-hammerAngle, 0, 0), period).SetRelative().SetEase(customEase));
        mySequence.SetLoops(-1, LoopType.Restart);
        
    }

}
