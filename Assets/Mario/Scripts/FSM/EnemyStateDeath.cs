using UnityEngine;
using System.Collections;

public class EnemyStateDeath : BaseState<EnemyStateType>
{
    private EnemyStateManager manager;
    public EnemyStateDeath(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }

    public override void EnterState()
    {
        Debug.Log("Manager Death Called");
        manager.animator.SetBool("IsAttacking", false);
        manager.ActiveState = EnemyStateType.Death;
        
        manager.animator.SetTrigger("IsDead");

        // Optional: disable collider/movement
        manager.GetComponent<Collider2D>().enabled = false;
        manager.GetComponent<Rigidbody2D>().simulated = false;
    }

    public override void ExitState()
    {

    }

    public override EnemyStateType GetNextState()
    {
        return stateKey;
    }

    public override void OnTriggerEnter(Collider2D collision)
    {

    }

    public override void UpdateState()
    {

    }
}
