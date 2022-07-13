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
    
    public Dictionary<EnemyStatType, Stat> allStats { get; } = new ();

    public void InitStats() {
        allStats.Add(EnemyStatType.Health, _health.Init(EnemyStatType.Health));
        allStats.Add(EnemyStatType.MoveSpeed, _moveSpeed.Init(EnemyStatType.Health));
        allStats.Add(EnemyStatType.Damage, _damage.Init(EnemyStatType.Health));
        allStats.Add(EnemyStatType.AttackSpeed, _attackSpeed.Init(EnemyStatType.Health));
        allStats.Add(EnemyStatType.AttackRange, _attackRange.Init(EnemyStatType.Health));
        allStats.Add(EnemyStatType.Reward, _reward.Init(EnemyStatType.Health));
    }
}