using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int moneyValue = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterBase>().AddMoney(moneyValue);
            Destroy(gameObject);
        }
    }
}
