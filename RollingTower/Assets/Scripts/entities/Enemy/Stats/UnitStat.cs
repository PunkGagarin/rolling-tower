using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class UnitStat : BaseStat<UnitStat, UnitStatType> {
    public Action<float> OnValueChange = delegate { };

    [field: SerializeField]
    public float currentValue { get; set; }
    

    protected float _maxValue;

    public override UnitStat Init(UnitStatType type) {
        _maxValue = currentValue;
        this.type = type;
        return this;
    }

    public void DecreaseCurrentValue(float value) {
        currentValue -= value;
        if (currentValue < 0) {
            currentValue = 0;
        }
        OnValueChange?.Invoke(currentValue);
    }

    public void IncreaseCurrentValue(float value) {
        currentValue += value;
        if (currentValue > _maxValue) {
            currentValue = _maxValue;
        }
        OnValueChange?.Invoke(currentValue);
    }

}

public abstract class BaseStat<S, T> : MonoBehaviour {

    public abstract S Init(T type);
    
    public virtual T type { get; protected set; }
    
    
}