using System.Collections.Generic;
using entities.bases;
using Entities.Citadels.Towers;
using entities.player.towers;
using enums.towers;
using UnityEngine;

public class TowerStats : BaseStats<TowerStatType, TowerStat> {

    private Tower _towerOwner;

    [SerializeField]
    private TowerStat _damage;

    [Tooltip("Time for one attack")]
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
    protected override void Awake() {
        base.Awake();
        _towerOwner = GetComponent<Tower>();
    }

    protected override void InitStats() {
        allStats.Add(TowerStatType.Damage, _damage.Init(TowerStatType.Damage));
        allStats.Add(TowerStatType.AttackSpeed, _attackSpeed.Init(TowerStatType.AttackSpeed));
        allStats.Add(TowerStatType.AttackRange, _attackRange.Init(TowerStatType.AttackRange));
        allStats.Add(TowerStatType.ProjectileSpeed, _projectileSpeed.Init(TowerStatType.ProjectileSpeed));
        allStats.Add(TowerStatType.AOE, _aoe.Init(TowerStatType.AOE));
        allStats.Add(TowerStatType.ProjectileAmount, _projectileAmount.Init(TowerStatType.ProjectileAmount));
        allStats.Add(TowerStatType.Luck, _luck.Init(TowerStatType.Luck));
    }
}