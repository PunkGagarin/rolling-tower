using System.Collections.Generic;
using entities.enemies;
using entities.player.citadels;
using enums.towers;
using UnityEngine;

namespace entities.player.towers {

    [RequireComponent(typeof(TowerStats))]
    public class Tower : MonoBehaviour {

        [SerializeField]
        private AttackRadiusCollider _towerAttackRadiusCollider;

        [SerializeField]
        private TowerProjectile _towerProjectile;

        [SerializeField]
        private Transform _firePoint;

        private List<Enemy> _enemiesInRange = new();

        private TowerStats _stats;

        private float _attackMaxTimer = 1f;
        private float _attackTimer = 1f;

        private void Awake() {
            _stats = GetComponent<TowerStats>();
            _towerAttackRadiusCollider = GetComponentInChildren<AttackRadiusCollider>(true);
            Debug.Log(_towerAttackRadiusCollider);
        }


        public void DamageEnemy(Enemy enemy) {
            float towerDamage = _stats.getStatByType(TowerStatType.Damage).currentValue;
            Debug.Log("Deal damage to enemy: " + towerDamage);
            enemy.TakeDamage(towerDamage);
        }

        private void Update() {
            if (TargetIsInRadius()) {
                Shoot();
            }
            _attackTimer -= Time.deltaTime;
        }

        private void Shoot() {
            if (_attackTimer <= 0) {
                _attackTimer = _attackMaxTimer;
                TowerProjectile proj = Instantiate(_towerProjectile);
                proj.transform.SetPositionAndRotation(_firePoint.position, transform.rotation);
                proj.Init(this);
            }
        }

        public void ChangeAttackRadius(float range) {
            Debug.Log("Changing from tower");
            _towerAttackRadiusCollider.ChangeRange(range);
        }

        private bool TargetIsInRadius() {
            Enemy enemy = GetComponent<Enemy>();
            return _enemiesInRange.Count > 0;
            // var towerRange = _stats.getStatByType(TowerStatType.AttackRange);
            // return false;
        }


        public void AddEnemyInRange(Enemy enemyUnit) {
            _enemiesInRange.Add(enemyUnit);
        }

        public void RemoveEnemyInRange(Enemy enemyUnit) {
            _enemiesInRange.Remove(enemyUnit);
        }

        public void AddStatFromCitadel(TowerStatType type, CitadelStat stat) {
            Debug.Log("Adding stat from citadel to tower: " + type + " " + stat.currentValue);
            var statToIncrease = _stats.getStatByType(type);
            Debug.Log("Stat before increasing: " + statToIncrease);
            statToIncrease.IncreaseMaxValue(stat.getCurrentValue());
            Debug.Log("Stat after increasing: " + statToIncrease);
        }
    }

}