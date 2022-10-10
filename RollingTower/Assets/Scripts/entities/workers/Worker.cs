using entities.bases;
using entities.enemies.Movement;
using UnityEngine;

[RequireComponent(typeof(WorkerStats))]
public class Worker : HealthUnit<WorkerStatType, WorkerStats, WorkerStat>, IDamageable {

    [SerializeField]
    private WorkerStateType _startState;

    [SerializeField]
    private WorkerHudUI _workerHudPrefab;

    private WorkerHudUI _workerHud;

    private WorkerStatesController _statesController = new();
    private AbstractMovement<WorkerStat, WorkerStatType> _movement;
    private ResourceSourceHolder _sourceHolder;
    private ResourceType _extractingResourceType;

    public WorkerBackPack backPack { get; private set; }
    public ResourceSource currentResourceSource { get; private set; }

    public bool IsEndHisWork { get; private set; }

    public void Init(ResourceType resourceType) {
        _extractingResourceType = resourceType;
        _sourceHolder = ResourceSourceHolder.GetInstance;
        backPack = new WorkerBackPack(_stats.getStatByType(WorkerStatType.Capacity));
        _movement = new SimpleStraightMoveTranslateBehaviour<WorkerStat, WorkerStatType>();
        _movement.Init(_stats.getStatByType(WorkerStatType.MoveSpeed), transform, transform);

        InitStatesAndWorkerHud(resourceType);
    }

    private void InitStatesAndWorkerHud(ResourceType resourceType) {
        var resourceSource = ResourceSourceHolder.GetInstance.GetResourceSourceByType(resourceType);
        _statesController.Init(this, _movement, _startState);

        _workerHud = Instantiate(_workerHudPrefab, WorkersUIHudHolder.GetInstance.transform);
        _workerHud.Init(transform, backPack, resourceSource.resourceIcon);
    }

    private void Update() {
        _statesController.Tick();
        _workerHud.SetPosition();
    }

    public void FindAndSetNewResourceSource() {
        var test = _sourceHolder.GetFreeResourceSourceByType(_extractingResourceType);

        Debug.Log(test);
        currentResourceSource = test;
    }

    public void ReturnToBase() {
        _statesController.SwitchState<GoingToBaseWorkerState>();
        IsEndHisWork = true;
    }

    public void EndOfWork() {
        Destroy(_workerHud.gameObject);
        Destroy(gameObject);
    }

    protected override void Die() {
        base.Die();
        _statesController.SwitchState<DieWorkerState>();
    }

    protected override WorkerStat getHealth() {
        return _stats.getAllStats()[WorkerStatType.Health];
    }

    public Transform currentTransform => transform;
    public WorkerStats Stats => _stats;

}