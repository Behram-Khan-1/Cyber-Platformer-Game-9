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
        Debug.Log("Entered Idle");
        manager.ActiveState = EnemyStateType.Idle;
        idleTimer = 1.2f;
        manager.animator.SetBool("IsRunning", false);
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

        if (manager.lineOfSight.IsFacingPlayer())
        {
            if (manager.lineOfSight.CanSeePlayer())
            
                return EnemyStateType.Chase;
        }
        if (manager.lineOfSight.IsPlayerInAttackRange(manager.attackRange))
        {
                return EnemyStateType.Attack;
        }



        if (idleTimer <= 0)
            return EnemyStateType.Patrol;

        return stateKey; // stay idle
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}
