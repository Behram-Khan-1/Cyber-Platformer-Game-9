using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterCollider : MonoBehaviour
{
    CharacterBase characterBase;

    void Start()
    {
        characterBase = gameObject.GetComponent<CharacterBase>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        var hit = Physics2D.OverlapCircle(transform.position, 2f, LayerMask.GetMask("Interactable"));
        if (hit != null)
        {
            hit.GetComponent<IUsable>().Use();
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBase>().TakeDamage(characterBase.damage);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.PlayerHurt);

        }
    }

}

