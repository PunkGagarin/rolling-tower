using UnityEngine;

public class TargetedProjectile : AbstractProjectile {
    [SerializeField]
    private float _stopDistance;
    
    private IDamageable _damageableTarget;

    public void Init(IDamageable damageableTarget ,IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier) {
        InitBaseProjectile(damageDealer, targetLayer, moveSpeedMultiplier);
        _damageableTarget = damageableTarget;
    }

    protected override void ProjectileMove() {
        var speed = _speed * Time.deltaTime;
        var targetPos = _damageableTarget.currentTransform.position;
        var ownPos = transform.position;
        var stepLength = speed * _moveSpeedMultiplier * Time.deltaTime;
        transform.position = Vector3.MoveTowards(ownPos, targetPos, stepLength);
        
        var direction = targetPos - ownPos;
        float directionMagnitude = direction.sqrMagnitude;

        LookAtPos(direction);
        
        if (directionMagnitude < _stopDistance) {
            Hit();
        }
    }

    protected override void Hit() {
        _damageDealer.DealDamage(_damageableTarget);
        _isMove = false;
        Destroy(gameObject);
    }
}