using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour {
    [SerializeField]
    protected float _speed;
    
    protected bool _isMoving = true;
    protected LayerMask _targetLayer;
    protected IDamageDealer _damageDealer;
    protected float _moveSpeedMultiplier;

    protected void InitBaseProjectile(IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier) {
        _damageDealer = damageDealer;
        _targetLayer = targetLayer;
        _moveSpeedMultiplier = moveSpeedMultiplier;
    }

    protected abstract void ProjectileMove();

    private void Update() {
        if (_isMoving) {
            ProjectileMove();
        }
    }

    protected float CalculateSpeed() {
        return _speed * _moveSpeedMultiplier * Time.deltaTime;
    }
    
    protected void DestroyProjectile() {
        Destroy(gameObject);
    }

    protected void DamageTargetAndDestroyMyself(IDamageable _damageableTarget) {
        _damageDealer.DealDamage(_damageableTarget);
        _isMoving = false;
        DestroyProjectile();
    }

    protected abstract void Hit();
}