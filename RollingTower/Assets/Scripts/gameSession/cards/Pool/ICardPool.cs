using System.Collections.Generic;
using enums.towers;
using gameSession.cards.cardInfo;

namespace gameSession.cards.Pool {

    public interface ICardPool {
        public List<CardInfo> GetThreeCardFromPool();
        public void CardChosenHandle(CardInfo cardInfo);
        void InitCardPool();
        CardInfo GetTowerByType(TowerType towerType);
    }

}