using UnityEngine;

public class EnemyStateManager : StateManagerr<EnemyStateType> // Inherits from StateManager
{
    //This will be attached to every enemy
    public Transform player;
    public float detectionRange = 5f;
    void Awake()
    {
        // Add all states to the dictionary
        //Register dictionary idle state with EnemyIdleState class
        //and EnemyIdleState with Idle key and this manager as its manager
        states[EnemyStateType.Idle] = new EnemyIdleState(EnemyStateType.Idle, this);
        // states[EnemyStateType.Patrol] = new EnemyPatrolState(EnemyStateType.Patrol, this);
        states[EnemyStateType.Chase] = new EnemyChaseState(EnemyStateType.Chase, this);
        // states[EnemyStateType.Attack] = new EnemyAttackState(EnemyStateType.Attack, this);

        currentState = states[EnemyStateType.Idle];
    }
}
