using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerController : MonoBehaviour
{

    // variables
    public CinemachineVirtualCamera cam2;
    public float oppositeSide;
    public float adjacentSide;
    public float alphaAngle;
    public float rotationAngle;
    public Vector3 distanceVector;
    public float walkingSpeed;
    public float horizontalSpeed;
    public float verticalSpeed;
    private float horizontalInput;
    private float xAxisBound = 4;
    private bool isGameRunning;
    private bool once;
    private bool startBonusStage;
    // end of variables


    // components
    public Animator playerAnimator;
    public Stacker stackerScript;
    public Transform transformOfRocket;
    private Rigidbody playerRb;
    // end of components


    // classes
    public GameManager gameManagerScript;
    // end of classes


    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        isGameRunning = gameManagerScript.isGameRunning;
        startBonusStage = gameManagerScript.finishBonusStage;

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate()
    {

        PlayerMovement();

    }


    private void PlayerMovement()
    {

        isGameRunning = gameManagerScript.isGameRunning;
        startBonusStage = gameManagerScript.finishBonusStage;

        if (isGameRunning)
        {

           setPlayerMoventAxises(1, 0, 1);

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
                // If mission is succeed
                if (gameManagerScript.isMissionSucceed)
                {

                    LookTowardRocket(transformOfRocket);
                    

                    // If player reach to the rocket, bonus stage will activated and  player movement axises and camera position will change.
                    if(startBonusStage && !gameManagerScript.finishBonusStage)
                    {
                        cam2.Priority = 11;
                        xAxisBound = 10;
                        setPlayerMoventAxises(1, 1, 0);
                        
                    }
                    else if(startBonusStage && gameManagerScript.finishBonusStage)
                    {

                        playerRb.velocity = Vector3.zero;

                    }
                    
                }
                else // If is not.
                {
                    playerRb.velocity = Vector3.zero;
                    playerAnimator.SetBool("isMissionSucceed", gameManagerScript.isMissionSucceed);

                }

            }

        }

    }

    // It is test method 
    private void setPlayerMoventAxises( float x, float y, float z)
    {

        playerAnimator.SetBool("isGameRunning", true);

        playerRb.velocity = new Vector3(horizontalInput * horizontalSpeed * Time.fixedDeltaTime * x , verticalSpeed * Time.fixedDeltaTime * y, verticalSpeed * Time.fixedDeltaTime * z);

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

    // It is orignal PlayerMovement method
    //private void PlayerMovement()
    //{

    //    isGameRunning = gameManagerScript.isGameRunning;

    //    if (isGameRunning && !bonusStage)
    //    {
    //        playerAnimator.SetBool("isGameRunning", true);


    //        playerRb.velocity = new Vector3(horizontalInput * horizontalSpeed * Time.fixedDeltaTime, 0f, verticalSpeed * Time.fixedDeltaTime);


    //        // Keep player on the plane
    //        if (transform.position.x >= xAxisBound)
    //        {
    //            transform.position = new Vector3(xAxisBound, transform.position.y, transform.position.z);
    //        }

    //        if (transform.position.x <= -xAxisBound)
    //        {
    //            transform.position = new Vector3(-xAxisBound, transform.position.y, transform.position.z);
    //        }

    //    }
    //    else
    //    {

    //        playerAnimator.SetBool("isGameRunning", false);
    //        playerAnimator.SetBool("didGasCansCount", stackerScript.didGasCansCount);

    //        if (stackerScript.stackSize > 0)
    //        {

    //            playerRb.velocity = Vector3.zero;

    //        }
    //        else
    //        {

    //            if (gameManagerScript.isMissionSucceed)
    //            {

    //                LookTowardRocket(transformOfRocket);
    //                bonusStage = true;

    //            }
    //            else
    //            {
    //                playerRb.velocity = Vector3.zero;
    //                playerAnimator.SetBool("isMissionSucceed", gameManagerScript.isMissionSucceed);

    //            }

    //        }

    //    }

    //} // 


    public void LookTowardRocket(Transform target)
    {

        distanceVector = target.position - transform.position;
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


        if (distanceVector.z > 0.5f)
        {

            playerRb.velocity = distanceVector.normalized * walkingSpeed;
            playerAnimator.SetBool("isMissionSucceed", true);

        }
        // I try to add bonus level end of the level, so i remove this code
        //else if (!once)
        //{

        //    gameObject.SetActive(false);

        //    once = true;
        //    playerRb.velocity = Vector3.zero;
        //    rocketMovementScript.RocketLaunch();

        //}
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
            Debug.Log("Yakýt takviyesi");

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
