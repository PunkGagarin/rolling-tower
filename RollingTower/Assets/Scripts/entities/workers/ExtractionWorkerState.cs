using UnityEngine;

public class ExtractionWorkerState : BaseWorkerState {
    private WorkerStat _capacity;
    private WorkerStat _currentBackPackFill;
    private WorkerStat _extractingSpeed;
    private float _timer;

    public ExtractionWorkerState(Worker owner) : base(owner) {}

    public override void Tick() {
        ExtractResource();
    }

    private void ExtractResource() {
        if (_timer <= 0) {
            _capacity.IncreaseCurrentValue(1);
            _timer = _extractingSpeed.currentValue;
        }
        _timer -= Time.deltaTime;
    }

    public override void Start() {
        _capacity = _owner.Stats.getStatByType(WorkerStatType.Capacity);
        _currentBackPackFill = _owner.Stats.getStatByType(WorkerStatType.CurrentBackPackFill);
        _extractingSpeed = _owner.Stats.getStatByType(WorkerStatType.ExtractingSpeed);
        _timer = _extractingSpeed.currentValue;
    }

    public override void CheckOnTransitionConditions() {
        if (_currentBackPackFill.currentValue >= _capacity.currentValue) {
            _stateSwitcher.SwitchState<GoingToBaseWorkerState>();
        }
    }
}