using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DestroyLevel(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void PlayerDied()
    {
        //Play Death Screen waitfor 3 seconds and respawn.
        RespawnManager.instance.OnPlayerDeath();
    }
    

}
