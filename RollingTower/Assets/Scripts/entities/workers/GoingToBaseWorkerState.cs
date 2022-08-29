
public class GoingToBaseWorkerState : BaseWorkerState {

    protected override void InitSpecificState() {
        type = WorkerStateType.GoingToBase;
    }
    
    public override void Start() {
        _movement.SetTarget(_citadel.transform);
    }

    public override void Tick() {
        _movement.Move();
    }

    public override void CheckOnTransitionConditions() {
        if (_movement.IsOwnerInRangeOfTarget(2.5f)) {
            _stateSwitcher.SwitchState<UnloadingWorkerState>();
        }
    }
}