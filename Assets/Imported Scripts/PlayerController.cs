using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed; //
    public float jumpTime; //max amount of time character can jump

    //private CharacterController characterController;
    private float ySpeed;//
    //for obstacles to avoid jump glitches
    private float originalStepOffset;
    private bool isJumping; //
    private float jumpTimer; //tracks how long character jumping
    public GameObject bigSlime;
    public GameObject blue_crystal; 
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset =  characterController.stepOffset;
        bigSlime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Imported
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = transform.TransformDirection(movementDirection);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y*Time.deltaTime; //


        //prevents user from jumping if already in midair
        if(characterController.isGrounded){
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            isJumping = false; //
            jumpTimer = 0f;
            if(Input.GetButtonDown("Jump")){
                isJumping = true;
                ySpeed = jumpSpeed;
            }
        } else {
            characterController.stepOffset = 0;
            if (isJumping && Input.GetButton("Jump") && jumpTimer < jumpTime)
            {
                ySpeed = jumpSpeed;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        

        Vector3 velocity = movementDirection * magnitude; //
        velocity.y = ySpeed; //
        characterController.Move(velocity * Time.deltaTime);

        //if(movementDirection != Vector3.zero) {
            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}

         if(Input.GetKeyDown(KeyCode.S))
         {
            ActivateChildObject();

         }
    }

    private void ActivateChildObject()
    {
        // Activate the child object
        bigSlime.SetActive(true);

        // ability lasts for 5 seconds
        Invoke("DeactivateChildObject", 5.0f);
    }

    private void DeactivateChildObject()
    {
        // Deactivate the child object
        bigSlime.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bigSlime.activeSelf && other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
        }

        if (!bigSlime.activeSelf && other.gameObject.tag == "enemy")
        {
        transform.localScale *= 0.8f;
        }    

         if (other.gameObject.CompareTag("Button") && transform.localScale == new Vector3(1.5f, 1.5f, 1.5f))
        {
        // Spawn a diamond at the button's position
        Instantiate(blue_crystal, other.transform.position, Quaternion.identity);
        }   
    }



   
}
