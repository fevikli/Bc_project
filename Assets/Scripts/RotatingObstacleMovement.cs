using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatingObstacleMovement : MonoBehaviour
{

    // variables
    public float period;
    // end of variables

    // Start is called before the first frame update
    void Start()
    {

        transform.DOLocalRotate(new Vector3(0, 0, 360), period).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        print("Dönen engel");

    }

}
