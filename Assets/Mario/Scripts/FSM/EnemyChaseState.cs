using UnityEngine;

public class EnemyChaseState : BaseState<EnemyStateType>
{
    private EnemyStateManager manager;

    public EnemyChaseState(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }

    public override void EnterState()
    {
        manager.ActiveState = EnemyStateType.Chase;
        manager.animator.SetBool("IsRunning", true);
        // Debug.Log("Chasing player");
    }

    public override void UpdateState()
    {
        //Enemy Moveing to player
        //Flip enemy if player is behind it

        Vector2 dir = (manager.player.position - manager.transform.position).normalized;
        manager.transform.position += (Vector3)dir * 2f * Time.deltaTime; // move speed

       manager.lineOfSight.TurnEnemyToPlayer();
    }

    public override void ExitState()
    {
        manager.animator.SetBool("IsRunning", false);
    }

    public override EnemyStateType GetNextState()
    {
        if (manager.lineOfSight.IsPlayerInAttackRange(manager.attackRange))
        {
            return EnemyStateType.Attack;
        }

        if (manager.lineOfSight.CanSeePlayer())
        { return EnemyStateType.Chase; }
        else
        {
            return EnemyStateType.Idle;
        }


    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }
}
