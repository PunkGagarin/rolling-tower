using entities.enemies.Movement;
using UnityEngine;

public class GoblinWithBow : EnemyBehaviours<RangeVectorAttackBehaviour, SimpleStraightMoveTranslateBehaviour<UnitStat, UnitStatType>> {
    
    [SerializeField]
    protected VectorProjectile _projectile;

    protected override void InitAttackBehaviour() {
        _attackBehaviour = new RangeVectorAttackBehaviour();
        _attackBehaviour.Init(_projectile, _firePoint, this, _stats.getStatByType(UnitStatType.ProjectileSpeed).currentValue, LayerMask.NameToLayer(GameConstants.CITADEL_LAYER));
    }

    protected override void InitMoveBehaviour() {
        _moveBehaviour = new SimpleStraightMoveTranslateBehaviour<UnitStat, UnitStatType>();
        _moveBehaviour.Init(_stats.getStatByType(UnitStatType.MoveSpeed), transform, _citadel.transform);
    }
}