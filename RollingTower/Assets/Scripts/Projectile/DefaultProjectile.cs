using UnityEngine;

public class DefaultProjectile : AbstractProjectile {

    private IDamageable _damageableTarget;
    private float _damage;

    public void Init(IDamageable damageableTarget, float speed, float stopDistance, Transform target) {
        InitDefaultStats(speed, stopDistance, target);
        _damageableTarget = damageableTarget;
    }

    protected override void Hit() {
        //_damageableTarget.TakeDamage(_damage);
        Debug.Log("TakeDamage "+ _damage);
        Destroy(gameObject);
    }
    
}