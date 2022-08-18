using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PendulumObstaclesMovement : MonoBehaviour
{


    // variables
    public float period;
    // end of variables


    // Start is called before the first frame update
    void Start()
    {
        
        transform.DOLocalRotate(new Vector3(180, 0, 0), period).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        print("Pendulum");

    }

}
