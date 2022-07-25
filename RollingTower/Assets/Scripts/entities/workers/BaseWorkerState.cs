public abstract class BaseWorkerState {

    protected Worker _owner;
    protected IStateSwitcher<BaseWorkerState> _stateSwitcher;

    public BaseWorkerState(Worker owner) {
        _owner = owner;
    }

    public abstract void Tick();

    public virtual void Stop(){}
    public virtual void Start(){}

    public abstract void CheckOnTransitionConditions();
}