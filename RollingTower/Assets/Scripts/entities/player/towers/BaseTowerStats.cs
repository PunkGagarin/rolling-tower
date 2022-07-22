using entities.bases;
using Entities.Citadels.Towers;
using enums.towers;
using UnityEngine;

namespace entities.player.towers {

    public class BaseTowerStats : BaseStats<TowerStatType, TowerStat> {

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

}