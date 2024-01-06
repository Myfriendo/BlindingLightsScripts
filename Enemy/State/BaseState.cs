// An abstract base class representing a state in an enemy state machine.
public abstract class BaseState
{
    // Instance of the StateMachine class associated with this state
    public StateMachine stateMachine;

    // Instance of the Enemy class associated with this state
    public Enemy enemy;
    
    // Called when entering this state
    public abstract void Enter();

    // Called to perform actions in this state
    public abstract void Perform();

    // Called when exiting this state
    public abstract void Exit();
}
