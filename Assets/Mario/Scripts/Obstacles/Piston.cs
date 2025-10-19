using UnityEngine;

public class Piston : MonoBehaviour
{
    public Collider2D damageCollider;

    public void OpenPiston()
    {
        damageCollider.enabled = true;
    }

    public void ClosePiston()
    {
        damageCollider.enabled = false;
    }


}
