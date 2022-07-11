using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    
    [SerializeField]
    private Stat _health;
    
    [SerializeField]
    private Stat _moveSpeed;
    
    [SerializeField]
    private Stat _damage;
    
    [SerializeField]
    private Stat _attackSpeed;
    
    [SerializeField]
    private Stat _attackRange;
    
    [SerializeField]
    private Stat _reward;

    private List<Stat> _stats = new();

    public void InitStats() {
        _health.Init(EnemyStatType.Health, ref _stats);
        _moveSpeed.Init(EnemyStatType.MoveSpeed, ref _stats);
        _damage.Init(EnemyStatType.Damage, ref _stats);
        _attackSpeed.Init(EnemyStatType.AttackSpeed, ref _stats);
        _attackRange.Init(EnemyStatType.AttackRange, ref _stats);
        _reward.Init(EnemyStatType.Reward, ref _stats);
    }

    public Stat GetStatByType(EnemyStatType enemyStatType) => _stats.Find(stat => stat.Type.Equals(enemyStatType));
}