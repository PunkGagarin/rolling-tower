using System.Collections.Generic;
using enums.citadels;
using UnityEngine;

namespace Entities.Citadels {

    public class CitadelStats : MonoBehaviour{
        
        [SerializeField]
        private PlayerStat _health;
        
        [SerializeField]
        private UnitStat _armor;
        
        [SerializeField]
        private UnitStat _hpRegen;
    
        public Dictionary<PlayerStatType, UnitStat> allStats { get; } = new ();

        public void InitStats() {
            // allStats.Add(UnitStatType.Health, _health.Init(PlayerStats.Health));
            // allStats.Add(UnitStatType.Health, _armor.Init(UnitStatType.Armor));
            // allStats.Add(UnitStatType.Health, _hpRegen.Init(UnitStatType.HpRegen));
        }
    }

}