using System;
using System.Collections.Generic;
using Entities.Citadels.Towers;
using enums.towers;
using UnityEngine;

public class Tower : MonoBehaviour {

    private AttackRadiusCollider _towerAttackCollider;

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
        _towerAttackCollider = GetComponentInChildren<AttackRadiusCollider>();
    }

    private void Start() {
    }


    public void DamageEnemy(Enemy enemy) {
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
            Debug.Log("we are shooting now"!);
            _attackTimer = _attackMaxTimer;
        }
    }

    private bool TargetIsInRadius() {
        return _enemiesInRange.Count > 0;
        // var towerRange = _stats.getStatByType(TowerStatType.AttackRange);
        // return false;
    }


    public void AddEnemyInRange(Enemy enemyUnit) {
        _enemiesInRange.Add(enemyUnit);
        Debug.Log("We just Added an Enemy to the tower");
    }

    public void RemoveEnemyInRange(Enemy enemyUnit) {
        _enemiesInRange.Remove(enemyUnit);
        Debug.Log("we Just removed an enemy from the tower");
    }
}