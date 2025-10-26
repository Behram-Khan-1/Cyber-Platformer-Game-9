using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialNPC : MonoBehaviour
{
    bool isInRange;
    public TextMeshProUGUI text;
    public List<String> dialouges;
    int i;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        i = 0;
        // Debug.Log(dialouges.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            Debug.Log("Press E");
            text.text = dialouges[i];
            i++;
        }

        if (i == dialouges.Count )
        {
            StoryManager.instance.EndTutorial();
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("NPC Trigger enter");
            text.text = "Press E";
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Debug.Log("NPC Trigger exit");
        isInRange = false;
    }


}
