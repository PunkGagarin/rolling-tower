using entities.player.citadels;
using UnityEngine;

public abstract class BaseWorkerState {
    public WorkerStateType type { get; protected set; }
    protected Worker _owner;
    protected AbstractMovement<WorkerStat, WorkerStatType> _movement;
    protected Transform _citadel;
    protected InGameResourceStorage _inGameResourceStorage;

    protected IStateSwitcher<BaseWorkerState> _stateSwitcher;

    public void InitBase(Worker owner, IStateSwitcher<BaseWorkerState> stateSwitcher, AbstractMovement<WorkerStat, WorkerStatType> movement, Transform citadel, InGameResourceStorage inGameResourceStorage) {
        _owner = owner;
        _stateSwitcher = stateSwitcher;
        _movement = movement;
        _citadel = citadel;
        _inGameResourceStorage = inGameResourceStorage;
        InitSpecificState();
    }

    protected virtual void InitSpecificState() {
    }

    public abstract void Tick();

    public virtual void Stop(){}
    public virtual void Start(){}

    public abstract void CheckOnTransitionConditions();
}