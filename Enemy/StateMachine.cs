using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a state machine controlling the behavior of an object.
public class StateMachine : MonoBehaviour
{   
    // The currently active state in the state machine
    public BaseState activeState;

    // Initializes the state machine by setting the initial state to PatrolState.
    public void Initialize()
    {
        ChangeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    { // Additional initialization code can be added here if needed}

    // Update is called once per frame
    void Update()
    {
        // Perform the actions of the active state on each frame
        if (activeState != null)
        {
            activeState.Perform();
        }
    }

    // Changes the active state to a new state.
    public void ChangeState(BaseState newState)
    {
        // Exit the current state before changing to a new state
        if (activeState != null)
        {
            activeState.Exit();
        }
        // Set the new state as the active state
        activeState = newState;
        // Enter the new state and set references if the new state is not null
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
