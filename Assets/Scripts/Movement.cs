using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

public class Movement : MonoBehaviour
{

    public float walkSpeed = 4f;
    public float maxVelocityChange = 10f;
    public float sprintSpeed = 14f;
    public float jumpHeight = 30f;

    public float airControl = 0.5f;
    public Animator animator;

    private Vector2 input;
    private Rigidbody rb;
    private Boolean sprinting;
    private bool jumping;

    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        sprinting = Input.GetButton("Sprint");
        jumping = Input.GetButton("Jump");

    }


    private void OnTriggerStay(Collider other)
    {
        grounded = true;
    }

    void FixedUpdate()
    {

        getAnimations();

        if (grounded)
        {
            if (jumping)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            }
            else if (input.magnitude > 0.5f)
            {
                rb.AddForce(CalculateMovement(sprinting ? sprintSpeed : walkSpeed), ForceMode.VelocityChange);
            }
            else
            {
                var velocity1 = rb.velocity;
                velocity1 = new Vector3(velocity1.x * 0.2f * Time.fixedDeltaTime, velocity1.y, velocity1.z * 0.2f * Time.fixedDeltaTime);
                rb.velocity = velocity1;
            }

        }
        else
        {
            if (input.magnitude > 0.5f)
            {
                rb.AddForce(CalculateMovement(sprinting ? sprintSpeed * airControl : walkSpeed*airControl), ForceMode.VelocityChange);
            }
            else
            {
                var velocity1 = rb.velocity;
                velocity1 = new Vector3(velocity1.x * 0.2f * Time.fixedDeltaTime, velocity1.y, velocity1.z * 0.2f * Time.fixedDeltaTime);
                rb.velocity = velocity1;
            }
        } 

        grounded = false;

    }

    Vector3 CalculateMovement(float _speed)
    {
        Vector3 targetVelocity = new Vector3(input.x, 0, input.y);
        targetVelocity = transform.TransformDirection(targetVelocity);

        targetVelocity *= _speed;

        Vector3 velocity = rb.velocity;

        if(input.magnitude > 0.5f)
        {
            Vector3 velocityChange = targetVelocity;

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);

            velocityChange.y = 0;

            return velocityChange;
        }
        else
        {
            return new Vector3();
        }
    }

    //animate movement
    [PunRPC]
    void getAnimations()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        if (!sprinting)
        {
            if (moveDirection == Vector3.zero)
            {
                animator.SetFloat("x_velocity", 0);
                animator.SetFloat("y_velocity", 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetFloat("x_velocity", 0, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", 5, 0.5f, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetFloat("x_velocity", 0, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", -5, 0.5f, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("x_velocity", 5, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", 0, 0.5f, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetFloat("x_velocity", -5, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", 0, 0.5f, Time.deltaTime);
            }
        }
        if (sprinting)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetFloat("x_velocity", 0, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", 8, 0.5f, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetFloat("x_velocity", 0, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", -8, 0.5f, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("x_velocity", 5, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", 8, 0.5f, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetFloat("x_velocity", -8, 0.5f, Time.deltaTime);
                animator.SetFloat("y_velocity", 0, 0.5f, Time.deltaTime);
            }
        }
    }
    
}
