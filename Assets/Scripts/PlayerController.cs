using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerController : MonoBehaviour
{

    // variables
    public CinemachineVirtualCamera cam2;
    [SerializeField] float oppositeSide;
    [SerializeField] float adjacentSide;
    [SerializeField] float alphaAngle;
    [SerializeField] float rotationAngle;
    [SerializeField] Vector3 distanceVector;
    [SerializeField] float walkingSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] float rocketSpeed;
    [SerializeField] int flightFactor = 10;
    [SerializeField] float lerpMultiplier;
    [SerializeField] float xAxisBound = 4;
    private bool rocketExplosion;
    private int i = 1;
    private float horizontalInput;
    private bool isGameRunning;
    private bool startBonusStage;
    private float mouseFirstPos;
    private float preMousePos;
    private float centerPos;
    // end of variables


    // components
    public ParticleSystem rocketExplosionParticle;
    public Animator playerAnimator;
    public Transform transformOfRocket;
    private Rigidbody playerRb;
    // end of components


    // classes
    public GameManager gameManagerScript;
    public Stacker stackerScript;
    public UIManager UIManagerScript;
    // end of classes


    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        isGameRunning = gameManagerScript.isGameRunning;
        startBonusStage = gameManagerScript.finishBonusStage;

    }


    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        MouseAndTouchInput(); 
         
    }


    private void FixedUpdate()
    {

        PlayerMovement();

    }


    // This method manages movement of player.
    private void PlayerMovement()
    {

        isGameRunning = gameManagerScript.isGameRunning;
        startBonusStage = gameManagerScript.finishBonusStage;

        if (isGameRunning)
        {

            setPlayerMoventAxises(1, 0, 1); // Set movement for normal gameplay

        }
        else
        {

            playerAnimator.SetBool("isGameRunning", false);
            playerAnimator.SetBool("didGasCansCount", stackerScript.didGasCansCount);


            // If the counting process is not finished
            if (stackerScript.stackSize > 0)
            {

                playerRb.velocity = Vector3.zero;

            }
            else  // If is not.
            {
                int flightRange = stackerScript.collectedGasCan * flightFactor;


                // If mission is succeed
                if (gameManagerScript.isMissionSucceed)
                {

                    LookTowardRocket(transformOfRocket);

                    bonusStageMovement(flightRange);

                }
                else // If is not.
                {
                    playerRb.velocity = Vector3.zero;
                    playerAnimator.SetBool("isMissionSucceed", gameManagerScript.isMissionSucceed);

                }

            }

        }

    }

    // This method controls to inputs of touch.
    private void MouseAndTouchInput()
    {

        if (Input.GetMouseButton(0))
        {

            if (preMousePos != Input.mousePosition.x)
            {

                if (preMousePos > Input.mousePosition.x)
                {
                    // mouse moving left
                    centerPos = preMousePos;

                }
                else if (preMousePos < Input.mousePosition.x)
                {
                    // mouse moving right
                    centerPos = preMousePos;

                }

                if (centerPos < Input.mousePosition.x)
                {

                    horizontalInput = 1;

                }
                else if (centerPos > Input.mousePosition.x)
                {

                    horizontalInput = -1;

                }
                preMousePos = Input.mousePosition.x;
            }
            else
            {

                horizontalInput = 0;

            }

        }
    }

    private void bonusStageMovement(int m_flightRange)
    {

        // If player reach to the rocket, bonus stage will activated and  player movement axises and camera position will change.
        if (startBonusStage && !gameManagerScript.finishBonusStage)
        {

            cam2.Priority = 11;
            xAxisBound = 10;

            if (transform.position.y < m_flightRange) // If we have gas to flight
            {

                setPlayerMoventAxises(0, 1, 0); // Set movement for bonus stage


                if (transform.position.y > (flightFactor * i))
                {

                    gameManagerScript.fuelAmount--;
                    i++;

                }

            }
            else // If gas run out
            {

                gameManagerScript.finishBonusStage = true;

                if (!rocketExplosion)
                {
                    rocketExplosion = true;

                    ParticleSystem rocketExp = Instantiate(rocketExplosionParticle, transform.position, rocketExplosionParticle.transform.rotation);
                    Destroy(rocketExp.gameObject, 4);
                }

                transform.gameObject.SetActive(false); // If Run out of gas, rocket and player will disappear

            }

        }
        else if (startBonusStage && gameManagerScript.finishBonusStage)
        {

            playerRb.velocity = Vector3.zero;

        }

    }


    // We can set movement axises of player with this method.
    private void setPlayerMoventAxises(float x, float y, float z)
    {

        playerAnimator.SetBool("isGameRunning", true);

        playerRb.velocity = new Vector3(horizontalInput * horizontalSpeed * Time.fixedDeltaTime * x, rocketSpeed * Time.fixedDeltaTime * y, verticalSpeed * Time.fixedDeltaTime * z);


        // Keep player on the plane
        if (transform.position.x >= xAxisBound)
        {
            transform.position = new Vector3(xAxisBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= -xAxisBound)
        {
            transform.position = new Vector3(-xAxisBound, transform.position.y, transform.position.z);
        }

    }


    //This method able to player look to rocket when current level finished.
    public void LookTowardRocket(Transform target)
    {

        distanceVector = target.position - transform.position;
        adjacentSide = Mathf.Abs(distanceVector.x);
        oppositeSide = Mathf.Abs(distanceVector.z);
        alphaAngle = (Mathf.Atan(oppositeSide / adjacentSide)) * Mathf.Rad2Deg;

        if (distanceVector.x < 0 && distanceVector.z < 0) // quadrant 1
        {

            rotationAngle = 270 - alphaAngle;

        }
        else if (distanceVector.x > 0 && distanceVector.z < 0) // quadrant 2
        {

            rotationAngle = -270 + alphaAngle;

        }
        else if (distanceVector.x > 0 && distanceVector.z > 0) // quadrant 3
        {

            rotationAngle = 90 - alphaAngle;

        }
        else if (distanceVector.x < 0 && distanceVector.z > 0) // quadrant 4
        {

            rotationAngle = -90 + alphaAngle;

        }


        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, rotationAngle, transform.rotation.eulerAngles.z));


        if (distanceVector.z > 0.5f)
        {

            playerRb.velocity = distanceVector.normalized * walkingSpeed;
            playerAnimator.SetBool("isMissionSucceed", true);

        }
        else
        {

            transformOfRocket.parent = transform; // I set the rocket as a child of player, because it should move with player.
            startBonusStage = true;
        }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Gas Can"))
        {

            stackerScript.AddToStack(other.gameObject);
            Debug.Log("Yak?t takviyesi");

        }

        if (other.gameObject.CompareTag("LayerOfAtmosphere"))
        {

            UIManagerScript.MultiplScore(2);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("collided with obstacle");
            stackerScript.LoseFuel();

        }

    }

}
