public abstract class AbstractUnitAttack {

    protected float _damage;

    public void Init(float damage) {
        SetDamage(damage);

    }
    
    public void SetDamage(float damage) {
        _damage = damage;
    }

    public abstract void Attack(IDamageable _target);
}