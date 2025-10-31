using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int moneyValue = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterBase>().AddMoney(moneyValue);
            SoundManager.Instance.PlaySound(SoundManager.SoundType.Money);
            Destroy(gameObject);
        }
    }

    public void SetMoneyValue(int value)
    {
        moneyValue = value;
    }
}
