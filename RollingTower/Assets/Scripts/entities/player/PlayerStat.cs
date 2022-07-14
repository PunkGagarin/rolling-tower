using enums.citadels;

namespace Entities.Citadels {

    public class PlayerStat : UnitStat {

        public new PlayerStatType type { get; private set; }
        
        public new PlayerStat Init(PlayerStatType type) {
            _maxValue = currentValue;
            this.type = type;
            return this;
        }
    }

}