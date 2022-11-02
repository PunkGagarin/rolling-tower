using System;
using Entities.Citadels.Towers;
using entities.player.towers;
using enums.towers;

namespace entities.player.citadels.cardOperators {

    public interface ITowerOperator : ICardOperator, ICardHolder {

        public event Action<Tower> OnTowerBuild;

        public void AddStatFromCitadel(TowerStatType type, TowerStat stat);
        public void AddStatForEachTower(TowerStatType type, TowerStat stat);

        TowerSlot UnlockSlot();
    }

}