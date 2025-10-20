using UnityEngine;

public class EnemyLineOfSight
{
    private EnemyStateManager manager;

    public EnemyLineOfSight(EnemyStateManager manager)
    {
        this.manager = manager;
    }

    public bool CanSeePlayer()
    {
        if (manager.player == null) return false;

        float dist = Vector2.Distance(manager.transform.position, manager.player.position);
        if (dist > manager.detectionRange) return false;


        var playerDir = (manager.player.position - manager.transform.position).normalized;
        LayerMask enemy = ~manager.enemyLayer;
        RaycastHit2D hit = Physics2D.Raycast(manager.transform.position, playerDir, manager.detectionRange, enemy);
        Debug.DrawRay(manager.transform.position, playerDir * manager.detectionRange, Color.green);

        // Debug.Log("Ray hit: " + hit.collider.name);
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            // Debug.Log("Ray hit: " + hit.collider.name);
            return true;
        }

        return false;
    }

    public bool IsFacingPlayer()
    {
        var playerDir = (manager.player.position - manager.transform.position).normalized;
        Debug.DrawRay(manager.transform.position, playerDir, Color.red);
        return Vector2.Dot(manager.transform.right, playerDir) > 0;
    }

    public bool IsPlayerInAttackRange(float range)
    {
        return Vector2.Distance(manager.transform.position, manager.player.position) <= manager.attackRange;
    }
}
