using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] private int money;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        }
    }
}
