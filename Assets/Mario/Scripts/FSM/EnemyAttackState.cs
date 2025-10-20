using UnityEngine;

public class EnemyAttackState : BaseState<EnemyStateType>
{
    private EnemyStateManager manager;
    private float attackCooldown;
    public EnemyAttackState(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }

    public override void EnterState()
    {
        Debug.Log("Attacking");
        manager.ActiveState = EnemyStateType.Attack;
        manager.animator.SetBool("IsAttacking", true);
        attackCooldown = 0;
    }

    public override void UpdateState()
    {
        //Play Attack animation
        //attack the side player is on
        //if out of range, return to chase.
        if (!manager.isAttacking)
        {
            manager.animator.SetBool("IsAttacking", false);
            attackCooldown = attackCooldown - Time.deltaTime;
            Debug.Log(attackCooldown);
            if (attackCooldown <= 0)
            {
                manager.isAttacking = true;
                attackCooldown = manager.attackCooldown;
                //Perform Attack
                manager.animator.SetBool("IsAttacking", true);
                Debug.Log("Attack");
            }
        }

    }

    public override void ExitState()
    {
        Debug.Log("Exiting Attack State");
        manager.animator.SetBool("IsAttacking", false);
    }

    public override EnemyStateType GetNextState()
    {
        //if out of attack range, then chase
        if (!manager.lineOfSight.IsPlayerInAttackRange(manager.attackRange) && !manager.isAttacking)
        {
            return EnemyStateType.Chase;
        }

        // if (manager.lineOfSight.IsPlayerInAttackRange(manager.attackRange) && !manager.isAttacking)
        // {
        //     return EnemyStateType.Chase;
        // }
        return stateKey;

    }
}
