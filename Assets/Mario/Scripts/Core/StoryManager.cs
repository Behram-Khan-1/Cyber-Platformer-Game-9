using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    //TUTORIAL NPC AND Pipe
    public BoxCollider2D tutorialEndPipe;
    [SerializeField] Transform RatGate;
    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialEndPipe.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void EndTutorial()
    {
        tutorialEndPipe.enabled = true;
    }
    public void RatGateOpen()
    {
        RatGate.gameObject.SetActive(false);
    }
}
