using System.Collections;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Transform bottom;
    [SerializeField] private Transform flag;
    [SerializeField] private float slidingSpeed = 4f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PauseManager.instance.TogglePause(true);
            StartCoroutine(MoveDown());
            StartCoroutine(MoveDownPlayer(collision.gameObject));
        }
    }

    IEnumerator MoveDown()
    {
        while (flag.position.y > bottom.position.y)
        {
            flag.position = Vector2.MoveTowards(flag.position, bottom.position, slidingSpeed * Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator MoveDownPlayer(GameObject player)
    {
        while (player.transform.position.y > bottom.position.y)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, bottom.position, slidingSpeed * Time.deltaTime);
            yield return null;
        }

        PauseManager.instance.TogglePause(false);
        enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
