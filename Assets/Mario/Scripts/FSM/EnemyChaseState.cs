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
        Debug.Log("Chasing player");
    }

    public override void UpdateState()
    {
        Vector2 dir = (manager.player.position - manager.transform.position).normalized;
        manager.transform.position += (Vector3)dir * 2f * Time.deltaTime; // move speed
    }

    public override void ExitState() { }

    public override EnemyStateType GetNextState()
    {
        RaycastHit2D RaycastRight = Physics2D.Raycast(new Vector2(manager.groundCheck.position.x, manager.groundCheck.position.y + 0.4f)
        , manager.transform.right, manager.detectionRange);
        RaycastHit2D RaycastLeft = Physics2D.Raycast(new Vector2(manager.groundCheck.position.x, manager.groundCheck.position.y + 0.4f)
         , -manager.transform.right, manager.detectionRange);

        Debug.DrawRay(manager.transform.position, manager.transform.right * manager.detectionRange, Color.red);
        Debug.DrawRay(manager.transform.position, -manager.transform.right * manager.detectionRange, Color.blue);

        if (RaycastRight.collider != null && RaycastRight.collider.tag == "Player")
        {
            return stateKey; //return chase
        }
        else if (RaycastLeft.collider != null && RaycastLeft.collider.tag == "Player")
        {
            return stateKey;
        }
            
            

        float dist = Vector2.Distance(manager.transform.position, manager.player.position);

        if (dist < 1) { Debug.Log("Attack"); return EnemyStateType.Idle; }
        // if (dist < manager.attackRange)
        //     return EnemyStateType.Attack;

        // if (dist > manager.detectionRange)
        //     return EnemyStateType.Patrol;

        return stateKey;
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
