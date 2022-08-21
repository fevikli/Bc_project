using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RocketMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        //transform.DOMoveY(15, 5, false).SetEase(Ease.InCirc); 

        //transform.DOLocalRotate(new Vector3(180, 0, 0), period).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

    }

    public void RocketLaunch()
    {

        transform.DOMoveY(15, 2, false).SetEase(Ease.InCirc);
        
    }

}
