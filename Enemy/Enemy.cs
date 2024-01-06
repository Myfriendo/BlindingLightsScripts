using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Represents an enemy character in the game.
public class Enemy : MonoBehaviour
{
    // Instance of the state machine controlling the enemy's behavior
    private StateMachine stateMachine;

    // Reference to the NavMeshAgent component for navigation
    private NavMeshAgent agent;

    // Reference to the player GameObject
    private GameObject player;

    // Last known position of the player
    private Vector3 lastKnownPosition;

    // Current state of the enemy (for debugging purposes)
    [SerializeField] private string currentState;

    // Path for patrolling behavior
    public Path path;

    // Sight-related parameters
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fov = 85f;
    [SerializeField] public float eyeHeight;

    // Weapon-related parameters
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f,10f)]public float fireRate = 0.5f;

    // Debug sphere to visualize the last known position
    public GameObject debugSphere;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the state machine
        stateMachine = GetComponent<StateMachine>();
        stateMachine.Initialize();

        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Find the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy can see the player
        CanSeePlayer();

        // Update the current state (for debugging purposes)
        currentState = stateMachine.activeState.ToString();

        // Update the debug sphere's position to the last known position
        debugSphere.transform.position = lastKnownPosition;
    }

    // Checks if the enemy can see the player
    public bool CanSeePlayer()
    {
        // Ensure that the player exists
        if (player != null)
        {
            // Check if the player is within the sight distance
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                // Calculate the angle between the enemy's forward direction and the direction to the player
                Vector3 targetDir = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));

                // Check if the player is within the field of view
                if (angleToPlayer >= -fov && angleToPlayer <= fov)
                {
                    // Create a ray from the enemy's position to the player's position
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDir);
                    RaycastHit hitInfo = new RaycastHit();

                    // Check if the ray hits anything within the sight distance
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        // Check if the hit object is the player
                        if (hitInfo.transform.gameObject == player)
                        {   
                            // Set the last known position to the player's position
                            lastKnownPosition = player.transform.position;
                            return true;
                        }
                    }

                    // Draw a debug ray to visualize the sight direction
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }
        }

        // Return false if the player is not seen
        return false;
    }
}
