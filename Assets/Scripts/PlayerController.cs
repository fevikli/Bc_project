using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // variables
    public float horizontalSpeed;
    public float verticalSpeed;
    private float horizontalInput;
    private float xAxisBound = 4;
    private bool isGameRunning;
    // end of variables


    // components
    public Animator playerAnimator;
    public Stacker stackerScript;
    private Rigidbody playerRb;
    // end of components


    // classes
    public FinishSensor finishSensor;
    // end of classes


    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        isGameRunning = finishSensor.isGameRunning;

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

        isGameRunning = finishSensor.isGameRunning;

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

            playerRb.velocity = Vector3.zero;
            playerAnimator.SetBool("isGameRunning", false);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Gas Can"))
        {

            Destroy(other.gameObject);
            Debug.Log("Yakýt takviyesið");

            stackerScript.AddToStack();

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
