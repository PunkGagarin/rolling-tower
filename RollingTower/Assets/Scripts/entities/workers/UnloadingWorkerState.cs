using UnityEngine;

public class UnloadingWorkerState : BaseWorkerState {
    private WorkerStat _currentBackPackFill;
    private WorkerStat _unloadingSpeed;
    private float _timer;

    public UnloadingWorkerState(Worker owner) : base(owner) {}
    
    public override void Tick() {
        UnloadingResource();
    }

    private void UnloadingResource() {
        if (_timer <= 0) {
            _currentBackPackFill.DecreaseCurrentValue(1);
            _timer = _unloadingSpeed.currentValue;
        }
        _timer -= Time.deltaTime;
    }

    public override void Start() {
        _currentBackPackFill = _owner.Stats.getStatByType(WorkerStatType.CurrentBackPackFill);
        _unloadingSpeed = _owner.Stats.getStatByType(WorkerStatType.UnloadingSpeed);
        _timer = _unloadingSpeed.currentValue;
    }

    public override void CheckOnTransitionConditions() {
        if (_owner.Stats.getStatByType(WorkerStatType.CurrentBackPackFill).currentValue <= 0) {
            _stateSwitcher.SwitchState<GoingToResourceWorkerState>();
        }
    }
}