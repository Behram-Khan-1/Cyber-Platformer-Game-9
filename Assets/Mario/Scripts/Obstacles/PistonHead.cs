using UnityEngine;

public class PistonHead : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // collision.gameObject.GetComponent<CharacterMovement>().TakeDamage(1);
            Debug.Log("Player hit by piston");
        }
    }
}
