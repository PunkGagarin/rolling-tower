using System;
using enums.towers;

namespace Entities.Citadels.Towers {

    [Serializable]
    public class TowerStat : BaseStat<TowerStat, TowerStatType> {
        public override TowerStat Init(TowerStatType type) {
            _maxValue = currentValue;
            _type = type;
            return this;
        }
    }

}