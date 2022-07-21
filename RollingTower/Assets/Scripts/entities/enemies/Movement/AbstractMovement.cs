using UnityEngine;

public abstract class AbstractMovement {
    
    protected float _speed;
    protected Transform _targetTransform;
    protected Transform _ownerTransform;
    protected Rigidbody2D _rigidbody2D;

    public void Init(UnitStat speedStat,Transform ownerTransform, Rigidbody2D rb, Transform target) {
        SetSpeed(speedStat.currentValue);
        speedStat.OnValueChange += SetSpeed;
        _ownerTransform = ownerTransform;
        _rigidbody2D = rb;
        _targetTransform = target;
    }

    public void SetTarget(Transform target) {
        _targetTransform = target;
    }
    
    private void SetSpeed(BaseStat<UnitStat, UnitStatType> stat) {
        _speed = stat.currentValue;
    }   
    private void SetSpeed(float speed) {
        _speed = speed;
    }

    public abstract void Move();
}