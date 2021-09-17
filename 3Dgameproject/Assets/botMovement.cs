using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private bool IsGrounded;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    private Vector3 movedir;
    private Vector3 velocity;

    private CharacterController controller;

    public Animator animator;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }
    private void Move()
    {
        IsGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        movedir = new Vector3(0, 0, moveZ);
        movedir = transform.TransformDirection(movedir);

        if (movedir != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();// need to find way to set condition 
        }
        else if (movedir != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();// need to find way to set condition else only 1 speed
        }
       
        movedir *= moveSpeed;

        controller.Move(movedir * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        animator.SetFloat("speed", 0f);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        animator.SetFloat("speed", 1f);
    }
}
