using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyPatrolState : BaseState<EnemyStateType>
{
    private EnemyStateManager manager;
    private bool directionChanged = false;


    public EnemyPatrolState(EnemyStateType stateKey, EnemyStateManager manager) : base(stateKey)
    {
        this.manager = manager;
    }


    public override void EnterState()
    {
        Debug.Log("Patrolling");
        manager.ActiveState = EnemyStateType.Patrol;
        directionChanged = false;
        manager.animator.SetBool("IsRunning", true);
        FlipDirection();
    }


    public override void UpdateState()
    {
        if (CanMoveNext())
        {
            manager.rb.linearVelocity = new Vector2(manager.patrolSpeed * manager.transform.right.x, manager.rb.linearVelocityY);
        }
        else
        {
            directionChanged = true;
        }
    }
    void FlipDirection()
    {
        manager.transform.right = -manager.transform.right;
    }

    bool CanMoveNext()
    {
        bool groundHit = Physics2D.Raycast(manager.groundCheck.position, Vector2.down, 0.3f, manager.groundLayer);
        Debug.DrawRay(manager.groundCheck.position, Vector2.down * 0.5f, Color.red);
        // bool wallHit = Physics2D.Raycast(manager.transform.position, manager.transform.right, 0.3f, manager.groundLayer);
        if (groundHit)
        {
            return true;
        }
        return false;

    }
    public override void ExitState()
    {
        // Debug.Log("Exiting Enemy Patrol State");
    }
    public override EnemyStateType GetNextState()
    {

        if (manager.lineOfSight.IsFacingPlayer())
        {
            if (manager.lineOfSight.CanSeePlayer())
                return EnemyStateType.Chase;
        }


        if (directionChanged == true)
        {
            return EnemyStateType.Idle;
        }
        return stateKey;
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}
