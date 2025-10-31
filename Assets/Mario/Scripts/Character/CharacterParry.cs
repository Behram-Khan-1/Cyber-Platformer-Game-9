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
    [SerializeField] float parryWindowTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<CharacterAnimatorManager>();
        parryResetTimer = parryCooldown;
        parryWindowTimer = parryWindow;
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
            parryWindowTimer = parryWindowTimer - Time.deltaTime;
        }

        if (parryResetTimer <= 0)
        {
            isParrying = false;
        }

        if (Input.GetMouseButtonDown(1) && !isParrying)
        {
            isParrying = true;
            parryResetTimer = parryCooldown;
            parryWindowTimer = parryWindow;
            animator.SetTrigger("Parry");
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Parry);
        }
    }

    public bool TryParrying()
    {
        if (parryWindowTimer >= 0 && isParrying)
        {
            Debug.Log("Parried");
            parryWindowTimer = parryWindow;
            isParrying = false;
            return true;
        }
        return false;
    }

}
