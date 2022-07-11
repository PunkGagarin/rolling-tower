using System;
using UnityEngine;

[RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamageable {
    public Action OnDie = delegate {};
    
    private EnemyStats _enemyStats;
    private AbstractMovement _movementBehaviour;
    private AbstractUnitAttack _attackBehaviour;

    [SerializeField]
    private EnemyMoveType _enemyMoveType;

    [SerializeField]
    private AttackType _attackType;

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
        var speed = _enemyStats.GetStatByType(EnemyStatType.MoveSpeed);
        var damageStat = _enemyStats.GetStatByType(EnemyStatType.Damage);
        _attackBehaviour.Init(damageStat.CurrentValue);
        _movementBehaviour.Init(speed.CurrentValue, transform, GetComponent<Rigidbody2D>());

        damageStat.OnValueChange += _attackBehaviour.SetDamage;
        speed.OnValueChange += _movementBehaviour.SetSpeed;
        
        _movementBehaviour.SetTarget(_target);
    }

    public void Update() {
        _distance = Vector2.Distance(transform.position, _target.position);
        
        if (_distance > _enemyStats.GetStatByType(EnemyStatType.AttackRange).CurrentValue) {
            _movementBehaviour.Move();
        } else {
            //_attackBehaviour.Attack(_target);
        }
    }

    public void TakeDamage(float damage) {
        if(damage<=0) return;
        var health = _enemyStats.GetStatByType(EnemyStatType.Health);
        health.DecreaseCurrentValue(damage);
        
        if (health.CurrentValue == 0) {
            Die();
        }
    }

    private void Die() {
        OnDie?.Invoke();
        IsDead = true;
    }
}