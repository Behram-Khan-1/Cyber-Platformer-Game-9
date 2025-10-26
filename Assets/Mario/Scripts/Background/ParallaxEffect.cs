using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPosX;//starting position of objects
    public GameObject cam;
    public float parallaxEffect;//how much parallax we want
    private float length; //length of current sprite
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosX = transform.position.x;
        // startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        float distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosX + distance, transform.position.y, transform.position.z);

        if (movement < startPosX - length)
        {
            startPosX -= length;
        }
        else if (movement > startPosX + length)
        {
            startPosX += length;
        }
    }
}
