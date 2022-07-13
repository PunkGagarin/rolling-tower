using System;
using UnityEngine;

[System.Serializable]
public class Stat {
    public Action<float> OnValueChange = delegate {};

    [SerializeField]
    private float _currentValue;

    private float _maxValue;


    public Stat Init(EnemyStatType type) {
        _maxValue = _currentValue;
        Type = type;
        return this;
    }

    public void DecreaseCurrentValue(float value) {
        _currentValue -= value;
        if (_currentValue < 0) {
            _currentValue = 0;
        }
        OnValueChange?.Invoke(_currentValue);
    }

    public void IncreaseCurrentValue(float value) {
        _currentValue += value;
        if (_currentValue > _maxValue) {
            _currentValue = _maxValue;
        }
        OnValueChange?.Invoke(_currentValue);
    }
    
    public EnemyStatType Type { get; private set; }

    public float CurrentValue => _currentValue;
}