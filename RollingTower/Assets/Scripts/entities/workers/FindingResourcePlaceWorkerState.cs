public class FindingResourcePlaceWorkerState : BaseWorkerState {
    private ResourceSourceHolder _sourceHolder;

    protected override void InitSpecificState() {
        _sourceHolder = ResourceSourceHolder.GetInstance;
        type = WorkerStateType.FindingResourcePlace;
    }

    public override void Tick() {
        //nothing
    }

    public override void Start() {
        _owner.FindAndSetNewResourceSource();
    }

    public override void CheckOnTransitionConditions() {
        if (_owner.currentResourceSource == null) {
            _stateSwitcher.SwitchState<GoingToBaseWorkerState>();
        } else {
            _stateSwitcher.SwitchState<GoingToResourceWorkerState>();
        }
    }
}