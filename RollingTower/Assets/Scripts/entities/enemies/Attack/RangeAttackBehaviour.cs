using UnityEngine;

public abstract class RangeAttackBehaviour : AbstractUnitAttack{
    protected Transform _firePoint;
    protected float _projectileSpeedMultiplier;
    protected LayerMask _targetLayer;

    protected void InitRange(Transform firePoint, float projectileSpeedMultiplier, IDamageDealer damageDealer, LayerMask targetLayer) {
        _damageDealer = damageDealer;
        _firePoint = firePoint;
        _projectileSpeedMultiplier = projectileSpeedMultiplier;
        _targetLayer = targetLayer;
    }
}