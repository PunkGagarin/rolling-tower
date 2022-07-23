using entities.player.towers;
using enums.towers;
using UnityEngine;

public class TargetTower : Tower {
    [SerializeField]
    private TargetedProjectile _targetedProjectile;

    //todo: get target from different place;
    private IDamageable _target;
    
    protected override void Attack() {
        var projectile = Instantiate(_targetedProjectile);
        projectile.transform.SetPositionAndRotation(_firePoint.position, transform.rotation);
        projectile.Init(_target, this,LayerMask.NameToLayer(GameConstants.ENEMY_LAYER), _stats.getStatByType(TowerStatType.ProjectileSpeed).currentValue);
    }
}