using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingObstacleMovement : MonoBehaviour
{

    // variables
    public float period;
    // end of variables


    void Start()
    {

        transform.DOLocalRotate(new Vector3(0, 0, 360), period).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);

    }

}
