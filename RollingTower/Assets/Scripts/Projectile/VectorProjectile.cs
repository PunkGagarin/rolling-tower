using entities.enemies;
using UnityEngine;

public class VectorProjectile : AbstractProjectile {
    private float _lifeTime;
    
    public void Init(IDamageable damageableTarget, float speed, float stopDistance, Transform target) {
        InitDefaultStats(speed, stopDistance, target);
        Invoke(nameof(DestroyProjectile), _lifeTime);
    }
    
    protected override void ProjectileMove() {
        transform.Translate(Vector2.up * (_speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == _targetLayer) {
            Hit();
            // Debug.Log("We hit an enemy");
            
            
        }
    }

    protected override void Hit() {
        _isMove = false;
        DestroyProjectile();
        //_towerOwner.DamageEnemy(collider.gameObject.GetComponent<IDamageable>());
    }
}