using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;
    public bool isPlayerPaused { get;  private set; } = false;
    public event Action<bool> OnPause;

    void Awake()
    {
        instance = this;
    }

    public void TogglePause(bool pause)
    {
        if (pause == isPlayerPaused) return;
        isPlayerPaused = pause;
        OnPause?.Invoke(isPlayerPaused);
    }

}
