using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    CharacterMovement controller;
    bool isOnPipe;
    bool isUsed;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            isOnPipe = true;
        }
        else
        {
            isOnPipe = false;
        }


    }




    void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Pipe" && isOnPipe && !isUsed)
        {
            Debug.Log("Enter Pipe");
            collision.gameObject.GetComponent<Pipe>().EnterPipe(controller);
            isUsed = true;

        }
    }
}

