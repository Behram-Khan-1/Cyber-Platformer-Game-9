using UnityEngine;

public class EnemyAttackState : BaseState<EnemyStateType>
{
    private EnemyStateManager manager;
    bool isStunned = false;
    private float attackCooldown;
    public EnemyAttackState(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }

    public override void EnterState()
    {
        // Debug.Log("Attacking");
        manager.ActiveState = EnemyStateType.Attack;
        manager.animator.SetBool("IsAttacking", true);
        isStunned = false;
        attackCooldown = 0;
    }

    public override void UpdateState()
    {
        //Play Attack animation
        //attack the side player is on
        //if out of range, return to chase.

        if (!manager.isAttacking)
        {
            manager.lineOfSight.TurnEnemyToPlayer();
            manager.animator.SetBool("IsAttacking", false);
            attackCooldown = attackCooldown - Time.deltaTime;
            if (attackCooldown <= 0)
            {
                manager.isAttacking = true;
                attackCooldown = manager.attackCooldown;
                //Perform Attack
                manager.animator.SetBool("IsAttacking", true);
                // Debug.Log("Attack");
            }
        }

    }

    public override void ExitState()
    {
        // Debug.Log("Exiting Attack State");
        manager.animator.SetBool("IsAttacking", false);
    }

    public override EnemyStateType GetNextState()
    {
        //if out of attack range, then chase
        if (!manager.lineOfSight.IsPlayerInAttackRange(manager.attackRange) && !manager.isAttacking)
        {
            return EnemyStateType.Chase;
        }
        // Debug.Log("Is Stunned: " + isStunned);
        if (isStunned == true)
        {
            Debug.Log("Stunned");
            return EnemyStateType.Parried;
        }

        return stateKey;

    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerParry = collision.GetComponent<CharacterParry>();
            if (playerParry.TryParrying() == true)
            {
                isStunned = true;
                manager.isAttacking = false;
                return;
            }
            collision.gameObject.GetComponent<CharacterBase>().DecreaseHealth(manager.attackDamage);
        }
    }
}
