using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents the attack state of an enemy in a state machine.
public class AttackState : BaseState
{
    // Timer used for controlling the movement during attack
    private float moveTimer;

    // Timer used for losing track of the player
    private float losePlayerTimer;

    // Timer used for controlling the shooting interval
    private float shootTimer;

    // Called when entering the attack state
    public override void Enter()
    {
        // Initialization code can be added here if needed
    }

    // Called to perform actions in the attack state
    public override void Perform()
    {
        // Check if the enemy can see the player
        if (enemy.CanSeePlayer())
        {
            // Reset the lose player timer
            losePlayerTimer = 0;

            // Increment the move and shoot timers
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;

            // Make the enemy face the player
            enemy.transform.LookAt(enemy.Player.transform.position);

            // Shoot at the player after a certain time interval
            if (shootTimer > enemy.fireRate)
            {
                Shoot();
                //shootTimer = 0;
            }

            // Move randomly after a certain time interval
            if (moveTimer > Random.Range(3, 7))
            {   
                // Move the enemy to a random position within a certain radius
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                
                // Reset the move timer
                moveTimer = 0;
            }

            // Update the last known position of the player
            enemy.LastKnownPosition = enemy.Player.transform.position;
        }
        else
        {
            // Increment the lose player timer
            losePlayerTimer += Time.deltaTime;

            // Transition to the search state after losing sight of the player for a certain duration
            if (losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }

    // Called when exiting the attack state
    public override void Exit()
    {
        // Clean-up code can be added here if needed
    }

    // Perform shooting action
    public void Shoot()
    {   
        // Get the position of the gun barrel
        Transform gunbarrel = enemy.gunBarrel;

        // Instantiate a bullet prefab
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Revolver_Bullet") as GameObject,
            gunbarrel.position, enemy.transform.rotation);

        // Calculate the direction towards the player
        Vector3 bulletDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;

        // Set the bullet's velocity with some random spread
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * bulletDirection * 40;

        // Log a message indicating the shooting action
        Debug.Log("Shoot");

        // Reset the shoot timer
        shootTimer = 0;
    }
}
