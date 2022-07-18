using System.Collections.Generic;
using entities.bases;
using UnityEngine;

public class EnemyStats : BaseStats<UnitStatType, UnitStat> {

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

    protected override void InitStats() {
        allStats.Add(UnitStatType.Health, _health.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.MoveSpeed, _moveSpeed.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.Damage, _damage.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.AttackSpeed, _attackSpeed.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.AttackRange, _attackRange.Init(UnitStatType.Health));
        allStats.Add(UnitStatType.Reward, _reward.Init(UnitStatType.Health));
    }
}