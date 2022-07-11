
public class MeleeAttackBehaviour : AbstractUnitAttack {
    
    public override void Attack(IDamageable target) {
        target.TakeDamage(_damage);
    }
}