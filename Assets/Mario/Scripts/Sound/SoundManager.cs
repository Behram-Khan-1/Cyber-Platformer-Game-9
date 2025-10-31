using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [System.Serializable]
    public class Sound
    {
        public SoundType type;
        public AudioClip clip;
    }

    [Header("Assign all sound effects here")]
    public List<Sound> sounds = new List<Sound>();

    private Dictionary<SoundType, AudioClip> soundDict;
    private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        sfxSource = gameObject.AddComponent<AudioSource>();
        soundDict = new Dictionary<SoundType, AudioClip>();

        foreach (var s in sounds)
            soundDict[s.type] = s.clip;
    }

    public void PlaySound(SoundType type)
    {
        if (!CanPlaySound(type))
            return;

        moveTimer = movementSoundTimer;

        if (soundDict.ContainsKey(type))
            sfxSource.PlayOneShot(soundDict[type]);
        else
            Debug.LogWarning("Sound not found: " + type);
    }
    private float movementSoundTimer = 0.5f;
    private float moveTimer = 0.5f;

    private bool CanPlaySound(SoundType sound)
    {
        switch (sound)
        {
            case SoundType.Movement:
                moveTimer -= Time.deltaTime;
                return moveTimer <= 0;
            default:
                return true;
        }
    }

    public enum SoundType
    {
        Movement,
        Jump,
        Punch,
        Parry,
        PlayerHurt,
        PlayerDie,

        Money,
        Chest,
        EnemyHurt,
        EnemyDeath,
        Landing,
        Text

    }

}
