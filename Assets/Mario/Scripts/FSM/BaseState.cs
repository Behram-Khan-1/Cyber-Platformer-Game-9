
using System;

public abstract class BaseState<EState> where EState : Enum //We use EnemyStateType Enum here
{

    public BaseState(EState Key)
    {
        stateKey = Key;
    }

    public EState stateKey; //When we add a state to dictionary in StateManager, We store it here. so every state can use its own Enter,update, exitstate.
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public abstract EState GetNextState();

    // public abstract void OnTriggerEnter();
    // public abstract void OnTriggerExit();
    // public abstract void OnTriggerStay();

}
