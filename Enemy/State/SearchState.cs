using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents the search state of an enemy in a state machine.
public class SearchState : BaseState
{   
    // Timer used for controlling the search duration
    private float searchTimer;

    // Timer used for controlling the movement during search
    private float moveTimer;

    // Called when entering the search state
    public override void Enter()
    {
        // Set the destination of the enemy to the last known position of the player
        enemy.Agent.SetDestination(enemy.LastKnownPosition);
    }

    // Called to perform actions in the search state
    public override void Perform()
    {
        // Check if the enemy can see the player and transition to the attack state if true
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }

        // Check if the enemy is close to the last known position of the player
        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            // Increment the search and move timers
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            // Move randomly after a certain time interval
            if (moveTimer > Random.Range(3, 5))
            {   
                // Move the enemy to a random position within a certain radius
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                
                // Reset the move timer
                moveTimer = 0;
            }

            // Transition to patrol state after a certain search duration
            if (searchTimer > Random.Range(7, 15))
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    // Called when exiting the search state
    public override void Exit()
    {
        // Clean-up code can be added here if needed
    }
}
