using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    private float movementX;
    private float movementY;

    //Initally set to zero as on Unity app, you can set the speed, so more to update later then.
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float smoothing = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    //Used for player input movement
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }


    // Update for physics consistencity calculations
    private void FixedUpdate()
    {

        // need to fix this more, but this is meant to check if the player is moving or not.
        if (movementX != 0 || movementY != 0)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime * smoothing);

        }




    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
