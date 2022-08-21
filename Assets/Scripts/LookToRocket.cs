using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToRocket : MonoBehaviour
{
    // variables
    public float oppositeSide;
    public float adjacentSide;
    public float alphaAngle;
    public float rotationAngle;
    public Vector3 distanceVector;
    // end of variables



    // components
    public Transform targetTransform;
    // end of componeents


    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        LookTowardRocket(targetTransform);

    }

    public void LookTowardRocket(Transform target)
    {

        distanceVector = target.position -transform.position;
        adjacentSide = Mathf.Abs(distanceVector.x);
        oppositeSide = Mathf.Abs(distanceVector.z);
        alphaAngle = (Mathf.Atan(oppositeSide / adjacentSide)) * Mathf.Rad2Deg;

        if (distanceVector.x < 0 && distanceVector.z < 0) // birinci bölge
        {

            rotationAngle = 270 - alphaAngle;

        }
        else if (distanceVector.x > 0 && distanceVector.z < 0) // ikinci bölge
        {

            rotationAngle = -270 + alphaAngle;

        }
        else if (distanceVector.x > 0 && distanceVector.z > 0) // üçüncü bölge
        {

            rotationAngle = 90 - alphaAngle;

        }
        else if (distanceVector.x < 0 && distanceVector.z > 0) // dördüncü bölge
        {

            rotationAngle = -90 + alphaAngle;

        }


        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, rotationAngle, transform.rotation.eulerAngles.z));

    }

}
