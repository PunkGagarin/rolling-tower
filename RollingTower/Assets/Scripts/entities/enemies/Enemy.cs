using entities.bases;
using entities.player.citadels;
using UnityEngine;

namespace entities.enemies {

    [RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
    public abstract class Enemy : HealthUnit<UnitStatType, EnemyStats, UnitStat>, IDamageable, IDamageDealer {
        private EnemyMoveType _enemyMoveType;

        [SerializeField]
        private EnemyUnitType _enemyUnitType;
        
        [SerializeField]
        protected Transform _firePoint;
        
        protected Transform _citadel;

        protected virtual void Start() {
            _citadel = Citadel.GetInstance.transform;
        }

        protected override UnitStat getHealth() {
            return _stats.getAllStats()[UnitStatType.Health];
        }
        
        //todo: already have same logic in Tower.cs think about composition
        public void DealDamage(IDamageable damageableTarget) {
            float enemyDamage = _stats.getStatByType(UnitStatType.Damage).currentValue;
            Debug.Log("Deal damage to : " + enemyDamage);
            damageableTarget.TakeDamage(enemyDamage);
        }

        public EnemyUnitType enemyUnitType => _enemyUnitType;
        
        public Transform currentTransform => transform;
    }
}