using UnityEngine;

public class EnemyIdleState : BaseState<EnemyStateType> //Every state inherits from BaseState cuz it has stuff like enter, update, exit state
{
    private EnemyStateManager manager; // reference to manager that will control this enemy states with StateManager
    private float idleTimer;
    //EnemyStateManager will setup this key to idle and manager to itself
    public EnemyIdleState(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }

    //Below is implementation of Idle state amnd its methods
    public override void EnterState()
    {
        idleTimer = 2f;
        Debug.Log("Entered Idle");
    }

    public override void UpdateState()
    {
        idleTimer -= Time.deltaTime;
        // maybe look around, play idle anim
    }

    public override void ExitState()
    {
        Debug.Log("Exited Idle");
    }

    //In this method we will setup stuff of how to change state from idle to others.
    public override EnemyStateType GetNextState()
    {
        float dist = Vector2.Distance(manager.transform.position, manager.player.position);

        // if (dist < manager.attackRange)
        //     return EnemyStateType.Attack;

        if (dist < manager.detectionRange)
            return EnemyStateType.Chase;

        // if (idleTimer <= 0)
        //     return EnemyStateType.Patrol;

        return stateKey; // stay idle
    }

    public override void OnTriggerEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay()
    {
        throw new System.NotImplementedException();
    }
}
