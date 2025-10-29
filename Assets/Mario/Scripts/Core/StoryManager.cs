using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;
    //TUTORIAL NPC AND Pipe
    public BoxCollider2D tutorialEndPipe;
    [SerializeField] Transform RatGate;
    [SerializeField] Transform TutorialGate;
    [SerializeField] Transform TrapRoomGate;



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
    public void OpenTutorialGate()
    {
        TutorialGate.gameObject.GetComponent<GateOpen>().PlayAnimation();
    }

    public void EndTutorial()
    {
        tutorialEndPipe.enabled = true;
    }
    public void RatGateOpen()
    {
        RatGate.gameObject.GetComponent<GateOpen>().PlayAnimation();
    }
    public void TrapRoomGateOpen()
    {
        TrapRoomGate.gameObject.GetComponent<GateOpen>().PlayAnimation();
    }
}
