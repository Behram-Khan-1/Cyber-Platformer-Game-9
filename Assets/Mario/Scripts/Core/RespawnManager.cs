using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;
    public Respawn respawn;
    public CharacterBase player;

    void Awake()
    {
        instance = this;
    }
    
    public void OnPlayerDeath()
    {
        player.transform.position = respawn.position;
        player.SetHealth(respawn.health);
        player.SetMoney(respawn.money);
    }
}
