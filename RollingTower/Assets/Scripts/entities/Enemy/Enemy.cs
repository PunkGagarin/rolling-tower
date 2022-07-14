using System;
using UnityEngine;

[RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamageable {
    public Action OnDie = delegate {};
    
    private EnemyStats _enemyStats;
    private AbstractMovement _movementBehaviour;
    private AbstractUnitAttack _attackBehaviour;

    private EnemyMoveType _enemyMoveType;

    [SerializeField]
    private AttackType _attackType;

    //todo: remove
    [SerializeField]
    private Transform _target;

    public bool IsDead { get; private set; }
    private float _distance;

    private void Awake() {
        _movementBehaviour = MoveFactory.GetMoveBehaviour(_enemyMoveType);
        _attackBehaviour = AttackTypeFactory.GetAttackBehaviourByType(_attackType);
        _enemyStats = GetComponent<EnemyStats>();
        
        _enemyStats.InitStats();
        InitBehaviours();
    }

    private void InitBehaviours() {
        var speedStat = _enemyStats.allStats[UnitStatType.MoveSpeed];
        var damageStat = _enemyStats.allStats[UnitStatType.Damage];
        _attackBehaviour.Init(damageStat.currentValue);
        _movementBehaviour.Init(speedStat.currentValue, transform, GetComponent<Rigidbody2D>());

        damageStat.OnValueChange += _attackBehaviour.SetDamage;
        speedStat.OnValueChange += _movementBehaviour.SetSpeed;
        
        _movementBehaviour.SetTarget(_target);
    }

    public void Update() {
        if (IsNeedToMove()) {
            _movementBehaviour.Move();
        } else {
            //todo: remove comments
            //_attackBehaviour.Attack(_target);
        }
    }

    public void TakeDamage(float damage) {
        if(damage<=0) return;
        var health = _enemyStats.allStats[UnitStatType.Health];
        health.DecreaseCurrentValue(damage);
        
        if (health.currentValue == 0) {
            Die();
        }
    }
    
    private bool IsNeedToMove() {
        var distance = _target.position - transform.position;
        var range = _enemyStats.allStats[UnitStatType.AttackRange].currentValue;
        return !(distance.sqrMagnitude < range * range);
    }

    private void Die() {
        OnDie?.Invoke();
        IsDead = true;
    }
}