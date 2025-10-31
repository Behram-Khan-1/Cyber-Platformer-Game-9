using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI moneyTextGUI;
    [SerializeField] private TextMeshProUGUI healthTextGUI;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void MoneyUIUpdate(int value)
    {
        moneyTextGUI.text = " " + value.ToString();
    }
    public void HealthUIUpdate(int value)
    {
        healthTextGUI.text = " " + value.ToString();
    }

}
