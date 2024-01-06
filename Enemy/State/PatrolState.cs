using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents the patrol state of an enemy in a state machine.
public class PatrolState : BaseState
{   
    // Index of the current waypoint in the patrol path
    public int waypointIndex;

    // Timer used to control the waiting period at each waypoint
    public float waitTimer;

    // Called when entering the patrol state
    public override void Enter()
    {
        // Initialization code can be added here if needed
    }

    // Called to perform actions in the patrol state
    public override void Perform()
    {
        // Execute the patrol cycle logic
        PatrolCycle();

        // Check if the enemy can see the player and transition to the attack state if true
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    // Called when exiting the patrol state
    public override void Exit()
    {
        // Clean-up code can be added here if needed
    }
    
    // Perform the logic for patrolling between waypoints
    public void PatrolCycle()
    {
        // Check if the enemy is close to the current waypoint
        if(enemy.Agent.remainingDistance < 0.2f)
        {   
            // Increment the wait timer
            waitTimer += Time.deltaTime;

            // Check if enough time has passed to move to the next waypoint
            if (waitTimer > 3)
            {
                // Update the waypoint index to the next one in the patrol path
                if(waypointIndex < enemy.path.waypoints.Count-1)
                {
                    waypointIndex++;
                }
                else
                {
                    waypointIndex = 0;
                }

                // Set the destination of the enemy to the new waypoint
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);

                // Reset the wait timer
                waitTimer = 0;
            }
        }
    }
}
