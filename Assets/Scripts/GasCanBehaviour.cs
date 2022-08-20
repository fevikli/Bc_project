using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GasCanBehaviour : MonoBehaviour
{

    // veriables
    public float rotationalSpeed;
    // end of variables

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0f, rotationalSpeed * Time.deltaTime, 0f),Space.World);

    }

}
