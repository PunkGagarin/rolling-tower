using UnityEngine;

public class UnloadingWorkerState : BaseWorkerState {
    private WorkerStat _unloadingSpeed;
    private float _timer;
    private bool _isUnloading;

    protected override void InitSpecificState() {
        type = WorkerStateType.ResourceUnloading;
        _unloadingSpeed = _owner.Stats.getStatByType(WorkerStatType.UnloadingSpeed);
    }

    public override void Tick() {
        UnloadingResource();
    }
    
    public override void Start() {
        _isUnloading = true;
        _timer = _unloadingSpeed.currentValue;
        _owner.backPack.OnEmpty += IsNeedToChangeState;
        if (_owner.backPack.IsEmpty()) {
            _isUnloading = false;
        }
    }

    private void UnloadingResource() {
        if(!_isUnloading) return;
        if (_timer <= 0) {
            _inGameResourceStorage.AddResourceToStorage(_owner.backPack.GetResource());
            _timer = _unloadingSpeed.currentValue;
        }
        _timer -= Time.deltaTime;
    }

    public override void CheckOnTransitionConditions() {
        if (!_isUnloading) {
            if (_owner.IsEndHisWork || _owner.currentResourceSource == null) {
                _stateSwitcher.SwitchState<EndWorkerState>();
            } else {
                _stateSwitcher.SwitchState<FindingResourcePlaceWorkerState>();       
            }
        }
    }
    
    private void IsNeedToChangeState() {
        _isUnloading = false;
    }
    
    public override void Stop() { ;
        _owner.backPack.OnEmpty -= IsNeedToChangeState;
    }
}