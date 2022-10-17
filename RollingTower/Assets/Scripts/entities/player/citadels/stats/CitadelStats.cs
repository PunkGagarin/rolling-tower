using System.Collections.Generic;
using entities.bases;
using enums.citadels;
using UnityEngine;

namespace entities.player.citadels {

    public class CitadelStats : BaseStats<CitadelStatType, CitadelStat> {

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

        protected override void InitStats() {
            AddStatsForCitadelWithInit();
        }

        private void AddStatsForCitadelWithInit() {
            allStats.Add(CitadelStatType.Health, _health.Init(CitadelStatType.Health));
            allStats.Add(CitadelStatType.Armor, _armor.Init(CitadelStatType.Armor));
            allStats.Add(CitadelStatType.HpRegen, _hpRegen.Init(CitadelStatType.HpRegen));
            allStats.Add(CitadelStatType.Luck, _luck.Init(CitadelStatType.Luck));
            allStats.Add(CitadelStatType.GoldBonus, _goldBonus.Init(CitadelStatType.GoldBonus));
            allStats.Add(CitadelStatType.CardRerollAmount, _cardRerollAmount.Init(CitadelStatType.CardRerollAmount));
        }

    }

}