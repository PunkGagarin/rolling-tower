using entities.player.towers;
using enums.towers;
using UnityEngine;

//todo: think about realization (maybe try to combine some of this logic with enemy projectile)
public class VectorTower : Tower {
    [SerializeField]
    private VectorProjectile _vectorProjectile;

    protected override void Attack() {
        var projectile = Instantiate(_vectorProjectile);
        projectile.transform.SetPositionAndRotation(_firePoint.position, transform.rotation);
        projectile.Init(this, LayerMask.NameToLayer(GameConstants.ENEMY_LAYER), _stats.getStatByType(TowerStatType.ProjectileSpeedMultiplier).currentValue);
    }
}