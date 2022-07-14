using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
    
    [SerializeField]
    private UnitStat _health;
    
    [SerializeField]
    private UnitStat _moveSpeed;
    
    [SerializeField]
    private UnitStat _damage;
    
    [SerializeField]
    private UnitStat _attackSpeed;
    
    [SerializeField]
    private UnitStat _attackRange;
    
    [SerializeField]
    private UnitStat _reward;
    
    public Dictionary<UnitStatType, UnitStat> allStats { get; } = new ();

    public void InitStats() {
        allStats.Add(UnitStatType.Health, _health.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.MoveSpeed, _moveSpeed.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.Damage, _damage.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.AttackSpeed, _attackSpeed.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.AttackRange, _attackRange.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.Reward, _reward.Init(UnitStatType.Health));
    }
}