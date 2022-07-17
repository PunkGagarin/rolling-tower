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
        // if (TargetIsInRadius())
        //AttackTarget
    }

    private bool TargetIsInRadius() {
        var towerRange = _stats.getStatByType(TowerStatType.AttackRange);
        return false;
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