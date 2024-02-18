using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerOne : MonoBehaviour
{
    public float speed = 10.0f; // You can adjust the speed to your liking
    public float jumpForce = 6f; // You can adjust the jump force to your liking
    public float rotationSpeed = 720f;

    bool isOnGround;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        isOnGround = true;
    }  

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if the "E or Q" key is pressed
        if (isOnGround && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q)))
        {
            // Apply a force upwards
            isOnGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

        void OnCollisionEnter(Collision collision)
        {   
            // Check if the player has collided with the ground
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        }
}
