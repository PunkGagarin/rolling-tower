using System.Collections.Generic;
using gameSession.cards.cardInfo;

namespace gameSession.cards.Pool {

    public interface ICardPool {
        public List<CardInfo> GetThreeCardFromPool();
        public void HandleCardChosen(CardInfo cardInfo);
    }

}