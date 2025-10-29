using UnityEngine;

public class Chest : MonoBehaviour, IUsable
{
    [SerializeField] private int amountOfMoney = 5;
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField] private Transform spawnPoint;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Use()
    {
        Debug.Log("Chest Used");
        anim.SetBool("Open", true);
    }
    public void ChestOpened()
    {
        var money = Instantiate(moneyPrefab, spawnPoint.position, Quaternion.identity);
        money.GetComponent<Money>().SetMoneyValue(amountOfMoney);
        //Later add lighting
    }
    public void ChestClosed()
    {
        Destroy(gameObject);
        //add poof particle
    }


}
