using entities.enemies;
using entities.enemies.Movement;
using UnityEngine;

public class GoblinWithBow : Enemy {
    
    [SerializeField]
    protected VectorProjectile _projectile;

    protected override void InitAttackBehaviour() {
        _attackBehaviour = new RangeVectorAttackBehaviour();
        (_attackBehaviour as RangeVectorAttackBehaviour)?.Init(_projectile, _firePoint, this, _stats.getStatByType(UnitStatType.ProjectileSpeedMultiplier).currentValue, LayerMask.NameToLayer(GameConstants.CITADEL_LAYER));
    }

    protected override void InitMoveBehaviour() {
        _movementBehaviour = new SimpleStraightMoveTranslateBehaviour();
        _movementBehaviour.Init(_stats.getStatByType(UnitStatType.MoveSpeed), transform, GetComponent<Rigidbody2D>(), _citadel.transform);
    }
}