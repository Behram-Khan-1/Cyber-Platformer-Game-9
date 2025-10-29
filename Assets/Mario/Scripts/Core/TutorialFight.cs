using System;
using UnityEngine;

public class TutorialFightStateManager : EnemyStateManager
{
    public int requiredHits = 3;
    public int hitCount = 0;
    public int requiredParries = 3;
    public int parryCount = 0;

    void Awake()
    {
        base.Awake();
    }

    public void RegisterHit()
    {
        hitCount++;
        CheckCompletion();
    }

    public void RegisterParry()
    {
        parryCount++;
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        if (hitCount >= requiredHits && parryCount >= requiredParries)
        {
            // Tutorial completed - open the gate
            StoryManager.instance.OpenTutorialGate();

            // Optional: Disable this enemy or play death animation
            Destroy(gameObject);
        }
    }

}
