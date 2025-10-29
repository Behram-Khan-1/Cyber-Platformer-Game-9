using System.Collections;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        anim.SetBool("IsOpen", true);
        StartCoroutine("WaitForSeconds", 2);
    }
    
    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
