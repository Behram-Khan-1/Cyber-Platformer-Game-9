using Unity.Mathematics;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private EnemyStateManager manager;
    private EnemyBase enemy;
    void Start()
    {
        manager = GetComponent<EnemyStateManager>();
        enemy = GetComponent<EnemyBase>();
    }

    public void EndAttack()
    {
        manager.isAttacking = false;
    }
    public void EnemyDied()
    {
        Instantiate(enemy.moneyPrefab, enemy.transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}
