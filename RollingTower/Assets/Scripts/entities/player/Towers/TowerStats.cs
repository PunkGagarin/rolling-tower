using System.Collections.Generic;
using Entities.Citadels;
using Entities.Citadels.Towers;
using enums.citadels;
using enums.towers;
using UnityEngine;

public class TowerStats : MonoBehaviour{
        
    [SerializeField]
    private TowerStat _damage;
        
    [SerializeField]
    private TowerStat _attackSpeed;
        
    [SerializeField]
    private TowerStat _attackRange;
        
    [SerializeField]
    private TowerStat _armor;
        
    [SerializeField]
    private TowerStat _hpRegen;
        
    [SerializeField]
    private TowerStat _projectileSpeed;
        
    [SerializeField]
    private TowerStat _aoe;
        
    [SerializeField]
    private TowerStat _projectileAmount;
        
    [SerializeField]
    private TowerStat _luck;
    
    public Dictionary<TowerStatType, TowerStat> allStats { get; } = new ();

    public void InitStats() {
        allStats.Add(TowerStatType.Damage, _damage.Init(TowerStatType.Damage));
        allStats.Add(TowerStatType.AttackSpeed, _attackSpeed.Init(TowerStatType.AttackSpeed));
        allStats.Add(TowerStatType.AttackRange, _attackRange.Init(TowerStatType.AttackRange));
        allStats.Add(TowerStatType.Armor, _armor.Init(TowerStatType.Armor));
        allStats.Add(TowerStatType.HpRegen, _hpRegen.Init(TowerStatType.HpRegen));
        allStats.Add(TowerStatType.ProjectileSpeed, _projectileSpeed.Init(TowerStatType.ProjectileSpeed));
        allStats.Add(TowerStatType.AOE, _aoe.Init(TowerStatType.AOE));
        allStats.Add(TowerStatType.ProjectileAmount, _projectileAmount.Init(TowerStatType.ProjectileAmount));
        allStats.Add(TowerStatType.Luck, _luck.Init(TowerStatType.Luck));
    }
}