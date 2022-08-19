using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{

    // variables
    public int stackSize;
    private Vector3 positionOffset;
    private Vector3 spawnPoint;
    private Vector3 spawnRotation = new Vector3(-180, 180, -90);
    // end of variables


    // game objects
    public GameObject gasCanPrefab;
    public GameObject player;
    // end of game objects




    // Start is called before the first frame update
    void Start()
    {

        positionOffset = new Vector3(0.2f, 1.5f, 1);
        spawnPoint = transform.position;
        stackSize = 0;

    }

    private void LateUpdate()
    {

        FollowPlayer();

    }

    public void AddToStack()
    {

        spawnPoint = transform.position;
        spawnPoint.y += (stackSize * 0.5f);
        gasCanPrefab.GetComponent<GasCanBehaviour>().rotationalSpeed = 0;
        GameObject newGasCan =  Instantiate(gasCanPrefab, spawnPoint, Quaternion.Euler(spawnRotation));
        newGasCan.transform.tag = "Untagged";
        newGasCan.transform.parent = transform;
        stackSize++;

    }

    private void FollowPlayer()
    {

        Vector3 followingPosition = player.transform.position + positionOffset;

        transform.position = new Vector3(followingPosition.x, positionOffset.y, followingPosition.z);

    }


    // When player collide any obstacle, player lose one gas can
    public void LoseFuel()
    {

        if (transform.childCount > 0)
        {
            Debug.Log("lose fuel!!");
            Destroy(transform.GetChild(stackSize-1).gameObject);
            stackSize--;

        }

    }

}
