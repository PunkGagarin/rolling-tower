using UnityEngine;

public class TargetedProjectileDto : AbstractProjectileDTO{
    public IDamageable damageableTarget { get; private set; }
    public float damage { get; private set; }
    
    public TargetedProjectileDto(IDamageable damageableTarget ,float damage ,IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier) : base(damageDealer, targetLayer, moveSpeedMultiplier) {
        this.damageableTarget = damageableTarget;
        this.damage = damage;
    }
}