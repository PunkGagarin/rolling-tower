
public class GoingToResourceWorkerState : BaseWorkerState {
    private bool _isSourceEmpty;
    private ResourceSource _resourceSource;
    
    protected override void InitSpecificState() {
        type = WorkerStateType.GoingToResource;
    }

    public override void Start() {
        _resourceSource = _owner.currentResourceSource;
        _isSourceEmpty = true;
        _movement.SetTarget(_resourceSource.transform);
        _resourceSource.OnEmpty += IsNeedToChangeState;
    }
    
    public override void Tick() {
        _movement.Move();
    }

    public override void CheckOnTransitionConditions() {
        if (!_isSourceEmpty) {
            _stateSwitcher.SwitchState<FindingResourcePlaceWorkerState>();
        }
        if (_movement.IsOwnerInRangeOfTarget(_resourceSource.extractRange)) {
            _stateSwitcher.SwitchState<ExtractionWorkerState>();
        }
    }
    
    private void IsNeedToChangeState() {
        _isSourceEmpty = false;
    }
}