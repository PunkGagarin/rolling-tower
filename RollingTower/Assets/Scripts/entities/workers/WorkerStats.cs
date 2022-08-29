using entities.bases;
using UnityEngine;

public class WorkerStats : BaseStats<WorkerStatType, WorkerStat> {

    [SerializeField]
    private WorkerStat _health;

    [SerializeField]
    private WorkerStat _moveSpeed;

    [SerializeField]
    private WorkerStat _capacity;
    [SerializeField]
    private WorkerStat _extractingSpeed;

    [SerializeField]
    private WorkerStat _unloadingSpeed;

    protected override void InitStats() {
        allStats.Add(WorkerStatType.Health, _health.Init(WorkerStatType.Health));
        allStats.Add(WorkerStatType.MoveSpeed, _moveSpeed.Init(WorkerStatType.MoveSpeed));
        allStats.Add(WorkerStatType.Capacity, _capacity.Init(WorkerStatType.Capacity));
        allStats.Add(WorkerStatType.ExtractingSpeed, _extractingSpeed.Init(WorkerStatType.ExtractingSpeed));
        allStats.Add(WorkerStatType.UnloadingSpeed, _unloadingSpeed.Init(WorkerStatType.UnloadingSpeed));
    }
}