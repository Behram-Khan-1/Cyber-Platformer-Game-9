using UnityEngine;

public class ScreenEffects : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void BloodEffectOn()
    {
        anim.SetTrigger("Blood");
    }

}
