using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // variables
    public float cameraLerpValue = 1f;
    public int positionIndex;
    private Vector3 cameraOffSet0;
    private Vector3 cameraOffSet1;
    private Vector3 cameraPosition;
    private Vector3 followingPosition;
    private float xPos;
    // end of variables


    // game objects
    public GameObject player;
    // end of game objects


    void Start()
    {

        cameraOffSet0 = new Vector3(0, 7.4f, -12);
        cameraOffSet1 = new Vector3(0, 16, -40);

        xPos = transform.position.x;

    }

    private void LateUpdate()
    {

        FollowPlayer(positionIndex);

    }

    private void FollowPlayer(int _positionIndex)
    {

        if (_positionIndex == 0)
        {

            followingPosition = player.transform.position + cameraOffSet0;
            cameraPosition = new Vector3(xPos, followingPosition.y, followingPosition.z);

        }
        else if (_positionIndex == 1) // This condition use for camera view of bonus stage.
        {

            followingPosition = player.transform.position + cameraOffSet1;
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));

            cameraPosition = new Vector3(xPos, followingPosition.y, followingPosition.z);

        }

        transform.position = cameraPosition;

    }

}
