using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{

    // variables
    public int collectedGasCan;
    public int stackSize;
    public float disappearCounter = 3;
    private float disappearTimer;
    private Vector3 positionOffset;
    private Vector3 spawnPoint;
    private Vector3 spawnRotation = new Vector3(-180, 180, -90);
    private bool isGameRunning;
    // end of variables


    // components
    public ParticleSystem disappearParticle;
    // end of components


    // game objects
    public GameObject gasCanPrefab;
    public GameObject player;
    // end of game objects


    // classes
    public GameManager gameManager;
    // end of classes




    // Start is called before the first frame update
    void Start()
    {

        positionOffset = new Vector3(0.2f, 1.5f, 1);
        spawnPoint = transform.position;
        stackSize = transform.childCount;

        disappearTimer = disappearCounter;

        isGameRunning = gameManager.isGameRunning;

        collectedGasCan = 0;

    }

    private void Update()
    {


    }

    private void LateUpdate()
    {

        isGameRunning = gameManager.isGameRunning;


        if (isGameRunning)
        {

            FollowPlayer();

        }
        else
        {

            CollectedGasCanAmount();

        }

    }


    // This method adds the gas can the player hit to the stack.
    public void AddToStack(GameObject gasCan)
    {

        spawnPoint = transform.position;
        spawnPoint.y += (stackSize * 0.5f);

        gasCan.GetComponent<GasCanBehaviour>().rotationalSpeed = 0;
        gasCan.transform.position = spawnPoint;
        gasCan.transform.rotation = Quaternion.Euler(spawnRotation);
        gasCan.transform.tag = "Untagged";
        gasCan.transform.parent = transform;

        stackSize++;

    }


    private void FollowPlayer()
    {

        Vector3 followingPosition = player.transform.position + positionOffset;

        transform.position = new Vector3(followingPosition.x, positionOffset.y, followingPosition.z);

    }


    // When player collides any obstacle, player lose one gas can.
    public void LoseFuel()
    {

        if (transform.childCount > 0)
        {
            Debug.Log("lose fuel!!");
            Destroy(transform.GetChild(stackSize - 1).gameObject);
            Instantiate(disappearParticle, transform.GetChild(stackSize - 1).position, disappearParticle.transform.rotation);
            stackSize--;

        }

    }

    // Amount of collected gas cans.
    public void CollectedGasCanAmount()
    {

        if (stackSize > 0)
        {

            if (disappearTimer < 0)
            {

                LoseFuel();
                collectedGasCan++;
                disappearTimer = disappearCounter;

            }
            else
            {

                disappearTimer -= Time.deltaTime;

            }

        }

    }

}
