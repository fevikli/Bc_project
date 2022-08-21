using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // variables
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
    // end of variables


    // components
    public Animator playerAnimator;
    public Stacker stackerScript;
    public Transform transformOfRocket;
    private Rigidbody playerRb;
    // end of components


    // classes
    public GameManager gameManagerScript;
    public RocketMovement rocketMovementScript;
    // end of classes


    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        isGameRunning = gameManagerScript.isGameRunning;

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

        if (isGameRunning)
        {
            playerAnimator.SetBool("isGameRunning", true);


            playerRb.velocity = new Vector3(horizontalInput * horizontalSpeed * Time.fixedDeltaTime, 0f, verticalSpeed * Time.fixedDeltaTime);


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
        else
        {

            playerAnimator.SetBool("isGameRunning", false);
            playerAnimator.SetBool("didGasCansCount", stackerScript.didGasCansCount);

            if (stackerScript.stackSize > 0)
            {

                playerRb.velocity = Vector3.zero;

            }
            else
            {

                if (gameManagerScript.isMissionSucceed)
                {

                    LookTowardRocket(transformOfRocket);

                }
                else
                {
                    playerRb.velocity = Vector3.zero;
                    playerAnimator.SetBool("isMissionSucceed", gameManagerScript.isMissionSucceed);

                }

            }






        }

    }


    public void LookTowardRocket(Transform target)
    {

        distanceVector = target.position - transform.position;
        adjacentSide = Mathf.Abs(distanceVector.x);
        oppositeSide = Mathf.Abs(distanceVector.z);
        alphaAngle = (Mathf.Atan(oppositeSide / adjacentSide)) * Mathf.Rad2Deg;

        if (distanceVector.x < 0 && distanceVector.z < 0) // birinci b�lge
        {

            rotationAngle = 270 - alphaAngle;

        }
        else if (distanceVector.x > 0 && distanceVector.z < 0) // ikinci b�lge
        {

            rotationAngle = -270 + alphaAngle;

        }
        else if (distanceVector.x > 0 && distanceVector.z > 0) // ���nc� b�lge
        {

            rotationAngle = 90 - alphaAngle;

        }
        else if (distanceVector.x < 0 && distanceVector.z > 0) // d�rd�nc� b�lge
        {

            rotationAngle = -90 + alphaAngle;

        }


        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, rotationAngle, transform.rotation.eulerAngles.z));


        if (distanceVector.z > 0.5f)
        {

            playerRb.velocity = distanceVector.normalized * walkingSpeed;
            playerAnimator.SetBool("isMissionSucceed", true);

        }
        else if(!once)
        {

            gameObject.SetActive(false);

            once = true;
            playerRb.velocity = Vector3.zero;
            rocketMovementScript.RocketLaunch();
            
        }


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Gas Can"))
        {

            stackerScript.AddToStack(other.gameObject);
            //Destroy(other.gameObject);
            Debug.Log("Yak�t takviyesi");

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
