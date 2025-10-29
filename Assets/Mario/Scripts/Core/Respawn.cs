using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 position;
    public int health;
    public int money;
    bool isSetup = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isSetup == false)
        {
            position = collision.gameObject.transform.position;
            health = collision.gameObject.GetComponent<CharacterBase>().health;
            money = collision.gameObject.GetComponent<CharacterBase>().money;

            RespawnManager.instance.respawn = this;

            isSetup = true;
        }
    }
}
