using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public static CharacterBase instance;
    [SerializeField] public int money { get; private set; }
    [SerializeField] public int health { get; private set; } = 100;
    [SerializeField] public int hearts { get; private set; } = 3;
    [SerializeField] public int damage { get; private set; } = 50;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager.instance.MoneyUIUpdate(money);
        UIManager.instance.HealthUIUpdate(health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMoney(int amount)
    {
        if (money >= 100)
        { money = 100; }
        else
        {
            money += amount;
            UIManager.instance.MoneyUIUpdate(money);
        }
    }
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        UIManager.instance.HealthUIUpdate(health);
        if (health <= 0)
        {
            GameManager.instance.PlayerDied();
        }
    }

    public void SetHealth(int amount)
    {
        health = amount;
        UIManager.instance.HealthUIUpdate(health);
    }
    public void SetMoney(   int amount)
    {
        money = amount;
        UIManager.instance.MoneyUIUpdate(money);
    }
}
