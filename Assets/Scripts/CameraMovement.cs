using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // variables
    private Vector3 cameraPos;
    private float xPos;
    private Vector3 followingDistance;
    // end of variables


    // game objects
    public GameObject player;
    // end of game objects


    // Start is called before the first frame update
    void Start()
    {

        cameraPos = transform.position;
        xPos = transform.position.x;
        followingDistance = player.transform.position - cameraPos;

    }

    // Update is called once per frame
    private void LateUpdate()
    {

        FollowPlayer();

    }

    private void FollowPlayer()
    {

        Vector3 followingPosition = player.transform.position - followingDistance;        

        transform.position = new Vector3(xPos, followingPosition.y, followingPosition.z);

    }
}
