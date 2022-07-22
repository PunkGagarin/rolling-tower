using System.Collections.Generic;
using Entities.Citadels.Towers;
using entities.enemies;
using enums.towers;
using UnityEngine;

namespace entities.player.towers {

    [RequireComponent(typeof(TowerStats))]
    public abstract class Tower : MonoBehaviour, IDamageDealer {

        [SerializeField]
        private AttackRadiusCollider _towerAttackRadiusCollider;

        [SerializeField]
        protected Transform _firePoint;

        private List<Enemy> _enemiesInRange = new();

        protected TowerStats _stats;

        private AttackSpeedController<TowerStat, TowerStatType> _attackSpeed = new();

        private void Awake() {
            _stats = GetComponent<TowerStats>();
            _towerAttackRadiusCollider = GetComponentInChildren<AttackRadiusCollider>(true);
        }

        private void Start() {
            _attackSpeed.Init(_stats.getStatByType(TowerStatType.AttackSpeed), Attack);
        }

        public void DealDamage(IDamageable damageableTarget) {
            float towerDamage = _stats.getStatByType(TowerStatType.Damage).currentValue;
            Debug.Log("Deal damage to enemy: " + towerDamage);
            damageableTarget.TakeDamage(towerDamage);
        }

        private void Update() {
            if (TargetIsInRadius()) {
                _attackSpeed.TryAttack();
            }
            _attackSpeed.Tick();
        }

        public void ChangeAttackRadius(BaseStat<TowerStat, TowerStatType> baseStat, float range) {
            Debug.Log("Changing from tower");
            _towerAttackRadiusCollider.ChangeRange(range);
        }

        private bool TargetIsInRadius() {
            return _enemiesInRange.Count > 0;
            // Enemy enemy = GetComponent<Enemy>();
            // var towerRange = _stats.getStatByType(TowerStatType.AttackRange);
            // return false;
        }


        public void AddEnemyInRange(Enemy enemyUnit) {
            _enemiesInRange.Add(enemyUnit);
        }

        public void RemoveEnemyInRange(Enemy enemyUnit) {
            _enemiesInRange.Remove(enemyUnit);
        }
        
        public void AddStatFromCitadel(TowerStatType type, TowerStat stat) {
            Debug.Log("Adding stat from citadel to tower: " + type + " " + stat.currentValue);
            var statToIncrease = _stats.getStatByType(type);
            Debug.Log("Stat before increasing: " + statToIncrease);
            statToIncrease.IncreaseMaxValue(stat.getCurrentValue());
            Debug.Log("Stat after increasing: " + statToIncrease);
        }
        
        public float GetProjectileSpeed() {
            return _stats.getStatByType(TowerStatType.ProjectileSpeed).currentValue;
        }
        
        protected abstract void Attack();
    }
}