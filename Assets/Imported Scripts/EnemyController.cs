using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;    // an array of waypoints that define the patrol path
    public float moveSpeed = 3f;     // speed at which the AI moves between waypoints
    public int maxHealth = 3;        // maximum health of the AI
    public int damage = 1;           // damage taken by the AI when hit by the player

    private int currentWaypointIndex = 0;  // index of the current waypoint the AI is moving towards
    private int patrolDirection = 1;        // direction of patrol (1 for forward, -1 for backward)
    private int currentHealth;              // current health of the AI
    private CharacterController controller;

    void Start()
    {
        currentHealth = maxHealth;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // check if we have reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // if so, update the waypoint index based on the current patrol direction
            currentWaypointIndex += patrolDirection;

            // if we've reached the end of the patrol path, reverse the patrol direction
            if (currentWaypointIndex >= waypoints.Length || currentWaypointIndex < 0)
            {
                patrolDirection *= -1;
                currentWaypointIndex += patrolDirection * 2;
            }
        }

        // create a new vector that ignores the y-value of the waypoint positions
        Vector3 targetPosition = new Vector3(waypoints[currentWaypointIndex].position.x, transform.position.y, waypoints[currentWaypointIndex].position.z);

        // calculate the direction and distance to the current waypoint
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);

        // move towards the current waypoint using CharacterController.SimpleMove
        controller.SimpleMove(direction * moveSpeed);

        // rotate the AI to face the direction of movement
        if (distance > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage(damage);
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // do something when the AI dies, such as play an animation or spawn a particle effect
        Destroy(gameObject);
    }
}