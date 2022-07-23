using UnityEngine;

public class TargetedProjectile : AbstractProjectile {
    [SerializeField]
    private float _stopDistance;
    
    private IDamageable _damageableTarget;
    private Vector3 _directionToTarget;
    private Vector3 _targetPos;
    private float _stepToMoveLenght;

    public void Init(IDamageable damageableTarget ,IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier) {
        InitBaseProjectile(damageDealer, targetLayer, moveSpeedMultiplier);
        _damageableTarget = damageableTarget;
    }

    protected override void ProjectileMove() {
        _targetPos = _damageableTarget.currentTransform.position;
        transform.position = Vector3.MoveTowards( transform.position, _targetPos, CalculateSpeed());
        _directionToTarget = _targetPos -  transform.position;
        float directionMagnitude = _directionToTarget.sqrMagnitude;

        LookAtTarget(_directionToTarget);
        
        if (directionMagnitude < _stopDistance * _stopDistance) {
            Hit();
        }
    }
    
    private void LookAtTarget(Vector2 directionToLook) {
        var angle = Mathf.Atan2(directionToLook.y, directionToLook.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    protected override void Hit() {
        DamageTargetAndDestroyMyself(_damageableTarget);
    }
}