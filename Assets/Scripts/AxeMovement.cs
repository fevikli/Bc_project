using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AxeMovement : MonoBehaviour
{

    // variables

    // end of variables

    // Start is called before the first frame update
    void Start()
    {
       
        transform.parent.DOLocalRotate(new Vector3(0, 100, 0), 1).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        //transform.DOMoveX(10, 1).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);


    }

    // Update is called once per frame
    void Update()
    {




    }

    private void OnTriggerEnter(Collider other)
    {

        print("börek");

    }




}
