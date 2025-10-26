using UnityEngine;

public class TutorialEnd : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        var levelToDestory = this.gameObject.transform.root;
        GameManager.instance.DestroyLevel(levelToDestory.gameObject);
    }
}
