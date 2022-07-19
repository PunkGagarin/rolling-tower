using UnityEngine;

public class TargetedProjectile : AbstractProjectile {

    private IDamageable _damageableTarget;
    private float _damage;

    public void Init(IDamageable damageableTarget, float speed, float stopDistance, Transform target) {
        InitDefaultStats(speed, stopDistance, target);
        _damageableTarget = damageableTarget;
    }

    protected override void ProjectileMove() {
        var speed = _speed * Time.deltaTime;
        var targetPos = _targetTransform.position;
        var ownPos = transform.position;
        transform.position = Vector3.MoveTowards(ownPos, targetPos, speed);
        
        var direction = targetPos - ownPos;
        float directionMagnitude = direction.sqrMagnitude;

        LookAtPos(direction);
        
        if (directionMagnitude < _stopDistance) {
            Hit();
        }
    }

    protected override void Hit() {
        //_damageableTarget.TakeDamage(_damage);
        _isMove = false;
        Destroy(gameObject);
    }
}