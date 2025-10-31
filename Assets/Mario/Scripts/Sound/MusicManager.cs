using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource musicSource;
    private Coroutine currentFade;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

    public void PlayMusic(AudioClip newClip, float fadeDuration = 1.5f)
    {
        if (musicSource.clip == newClip) return;

        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeToNewTrack(newClip, fadeDuration));
    }

    private IEnumerator FadeToNewTrack(AudioClip newClip, float fadeDuration)
    {
        Debug.Log("Fading music");
        float startVolume = musicSource.volume;

        // Fade out current music
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        musicSource.clip = newClip;
        Debug.Log("Playing new music");
        musicSource.Play();

        // Fade in new track
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }

        musicSource.volume = 1;
    }
}
