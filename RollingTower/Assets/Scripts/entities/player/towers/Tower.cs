using System.Collections.Generic;
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

        private List<enemies.Enemy> _enemiesInRange = new();

        private TowerStats _stats;

        private float _attackMaxTimer = 1f;
        private float _attackTimer = 1f;

        private void Awake() {
            _stats = GetComponent<TowerStats>();
            _towerAttackRadiusCollider = GetComponentInChildren<AttackRadiusCollider>(true);
            Debug.Log(_towerAttackRadiusCollider);
        }


        public void DamageEnemy(enemies.Enemy enemy) {
            Debug.Log("Deal damage to enemy");
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
            enemies.Enemy enemy = GetComponent<enemies.Enemy>();
            return _enemiesInRange.Count > 0;
            // var towerRange = _stats.getStatByType(TowerStatType.AttackRange);
            // return false;
        }


        public void AddEnemyInRange(enemies.Enemy enemyUnit) {
            _enemiesInRange.Add(enemyUnit);
        }

        public void RemoveEnemyInRange(enemies.Enemy enemyUnit) {
            _enemiesInRange.Remove(enemyUnit);
        }
    }

}