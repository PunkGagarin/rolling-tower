using System;

[Serializable]
public class WorkerStat : BaseStat<WorkerStat, WorkerStatType> {

    public override WorkerStat Init(WorkerStatType type) {
        _maxValue = currentValue;
        _type = type;
        return this;
    }
}