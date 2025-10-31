using System;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=qsIiFsddGV4&list=PLrXoflRZ7xBuj5wu1V_d9wjjr3JEZjhiN&index=9 

public abstract class StateManagerr<Estate> : MonoBehaviour where Estate : Enum //Also abstract
{
    //                     Key      Value
    protected Dictionary<Estate, BaseState<Estate>> states = new(); // Store every state the enemies will use in a dictionary.
    //In every enemy we will register the states that will be used, so <EnemyStateType.Idle, Then we will pass EnemyIdleState to it since it inherits from BaseState<Estate>
    protected BaseState<Estate> currentState; //showing us current state enemy is in.

    protected bool IsTransitioningState = false; // is in middle of transition of state or no? we want this so when we are changing state we only call changeState once not multiple times.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //Jo state bhi enter ho tho uska enterstate method call karo
    {
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        Estate nextStateKey = currentState.GetNextState(); // idle ka GetNextState method call karo, if condiiton fulfilled it will change to chase.

        if ( !IsTransitioningState && nextStateKey.Equals(currentState.stateKey)) // if state has not changed then update
        {
            currentState.UpdateState(); //currentstate i.e idle ka updatestate method call karo
        }
        else if(!IsTransitioningState) // if state changed, then transition
        {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(Estate nextStateKey)
    {
        IsTransitioningState = true; //state is changing, set to true so update doesnt call it again
        currentState.ExitState(); //Play exit state function of idle
        currentState = states[nextStateKey]; //set current state to chase
        currentState.EnterState(); //play enter state function of chase
        IsTransitioningState = false; //state is not changing, now we can run UpdateState in update method 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter(collision);
    }


}
