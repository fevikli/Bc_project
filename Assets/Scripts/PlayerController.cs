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
    // end of variables


    // components
    private Rigidbody playerRb;
    // end of components

    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();

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
}
