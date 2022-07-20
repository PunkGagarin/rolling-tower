using UnityEngine;

public class TargetedProjectile : AbstractProjectile {
    [SerializeField]
    private float _stopDistance;
    
    private IDamageable _damageableTarget;
    private float _damage;

    public override void Init(AbstractProjectileDTO projectileDto) {
        base.Init(projectileDto);
        var dto = ((TargetedProjectileDto) projectileDto);
        _damageableTarget = dto.damageableTarget;
        _damage = dto.damage;
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
        _damageableTarget.TakeDamage(_damage);
        _isMove = false;
        Destroy(gameObject);
    }
}