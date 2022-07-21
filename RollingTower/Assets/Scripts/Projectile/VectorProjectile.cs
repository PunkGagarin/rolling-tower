using UnityEngine;

public class VectorProjectile : AbstractProjectile {
    [SerializeField]
    private float _lifeTime;
    
    private IDamageable _damageableTarget;

    public void Init(IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier){
        InitBaseProjectile(damageDealer, targetLayer, moveSpeedMultiplier);
        Invoke(nameof(DestroyProjectile), _lifeTime);
    }

    protected override void ProjectileMove() {
        transform.Translate(Vector2.up * (_speed * _moveSpeedMultiplier * Time.deltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == _targetLayer) {
            _damageableTarget = other.gameObject.GetComponent<IDamageable>();
            Hit();
        }
    }

    protected override void Hit() {
        _damageDealer.DealDamage(_damageableTarget);
        _isMove = false;
        DestroyProjectile();
    }
}