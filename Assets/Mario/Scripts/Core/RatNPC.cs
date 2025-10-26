using System.Collections;
using UnityEngine;

public class RatNPC : MonoBehaviour, IUsable
{
    public float speed = 5f;
    public Transform childText;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("Walk") == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void Use()
    {
        Debug.Log("Used");
        if (CharacterBase.instance.money >= 50)
        {
            StoryManager.instance.RatGateOpen();
            CharacterBase.instance.AddMoney(-50); //reduce money
            anim.SetBool("Walk", true);
            Destroy(childText.gameObject);
            StartCoroutine(DestoryAfterSeconds(5f));
        }
        else
        {
            //Play Attack Animation and scream
        }
    }

    IEnumerator DestoryAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
