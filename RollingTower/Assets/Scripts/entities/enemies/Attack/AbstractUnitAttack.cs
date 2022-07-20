public abstract class AbstractUnitAttack {

    protected float _damage;

    public void Init(float damage) {
        _damage = damage; 
    }
    
    public void SetDamage(BaseStat<UnitStat, UnitStatType> stat) {
        _damage = stat.currentValue;
    }

    public abstract void Attack(IDamageable _target);
}