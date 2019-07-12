using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed,sprintSpeed, jumpForce;
    Vector3 MoveVelocity;
    float mouseX, mouseY;
    Rigidbody rb;
    public bool grounded, canJump;

   
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    private void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveVelocity = transform.TransformDirection(Movement) * sprintSpeed * Time.deltaTime;

        }
        else
        {
            MoveVelocity = transform.TransformDirection(Movement) * speed * Time.deltaTime;

        }

        rb.MovePosition(transform.position +  MoveVelocity);

        if (Input.GetKeyDown(KeyCode.C) && grounded)
        {

            rb.velocity += new Vector3(0,jumpForce);

            grounded = false;


        }

        
    }



    private void OnCollisionEnter(Collision col)
    {
        if (!col.collider.gameObject.CompareTag("Obstacle"))
        {
            grounded = true;
 
        }
    }

}
