using UnityEngine;

public class ExtractionWorkerState : BaseWorkerState {
    private WorkerStat _extractingSpeed;
    private float _timer;
    private bool _isExtracting;
    private ResourceSource _resourceSource;

    protected override void InitSpecificState() {
        type = WorkerStateType.Extraction;
        _extractingSpeed = _owner.Stats.getStatByType(WorkerStatType.ExtractingSpeed);
    }
    
    public override void Start() {
        _resourceSource = _owner.currentResourceSource;
        _isExtracting = true;
        _timer = _extractingSpeed.currentValue;
        _resourceSource.OnEmpty += IsNeedToChangeState;
        _owner.backPack.OnFilled += IsNeedToChangeState;
    }

    public override void Tick() {
        ExtractResource();
    }

    private void ExtractResource() {
        if (_timer <= 0) {
            _owner.backPack.AddResource(_resourceSource.GetResource());
            _timer = _extractingSpeed.currentValue;
        }
        _timer -= Time.deltaTime;
    }

    public override void CheckOnTransitionConditions() {
        if(!_isExtracting)
            _stateSwitcher.SwitchState<GoingToBaseWorkerState>();
    }

    private void IsNeedToChangeState() {
        _isExtracting = false;
    }
    
    public override void Stop() {
        _resourceSource.OnEmpty -= IsNeedToChangeState;
        _owner.backPack.OnFilled -= IsNeedToChangeState;
    }
}