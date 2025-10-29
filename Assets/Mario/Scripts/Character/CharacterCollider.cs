using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterCollider : MonoBehaviour
{
    CharacterMovement controller;
    CharacterBase characterBase;
    bool isOnPipe;
    bool isUsed;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterMovement>();
        characterBase = gameObject.GetComponent<CharacterBase>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        // {
        //     isOnPipe = true;
        // }
        // else
        // {
        //     isOnPipe = false;
        // }

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


    // void OnCollisionStay2D(Collision2D collision)
    // {

    //     // Debug.Log(collision.gameObject.name);
    //     if (collision.gameObject.tag == "Pipe" && isOnPipe && !isUsed)
    //     {
    //         Debug.Log("Enter Pipe");
    //         collision.gameObject.GetComponent<Pipe>().EnterPipe(controller);
    //         isUsed = true;
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBase>().TakeDamage(characterBase.damage);
        }
    }

}

