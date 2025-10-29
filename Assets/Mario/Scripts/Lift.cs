using System.Collections;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public int liftSpeed = 3;
    public Transform liftTopHeight;
    Vector2 liftBottomHeight;
    public Transform liftObject;
    private Rigidbody2D rb;

    bool IsGoingUp = false;
    Vector2 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        liftBottomHeight = liftObject.transform.position;
        rb = liftObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (IsGoingUp)
        {
            target = liftTopHeight.position;
        }
        if (!IsGoingUp)
        {
            target = liftBottomHeight;
        }

        if (Vector2.Distance(liftObject.position, target) < 0.1f)
        {
            return;
        }

        Vector2 newPos = Vector2.MoveTowards(rb.position, target, liftSpeed * Time.fixedDeltaTime); // cuz transfrom movement has jittering
        rb.MovePosition(newPos);



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(WaitForSeconds());
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1.5f);
        IsGoingUp = !IsGoingUp;
    }
}
