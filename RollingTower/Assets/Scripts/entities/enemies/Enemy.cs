using System;
using entities.bases;
using entities.player.citadels;
using gameSession.factories;
using UnityEngine;
using Zenject;

namespace entities.enemies {

    [RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
    public abstract class Enemy : HealthUnit<UnitStatType, EnemyStats, UnitStat>, IDamageable, IDamageDealer, IType<EnemyUnitType> {
        
        public new Action<Enemy> OnDie = delegate { };
        
        private EnemyMoveType _enemyMoveType;

        [SerializeField]
        private EnemyUnitType _enemyUnitType;
        
        [SerializeField]
        protected Transform _firePoint;
        
        [Inject]
        protected Citadel _citadel;

        protected virtual void Start() {
            // _citadel = Citadel.GetInstance.transform;
        }

        protected override UnitStat getHealth() {
            return _stats.getAllStats()[UnitStatType.Health];
        }

        protected override void Die() {
            OnDie.Invoke(this);
            base.Die();
            Destroy(gameObject);
        }

        //todo: already have same logic in Tower.cs think about composition
        public void DealDamage(IDamageable damageableTarget) {
            float enemyDamage = _stats.getStatByType(UnitStatType.Damage).currentValue;
            Debug.Log("Deal damage to : " + enemyDamage);
            damageableTarget.TakeDamage(enemyDamage);
        }

        public EnemyUnitType getType() {
            return _enemyUnitType;
        }

        public EnemyUnitType enemyUnitType => _enemyUnitType;
        
        public Transform currentTransform => transform;
    }
}