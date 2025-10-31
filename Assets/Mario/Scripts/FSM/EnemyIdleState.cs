using UnityEngine;

public class EnemyIdleState : BaseState<EnemyStateType> //Every state inherits from BaseState cuz it has stuff like enter, update, exit state
{
    private EnemyStateManager manager; // reference to manager that will control this enemy states with StateManager
    private float idleTimer = 1.2f;
    //EnemyStateManager will setup this key to idle and manager to itself
    public EnemyIdleState(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }

    //Below is implementation of Idle state amnd its methods
    public override void EnterState()
    {
        Debug.Log("Idle Timer: " + idleTimer);
        if (manager is TutorialFightStateManager tutorialFightManager)
        {
            idleTimer = 100000f; // Stay idle indefinitely during tutorial fight
        }

        // Debug.Log("Entered Idle");
        manager.ActiveState = EnemyStateType.Idle;
        manager.animator.SetBool("IsRunning", false);
    }

    public override void UpdateState()
    {
        idleTimer -= Time.deltaTime;
        // maybe look around, play idle anim
    }

    public override void ExitState()
    {

    }

    //In this method we will setup stuff of how to change state from idle to others.
    public override EnemyStateType GetNextState()
    {

        if (manager.lineOfSight.IsFacingPlayer())
        {
            Debug.Log("Is Facing Player");
            if (manager.lineOfSight.CanSeePlayer())
            {
                Debug.Log("Can see player");
                return EnemyStateType.Chase;
            }
        }
        if (manager.lineOfSight.IsPlayerInAttackRange(manager.attackRange))
        {
            Debug.Log("in range");
            return EnemyStateType.Attack;
        }


        if (idleTimer <= 0)
            return EnemyStateType.Patrol;

        return stateKey; // stay idle
    }

    public override void OnTriggerEnter(Collider2D collision)
    {

    }
}
