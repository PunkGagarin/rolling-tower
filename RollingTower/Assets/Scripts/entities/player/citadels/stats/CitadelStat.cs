using System;
using enums.citadels;

namespace entities.player.citadels {

    [Serializable]
    public class CitadelStat : BaseStat<CitadelStat, CitadelStatType> {

        //todo: try to move this method to base class
        public override CitadelStat Init(CitadelStatType type) {
            _maxValue = currentValue;
            _type = type;
            return this;
        }
    }

}