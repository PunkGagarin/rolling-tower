using System;
using System.Collections.Generic;
using System.Linq;
using enums.gameSession.cards;
using enums.towers;
using gameSession.cards.cardInfo;
using UnityEngine;

namespace gameSession.cards {

    public class CardPoolBuilder : ICardPoolBuilder {


        private Dictionary<CardType, List<CardInfo>> _cardPool = new();

        private CardPoolBuilder() {
        }

        public static ICardPoolBuilder CreateCardPoolBuilder() {
            return new CardPoolBuilder();
        }

        public ICardPoolBuilder InitPool(Dictionary<CardType, List<CardInfo>> cardPool) {
            if (cardPool != null && cardPool.Count > 0) {
                _cardPool = cardPool;
            } else {
                Debug.Log("Trying to init card pool with zero entities");
                throw new ArgumentException();
            }
            return this;
        }

        public ICardPoolBuilder RemoveNonUpgradesOfType(bool isNeeded, CardType type, List<TowerType> currentTypes) {
            if (isNeeded) {
                _cardPool[type]?.RemoveAll(el => !currentTypes.Contains((TowerType) el.type));
            }
            return this;
        }

        public ICardPoolBuilder RemoveAllByType(bool isNeeded, Dictionary<CardType, List<CardInfo>> pool,
            CardType type) {
            if (isNeeded) {
                _cardPool.Remove(type);
            }
            return this;
        }

        public ICardPoolBuilder RemoveMaxed(bool isNeeded, IEnumerable<CustomKeyValue<CardType, IConvertible>> maxLevelCards) {
            foreach (var keyValue in maxLevelCards) {
                //cardPool remove keyValue
                if (_cardPool.TryGetValue(keyValue.key, out var cards)) {
                    cards.RemoveAll(el => el.type.Equals(keyValue.value));
                }
            }
            return this;
        }

        private List<CardInfo> ConvertToList() {
            return _cardPool.Values.SelectMany(el => el).ToList();
        }

        public List<CardInfo> Construct() {
            return ConvertToList();
        }
    }

}