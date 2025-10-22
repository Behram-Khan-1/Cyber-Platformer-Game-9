using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetBoolTrue(string name)
    {
        animator.SetBool(name, true);
    }

    public void SetBoolFalse(string name)
    {
        animator.SetBool(name, false);
    }

    public void SetTrigger(string name)
    {
        animator.SetTrigger(name);
    }
    public void ResetTrigger(string name)
    {
        animator.ResetTrigger(name);
    }

    public void SetFloat(string name, float value)
    {
        animator.SetFloat(name, value);
    }

}
