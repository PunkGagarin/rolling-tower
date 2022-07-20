using UnityEngine;

public abstract class AbstractProjectileDTO {
    public IDamageDealer damageDealer { get; private set; }
    public LayerMask targetLayer { get; private set; }
    public float moveSpeedMultiplier { get; private set; }

    protected AbstractProjectileDTO(IDamageDealer damageDealer, LayerMask targetLayer, float moveSpeedMultiplier) {
        this.damageDealer = damageDealer;
        this.targetLayer = targetLayer;
        this.moveSpeedMultiplier = moveSpeedMultiplier;
    }
}