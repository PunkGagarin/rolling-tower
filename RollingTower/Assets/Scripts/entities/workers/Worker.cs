using entities.bases;
using UnityEngine;

[RequireComponent(typeof(WorkerStats))]
public class Worker : HealthUnit<WorkerStatType, WorkerStats, WorkerStat>, IDamageable {
    private WorkerStatesController _statesController;
    
    protected override WorkerStat getHealth() {
        return _stats.getAllStats()[WorkerStatType.Health];
    }

    private void Start() {
        _statesController.Init(this);
    }

    private void Update() {
        _statesController.Tick();
    }

    public Transform currentTransform => transform;
    public WorkerStats Stats => _stats;
}