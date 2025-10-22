using Unity.Mathematics;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] float comboResetDelay = 0.5f;

    private CharacterAnimatorManager animator;
    int numberOfClicks = 0;
    [SerializeField] float attackTimer;

    private const string PUNCH_1 = "Punch1";
    private const string PUNCH_2 = "Punch2";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<CharacterAnimatorManager>();
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (attackTimer > 0)
            {
                return;
            }
            OnAttack();
        }
    }

    private void OnAttack()
    {
        // Debug.Log("Player Attacked");
        numberOfClicks++;
        numberOfClicks = Mathf.Clamp(numberOfClicks, 1, 2);

        // reset both triggers before setting one to avoid stuck states
        animator.ResetTrigger(PUNCH_1);
        animator.ResetTrigger(PUNCH_2);

        if (numberOfClicks == 1)
        {
            animator.SetTrigger(PUNCH_1);
        }
        else if (numberOfClicks == 2)
        {
            animator.SetTrigger(PUNCH_2);
        }

        CancelInvoke(nameof(ResetCombo)); // cancel previous scheduled reset
        Invoke(nameof(ResetCombo), comboResetDelay);
    }

    public void ResetCombo()
    {
        animator.ResetTrigger(PUNCH_1);
        animator.ResetTrigger(PUNCH_2);
        attackTimer = attackCooldown;
        numberOfClicks = 0;
    }
}
