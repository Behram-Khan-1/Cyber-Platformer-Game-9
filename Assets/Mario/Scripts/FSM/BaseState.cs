
public abstract class BaseState
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void GetNextState();


    public abstract void OnTriggerEnter();
    public abstract void OnTriggerExit();
    public abstract void OnTriggerStay();

}
