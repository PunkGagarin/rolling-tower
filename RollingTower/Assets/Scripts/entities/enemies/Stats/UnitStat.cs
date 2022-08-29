using System;

[Serializable]
public class UnitStat : BaseStat<UnitStat, UnitStatType> {

    public override UnitStat Init(UnitStatType type) {
        _maxValue = currentValue;
        _type = type;
        return this;
    }
}