using System;
using System.Collections.Generic;
using enums.gameSession.cards;
using enums.towers;

namespace entities.player.citadels {

    public interface ICardHolder {
        bool IsMaxLevelExists();
        List<CustomKeyValue<CardType, IConvertible>> GetMaxedCards();
        List<TowerType> GetCurrentCardTypes();
        bool IsCardFreeSlotsLeft();

    }

}