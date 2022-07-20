public abstract class AbstractUnitAttack {
    
    protected IDamageDealer _damageDealer;

    public void Init(BaseStat<UnitStat, UnitStatType> stat, IDamageDealer damageDealer) {
        _damageDealer = damageDealer;
    }

    public abstract void Attack(IDamageable _target);
}