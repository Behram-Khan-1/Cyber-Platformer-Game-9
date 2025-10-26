using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterParry : MonoBehaviour
{
    CharacterAnimatorManager animator;
    [SerializeField] bool isParrying = false;
    [SerializeField] float parryWindow = 0.3f;
    [SerializeField] float parryCooldown = 1f;
    public float StunDuration = 1f;
    [SerializeField] float parryResetTimer;
    [SerializeField] float parryTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<CharacterAnimatorManager>();
        parryResetTimer = parryCooldown;
        parryTimer = parryWindow;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.instance.isPlayerPaused)
        {
            return;
        }
        
        if (isParrying == true)
        {
            parryResetTimer = parryResetTimer - Time.deltaTime;
            parryTimer = parryTimer - Time.deltaTime;
        }

        if (parryResetTimer <= 0)
        {
            isParrying = false;
        }

        if (Input.GetMouseButtonDown(1) && !isParrying)
        {
            isParrying = true;
            parryResetTimer = parryCooldown;
            parryTimer = parryWindow;
            animator.SetTrigger("Parry");
        }
    }

    public bool TryParrying()
    {
        if (parryTimer >= 0 && isParrying)
        {
            Debug.Log("Parried");
            parryTimer = parryWindow;
            isParrying = false;
            return true;
        }
        return false;
    }

}
