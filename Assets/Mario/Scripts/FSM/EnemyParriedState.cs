using UnityEngine;

public class EnemyParriedState : BaseState<EnemyStateType> 
{
    private EnemyStateManager manager;
    private float stunDuration;
    public EnemyParriedState(EnemyStateType key, EnemyStateManager manager) : base(key)
    {
        this.manager = manager;
    }
    public override void EnterState()
    {
        stunDuration = manager.player.GetComponent<CharacterParry>().StunDuration;

        manager.ActiveState = EnemyStateType.Parried;
        manager.animator.SetBool("IsParried", true);

        // Notify the TutorialFightStateManager if it exists
        if(manager is TutorialFightStateManager tutorialFightManager)
        {
            tutorialFightManager.RegisterParry();
        }
    }

    public override void ExitState()
    {
        manager.animator.SetBool("IsParried", false);
    }

    public override EnemyStateType GetNextState()
    {
        if (stunDuration <= 0)
        {
            return EnemyStateType.Idle;
        }
        return stateKey;
    }


    public override void UpdateState()
    {
        stunDuration -= Time.deltaTime;
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }


}
