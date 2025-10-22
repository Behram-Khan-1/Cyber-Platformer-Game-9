using UnityEngine;

public class EnemyStateManager : StateManagerr<EnemyStateType> // Inherits from StateManager
{
    //This will be attached to every enemy
    [Header("Enemy Basics")]
    public Transform player;
    public Rigidbody2D rb;

    public EnemyStateType ActiveState;

    [Header("AI Settings")]
    public EnemyLineOfSight lineOfSight;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public int attackDamage = 5;
    public float patrolSpeed;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;


    [Header("Animation")]
    public bool isAttacking;
    public Animator animator;



    void Awake()
    {
        lineOfSight = new EnemyLineOfSight(this);
        // Add all states to the dictionary
        //Register dictionary idle state with EnemyIdleState class
        //and EnemyIdleState with Idle key and this manager as its manager
        states[EnemyStateType.Idle] = new EnemyIdleState(EnemyStateType.Idle, this);

        states[EnemyStateType.Patrol] = new EnemyPatrolState(EnemyStateType.Patrol, this);

        states[EnemyStateType.Chase] = new EnemyChaseState(EnemyStateType.Chase, this);
        states[EnemyStateType.Attack] = new EnemyAttackState(EnemyStateType.Attack, this);

        currentState = states[EnemyStateType.Idle];
    }
}
