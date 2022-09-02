using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AxeMovement : MonoBehaviour
{

    // variables
    public float period;
    // end of variables

    void Start()
    {
       
        transform.parent.DOLocalRotate(new Vector3(0, 100, 0), period).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

    }

}
