using UnityEngine;

public abstract class AbstractMovement {
    
    protected float _speed;
    protected Transform _target;
    protected Transform _ownerTransform;
    protected Rigidbody2D _rigidbody2D;

    public void Init(float speed ,Transform ownerTransform, Rigidbody2D rb) {
        SetSpeed(speed);
        _ownerTransform = ownerTransform;
        _rigidbody2D = rb;
    }

    public void SetTarget(Transform target) {
        _target = target;
    }
    
    public void SetSpeed(float speed) {
        _speed = speed;
    }

    public abstract void Move();
}