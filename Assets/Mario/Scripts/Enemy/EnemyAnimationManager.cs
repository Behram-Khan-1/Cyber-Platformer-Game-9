using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private EnemyStateManager manager;
    void Start()
    {
        manager = GetComponent<EnemyStateManager>();
    }

    public void EndAttack()
    {
        manager.isAttacking = false;
    }
}
