using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MusicZone : MonoBehaviour
{
    public AudioClip zoneMusic;
    public float fadeDuration = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            MusicManager.Instance.PlayMusic(zoneMusic, fadeDuration);
    }
}
