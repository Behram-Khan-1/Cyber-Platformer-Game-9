using UnityEngine;

public class Piston : MonoBehaviour
{
    public Collider2D damageCollider;
    public int damage = 5;

    public void OpenPiston()
    {
        damageCollider.enabled = true;
    }

    public void ClosePiston()
    {
        damageCollider.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterBase>().DecreaseHealth(damage);
        }
    }

}
