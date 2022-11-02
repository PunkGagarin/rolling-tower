using System;
using entities.bases;
using entities.enemies.Movement;
using UnityEngine;

[RequireComponent(typeof(WorkerStats))]
public class Worker : HealthUnit<WorkerStatType, WorkerStats, WorkerStat>, IDamageable {

    [SerializeField]
    private WorkerStateType _startState;

    [SerializeField]
    private WorkerView _workerView;

    private readonly WorkerStatesController _statesController = new();
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
        _workerView.SpawnWorkerView(backPack, resourceSource.resourceIcon);
    }

    private void Update() {
        _statesController.Tick();
        _workerView.Tick();
    }

    public void FindAndSetNewResourceSource() {
        var resourceSource = _sourceHolder.GetFreeResourceSourceByType(_extractingResourceType);
        if (resourceSource != null) {
            currentResourceSource = resourceSource;
        } else {
            throw new Exception($"Resource source {_extractingResourceType} not found");
        }
        
    }

    public void ReturnToBase() {
        _statesController.SwitchState<GoingToBaseWorkerState>();
        IsEndHisWork = true;
    }

    public void EndOfWork() {
        _workerView.DestroyHud();
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