using UnityEngine;

public abstract class AbstractMovement<S,ST> where S : BaseStat<S, ST> {
    
    protected float _speed;
    protected Transform _targetTransform;
    protected Transform _ownerTransform;

    public void Init(S speedStat,Transform ownerTransform, Transform target) {
        SetSpeed(speedStat.currentValue);
        speedStat.OnValueChange += SetSpeed;
        _ownerTransform = ownerTransform;
        _targetTransform = target;
    }

    public void SetTarget(Transform target) {
        _targetTransform = target;
    }
    
    private void SetSpeed(BaseStat<S,ST> stat, float valueDifference) {
        _speed = stat.currentValue;
    }   
    private void SetSpeed(float speed) {
        _speed = speed;
    }

    public abstract void Move();
    
    public bool IsOwnerInRangeOfTarget(float range) {
        var distance = _targetTransform.position - _ownerTransform.position;
        return distance.sqrMagnitude <= range * range;
    }
}