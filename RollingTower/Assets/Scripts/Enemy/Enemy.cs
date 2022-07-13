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
        var speedStat = _enemyStats.allStats[EnemyStatType.MoveSpeed];
        var damageStat = _enemyStats.allStats[EnemyStatType.Damage];
        _attackBehaviour.Init(damageStat.CurrentValue);
        _movementBehaviour.Init(speedStat.CurrentValue, transform, GetComponent<Rigidbody2D>());

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
        var health = _enemyStats.allStats[EnemyStatType.Health];
        health.DecreaseCurrentValue(damage);
        
        if (health.CurrentValue == 0) {
            Die();
        }
    }
    
    private bool IsNeedToMove() {
        var distance = _target.position - transform.position;
        var range = _enemyStats.allStats[EnemyStatType.AttackRange].CurrentValue;
        return !(distance.sqrMagnitude < range * range);
    }

    private void Die() {
        OnDie?.Invoke();
        IsDead = true;
    }
}