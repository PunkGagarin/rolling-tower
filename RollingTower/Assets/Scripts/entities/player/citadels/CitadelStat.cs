using System;
using System.ComponentModel;
using enums.citadels;
using enums.towers;

namespace Entities.Citadels {

    [Serializable]
    public class CitadelStat : BaseStat<CitadelStat, CitadelStatType> {

        //todo: try to move this method to base class
        public override CitadelStat Init(CitadelStatType type) {
            _maxValue = currentValue;
            _type = type;
            return this;
        }

        public static TowerStatType ConvertTypeToTower(CitadelStatType type) {
            string citadelType = type.ToString();
            if (Enum.TryParse(citadelType, out TowerStatType typeToReturn)) {
                return typeToReturn;
            } else {
                throw new InvalidEnumArgumentException("Citadel type doesnt match with Tower type!");
            }
        }
    }

}