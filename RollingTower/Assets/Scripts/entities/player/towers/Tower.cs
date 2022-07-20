using System;
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

        private float _attackMaxTimer;
        private float _currentAttackTimer;

        private void Awake() {
            _stats = GetComponent<TowerStats>();
            _towerAttackRadiusCollider = GetComponentInChildren<AttackRadiusCollider>(true);
            Debug.Log(_towerAttackRadiusCollider);
        }

        private void Start() {
            SetProperAttackTime();
        }

        public void SetProperAttackTime() {
            Debug.Log("Changing attackSpeed timer, old timer: " + _attackMaxTimer);
            _attackMaxTimer = 10 / _stats.getStatByType(TowerStatType.AttackSpeed).currentValue;
            _currentAttackTimer = _attackMaxTimer;
            Debug.Log("New timer: " + _attackMaxTimer);
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
            _currentAttackTimer -= Time.deltaTime;
        }

        private void Shoot() {
            if (_currentAttackTimer <= 0) {
                _currentAttackTimer = _attackMaxTimer;
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