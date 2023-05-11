using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  private CharacterController characterController;
  private Animator anim;

  private float moveSpeed;
  //[SerializeField] private float walkSpeed;
  [SerializeField] private float runSpeed;
  public int hp = 300;

  public float speed;
  private float rotationSpeed;
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

  public float damageDelay = 1.0f;
  public float m_DamageCooldown = 0;

  public Transform bulletSpawnPoint;
  public GameObject bulletPrefab;

  public float bulletSpeed = 5.0f;


  // Start is called before the first frame update
  void Start()
  {
    characterController = GetComponent<CharacterController>();
    anim = GetComponentInChildren<Animator>();
    originalStepOffset = characterController.stepOffset;
    bigSlime.SetActive(false);

    anim.SetInteger("DamageType", 2);
  }

  // Update is called once per frame
  void Update()
  {
    //checking if user is below certain size

    if (hp <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      return;
    }

    if(m_DamageCooldown > 0)
      m_DamageCooldown -= Time.deltaTime;
    //

    //allows user to attack with Q keypress
    if (Input.GetKeyDown(KeyCode.E) && bigSlime.activeSelf)
    {
      Attack();
    }
    //
    KillPlayerFall();//restart lvl if player is below 0 y axis

    anim.SetInteger("DamageType", 2);

    if (anim.GetBool("Damage"))
    {
    }
    else
    {
      Move();//put everything in Move to cleanup Update and manage recoil
    }


  }

  private void Move()
  {
    if (Input.GetKeyDown(KeyCode.Mouse1))
    {
      Attack();
    }
    // Imported
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
    movementDirection = transform.TransformDirection(movementDirection);

    if (movementDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))//0, 0, 0
    {
      Walk();

    }
    else if (movementDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
    {
      Run();

    }
    else if (movementDirection == Vector3.zero)
    {
      Idle();
    }

    float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
    movementDirection.Normalize();

    ySpeed += Physics.gravity.y * Time.deltaTime; //


    //prevents user from jumping if already in midair
    if (characterController.isGrounded)
    {
      characterController.stepOffset = originalStepOffset;
      ySpeed = -0.5f;
      isJumping = false; //
      jumpTimer = 0f;
      if (Input.GetButtonDown("Jump"))
      {

        isJumping = true;
        ySpeed = jumpSpeed;
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
      }
    }
    else
    {
      characterController.stepOffset = 0;
      if (isJumping && Input.GetButton("Jump") && jumpTimer < jumpTime)
      {
        ySpeed = jumpSpeed;
        jumpTimer += Time.deltaTime;
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
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

    if (Input.GetKeyDown(KeyCode.B))
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
    transform.localScale *= 0.8f;
    hp -= 100;
    if (hp <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      return;
    }

  }

  /*private void OnTriggerEnter(Collider other)
  {
    if (bigSlime.activeSelf && other.gameObject.tag == "enemy")
    {
      Destroy(other.gameObject);
    }

    //if slime hits enemy in normal form, they will shrink
    if (!bigSlime.activeSelf && other.gameObject.tag == "enemy")
    {
      transform.localScale *= 0.8f;
      hp -= 100;

    }
  }*/


  /***********************Animations ******************************/

  private void Idle()
  {
    anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
  }

  private void Walk()
  {
    anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
  }

  private void Run()
  {
    speed = runSpeed;
    anim.SetFloat("Speed", 1.0f, 0.1f, Time.deltaTime);
  }

  private void Attack()
  {

    if(hp < 200)
      return;
    anim.SetTrigger("Attack");
    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

    transform.localScale *= 0.5f;
    hp -= 100;

  }

  private void TakeDamage()
  {
    anim.SetFloat("DamageType", 2f);
    anim.SetTrigger("Damage");
    characterController.Move(transform.TransformDirection(Vector3.back) * 2f);

    //characterController.Move(Vector3.back * 2f * Time.deltaTime);
  }

  /********************** Collider for Kicking Objects ***********************/

  //the following section allows character controller to push things away (hard)
  [SerializeField]
  private float forceMagnitude;

  private void OnControllerColliderHit(ControllerColliderHit hit)
  {
    var rigidBody = hit.collider.attachedRigidbody;

    if (rigidBody != null)
    {
      if (hit.gameObject.layer == 9)
      {
        Debug.Log("Hit Enemy");
        TakeDamage();

        if (bigSlime.activeSelf)
        {
          Destroy(hit.gameObject);
        }else{
          if(m_DamageCooldown > 0)
            return;
          m_DamageCooldown = damageDelay;
          transform.localScale *= 0.5f;
          hp -= 100;

        }
      }else if (hit.gameObject.layer == 12){
        Debug.Log("HP Barrier Col");
        if(hp < 200){
          Destroy(hit.gameObject);
        }
      }
      var forceDirection = hit.gameObject.transform.position - transform.position;
      forceDirection.y = 0;
      forceDirection.Normalize();

      rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);


    }
  }

  /********************** Kill the Player if they fall ***********************/

  private void KillPlayerFall()
  {
    if (transform.position.y <= 0)
    {
      ScoreScript.score = 0;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}
