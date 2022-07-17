using entities.bases;
using Entities.Citadels.Towers;
using enums.towers;
using UnityEngine;

public class TowerStats : BaseStats<TowerStatType, TowerStat> {

    [SerializeField]
    private TowerStat _damage;

    [SerializeField]
    private TowerStat _attackSpeed;

    [SerializeField]
    private TowerStat _attackRange;

    [SerializeField]
    private TowerStat _projectileSpeed;

    [SerializeField]
    private TowerStat _aoe;

    [SerializeField]
    private TowerStat _projectileAmount;

    [SerializeField]
    private TowerStat _luck;

    private void Awake() {
        InitStats();
    }

    private void InitStats() {
        allStats.Add(TowerStatType.Damage, _damage.Init(TowerStatType.Damage));
        allStats.Add(TowerStatType.AttackSpeed, _attackSpeed.Init(TowerStatType.AttackSpeed));
        allStats.Add(TowerStatType.AttackRange, _attackRange.Init(TowerStatType.AttackRange));
        allStats.Add(TowerStatType.ProjectileSpeed, _projectileSpeed.Init(TowerStatType.ProjectileSpeed));
        allStats.Add(TowerStatType.AOE, _aoe.Init(TowerStatType.AOE));
        allStats.Add(TowerStatType.ProjectileAmount, _projectileAmount.Init(TowerStatType.ProjectileAmount));
        allStats.Add(TowerStatType.Luck, _luck.Init(TowerStatType.Luck));
    }
}