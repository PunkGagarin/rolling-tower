using UnityEngine;

public class RangeVectorAttackBehaviour : RangeAttackBehaviour{

    private VectorProjectile _projectile;

    public void Init(VectorProjectile vectorProjectile ,Transform firePoint, IDamageDealer damageDealer, float projectileSpeedMultiplier, LayerMask targetLayer) {
        InitRange(firePoint, projectileSpeedMultiplier, damageDealer, targetLayer);
        _damageDealer = damageDealer;
        _projectile = vectorProjectile;
    }

    public override void Attack() {
        var projectile = GameObject.Instantiate(_projectile);
        projectile.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        projectile.Init(_damageDealer, _targetLayer,  _projectileSpeedMultiplier);
    }
}