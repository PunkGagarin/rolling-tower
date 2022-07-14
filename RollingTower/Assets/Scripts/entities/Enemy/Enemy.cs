using System;
using entities.bases;
using Entities.Citadels;
using enums.citadels;
using UnityEngine;

[RequireComponent(typeof(EnemyStats), typeof(Rigidbody2D))]
public class Enemy : HealthUnit<UnitStatType, EnemyStats, UnitStat>, IDamageable {
    private AbstractMovement _movementBehaviour;
    private AbstractUnitAttack _attackBehaviour;
    

    private EnemyMoveType _enemyMoveType;

    [SerializeField]
    private AttackType _attackType;

    //todo: remove
    [SerializeField]
    private Transform _target;

    private float _distance;

    private void Awake() {
        _movementBehaviour = MoveFactory.GetMoveBehaviour(_enemyMoveType);
        _attackBehaviour = AttackTypeFactory.GetAttackBehaviourByType(_attackType);
        _stats = GetComponent<EnemyStats>();
        
        _stats.InitStats();
        InitBehaviours();
    }

    private void InitBehaviours() {
        var speedStat = _stats.allStats[UnitStatType.MoveSpeed];
        var damageStat = _stats.allStats[UnitStatType.Damage];
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

    protected override UnitStat getHealth() {
        return _stats.getAllStats()[UnitStatType.Health];
    }

    private bool IsNeedToMove() {
        var distance = _target.position - transform.position;
        var range = _stats.allStats[UnitStatType.AttackRange].currentValue;
        return !(distance.sqrMagnitude < range * range);
    }
}