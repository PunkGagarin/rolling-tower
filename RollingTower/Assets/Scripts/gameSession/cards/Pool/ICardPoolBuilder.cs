using System;
using System.Collections.Generic;
using enums.gameSession.cards;
using enums.towers;
using gameSession.cards.cardInfo;

namespace gameSession.cards {

    public interface ICardPoolBuilder {
        ICardPoolBuilder InitPool(Dictionary<CardType, List<CardInfo>> cardPool);
        ICardPoolBuilder RemoveNonUpgradesOfType(bool isNeeded, CardType type, List<TowerType> currentTypes);
        ICardPoolBuilder RemoveAllByType(bool isNeeded, Dictionary<CardType, List<CardInfo>> pool, CardType type);
        List<CardInfo> Construct();

        ICardPoolBuilder RemoveMaxed(bool isNeeded, IEnumerable<CustomKeyValue<CardType, IConvertible>> maxLevelCards);
    }

}