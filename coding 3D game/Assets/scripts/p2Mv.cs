using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class p2Mv : MonoBehaviour
{
    public static Action<string> PlayerCollectsCoin = delegate { };
    private Rigidbody rb;

    private float moveSpeed;
    private float dirX, dirY, dirZ; // Add dirZ for z-axis movement
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        moveSpeed = 7f;
        jumpForce = 6f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (name == "player2" && Input.anyKey)
        {
            if (Input.GetKey(KeyCode.I))
            {
                dirY = moveSpeed;
            }

            if (Input.GetKey(KeyCode.K))
            {
                dirY = -moveSpeed;
            }

            if (Input.GetKey(KeyCode.J))
            {
                dirX = -moveSpeed;
            }

            if (Input.GetKey(KeyCode.L))
            {
                dirX = moveSpeed;
            }
            
            // Add z-axis movement controls
            if (Input.GetKey(KeyCode.N))
            {
                dirZ = -moveSpeed;
            }

            if (Input.GetKey(KeyCode.M))
            {
                dirZ = moveSpeed;
            }
        }
        else if (name == "player2" && !Input.anyKey)
        {
            dirX = 0f;
            dirY = 0f;
            dirZ = 0f; // Reset z-axis movement when no key is pressed
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, dirY, dirZ); // Use Vector3 for movement
        if (moveHorizontal > 0.1f || moveHorizontal < 0.1f)
        {
            rb.AddForce(new Vector3(moveHorizontal * moveSpeed, 0f, 0f), ForceMode.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb.AddForce(new Vector3(0f, moveVertical * jumpForce, 0f), ForceMode.Impulse);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            PlayerCollectsCoin(name);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Floor")
        {
            isJumping = true;
        }
    }
}
