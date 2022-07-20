public class MeleeAttackBehaviour : AbstractUnitAttack {
    
    public override void Attack(IDamageable target) {
        _damageDealer.DealDamage(target);
    }
}