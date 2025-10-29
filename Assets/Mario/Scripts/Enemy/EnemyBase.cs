using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] public int health = 100;
    public Transform moneyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void TakeDamage(int damageAmount)
    {
        if (gameObject.TryGetComponent<TutorialFightStateManager>(out TutorialFightStateManager tutorialManager))
        {
            tutorialManager.RegisterHit();
        }
        

        health -= damageAmount;
        if (health <= 0)
        {
            GetComponent<EnemyStateManager>().Die();
        }
    }
}
