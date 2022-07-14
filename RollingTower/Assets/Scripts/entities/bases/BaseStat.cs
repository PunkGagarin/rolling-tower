using System;
using UnityEngine;

public abstract class BaseStat<S, T> : IUnitStat<T> {

    public Action<float> OnValueChange = delegate { };

    [field: SerializeField]
    public float currentValue { get; private set; }

    protected float _maxValue;
    
    protected T _type;


    public abstract S Init(T type);

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

    public bool isMaxValue() {
        return currentValue >= _maxValue;
    }

    public T getStatType() {
        return _type;
    }

    public float getCurrentValue() {
        return currentValue;
    }
}