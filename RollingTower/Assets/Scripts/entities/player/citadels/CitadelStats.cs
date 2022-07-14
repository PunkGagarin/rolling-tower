using System.Collections.Generic;
using entities.bases;
using enums.citadels;
using UnityEngine;

namespace Entities.Citadels {

    public class CitadelStats : MonoBehaviour, IUnitStats<CitadelStatType, CitadelStat> {

        [SerializeField]
        private CitadelStat _health;

        [SerializeField]
        private CitadelStat _armor;

        [SerializeField]
        private CitadelStat _hpRegen;

        [SerializeField]
        private CitadelStat _luck;

        [SerializeField]
        private CitadelStat _goldBonus;

        [SerializeField]
        private CitadelStat _cardRerollAmount;

        [SerializeField]
        private CitadelStat _damage;

        [SerializeField]
        private CitadelStat _attackSpeed;

        [SerializeField]
        private CitadelStat _attackRange;

        [SerializeField]
        private CitadelStat _projectileSpeed;

        [SerializeField]
        private CitadelStat _aoe;

        [SerializeField]
        private CitadelStat _projectileAmount;

        public Dictionary<CitadelStatType, CitadelStat> allStats { get; } = new();

        public void InitStats() {
            allStats.Add(CitadelStatType.Health, _health.Init(CitadelStatType.Health));
            allStats.Add(CitadelStatType.Damage, _damage.Init(CitadelStatType.Damage));
            allStats.Add(CitadelStatType.AttackSpeed, _attackSpeed.Init(CitadelStatType.AttackSpeed));
            allStats.Add(CitadelStatType.AttackRange, _attackRange.Init(CitadelStatType.AttackRange));
            allStats.Add(CitadelStatType.Armor, _armor.Init(CitadelStatType.Armor));
            allStats.Add(CitadelStatType.HpRegen, _hpRegen.Init(CitadelStatType.HpRegen));
            allStats.Add(CitadelStatType.ProjectileSpeed, _projectileSpeed.Init(CitadelStatType.ProjectileSpeed));
            allStats.Add(CitadelStatType.AOE, _aoe.Init(CitadelStatType.AOE));
            allStats.Add(CitadelStatType.ProjectileAmount, _projectileAmount.Init(CitadelStatType.ProjectileAmount));
            allStats.Add(CitadelStatType.Luck, _luck.Init(CitadelStatType.Luck));
            allStats.Add(CitadelStatType.GoldBonus, _goldBonus.Init(CitadelStatType.GoldBonus));
            allStats.Add(CitadelStatType.CardRerollAmount, _cardRerollAmount.Init(CitadelStatType.CardRerollAmount));
        }

        public Dictionary<CitadelStatType, CitadelStat> getAllStats() {
            return allStats;
        }

        public CitadelStat getStatByType(CitadelStatType type) {
            if (!allStats.ContainsKey(type)) {
                Debug.Log("Trying to get not existed stat from: " + transform.name);
            }
            return allStats[type];
        }
    }

}