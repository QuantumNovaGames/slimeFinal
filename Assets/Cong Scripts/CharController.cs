using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;



    private CharacterController controller;
    private Animator anim;


    public GameObject bigSlime;
    public GameObject blue_crystal; 
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        bigSlime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }

        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))//0, 0, 0
        {
            Walk();

        }else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();

        }else if(moveDirection == Vector3.zero)
        {
            Idle();
        }

        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }
        }

        moveDirection.Normalize();
        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    /***********************Animations ******************************/

    private void Idle(){
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1.0f, 0.1f, Time.deltaTime);
    }

    private void Attack(){
        anim.SetTrigger("Attack");
    }

    private void Jump(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
