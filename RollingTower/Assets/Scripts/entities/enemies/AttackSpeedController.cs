using System;
using UnityEngine;

public class AttackSpeedController<S,T> {
    private float _attackMaxTimer;
    private float _currentAttackTimer;

    private Action _attack;

    public void Init(BaseStat<S,T> stat, Action attack) {
        _attack = attack;
        SetProperAttackTime(stat, stat.currentValue);
        stat.OnValueChange += SetProperAttackTime;
    }
    
    public void TryAttack() {
        if (_currentAttackTimer <= 0) {
            _currentAttackTimer = _attackMaxTimer;
            _attack();
        }
    }

    public void Tick() {
        _currentAttackTimer -= Time.deltaTime;
    }
    
    private void SetProperAttackTime(BaseStat<S, T> stat, float value) {
        _attackMaxTimer = 10 / stat.currentValue;
        _currentAttackTimer = _attackMaxTimer;
    }
}