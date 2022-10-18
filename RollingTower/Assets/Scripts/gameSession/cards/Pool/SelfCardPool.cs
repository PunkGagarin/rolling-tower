using System;
using System.Collections.Generic;
using System.Linq;
using entities.player.citadels;
using enums.gameSession.cards;
using enums.towers;
using gameSession.cards.cardInfo;
using gameSession.cards.so;
using UnityEngine;
using Random = System.Random;

namespace gameSession.cards.Pool {

    public class SelfCardPool : ICardPool {
        private const int CardCapacity = 3;
        private const string ResourcePath = "Towers/SO/TowerInfo";

        
        //todo: move initialize to init method
        private readonly Dictionary<CardType, List<CardInfo>> _cardPool = new() {
            {CardType.Tower, new List<CardInfo>()},
            {CardType.Perk, new List<CardInfo>()},
            };

        public void InitCardPool() {
              var towersDTOs = Resources.LoadAll<TowerCardInfoDTO>(ResourcePath).ToList();
              var towerCardInfos = towersDTOs.Select(el => new TowerCardInfo(el));
              _cardPool[CardType.Tower].AddRange(towerCardInfos);
        }

        //Информация о текущих картах хранится в пуле и в цитадели возможно стоит это пересмотреть
        private void RemoveCardIfMaxLevel(CardInfo poolCard) {
            if (poolCard.currentCardLevel >= poolCard.maxCardLevel) {
                RemoveCardFromPool(poolCard);
            }
        }

        public void CardChosenHandle(CardInfo cardInfo) {
            CardInfo poolCard = _cardPool[cardInfo.type].FirstOrDefault(info => info.Equals(cardInfo));
            if (poolCard == null) {
                Debug.Log("Cant find the card we just upgraded in card pool!");
                throw new Exception("Cant find the card we just upgraded in card pool!");
            }
            RemoveCardIfMaxLevel(poolCard);
        }

        private void RemoveCardFromPool(CardInfo poolCard) {
            _cardPool[poolCard.type].Remove(poolCard);
        }

        public List<CardInfo> GetThreeCardFromPool() {
            List<CardInfo> preparedCards = _cardPool.Values.SelectMany(el => el).ToList();
            int preparedCardsCount = preparedCards.Count;
            var finalCards = new List<CardInfo>(CardCapacity);
            for (int i = 0; i < CardCapacity; i++) {
                if (NoMoreCardInPool(preparedCardsCount, i + 1)) break;
                int randomElementIndex = new Random().Next(preparedCards.Count);
                finalCards.Add(preparedCards[randomElementIndex]);
                preparedCards.RemoveAt(randomElementIndex);
            }
            return finalCards;
        }

        private void RebuildCurrentCardPool() {
            //жалко удалять, пока оставлю
            // _cardPool = CardPoolBuilder.CreateCardPoolBuilder()
            //     .InitPool(_cardPool)
            //     .RemoveNonUpgradesOfType(_citadel.IsTowerFreeSlotsLeft(), CardType.Tower,
            //         _citadel.GetCurrentTowerTypes())
            //     // .RemoveNonUpgradesOfType(_citadel.isSupportSlotsLeft(), CardType.Support, new List<SupportType>())
            //     // .RemoveNonUpgradesOfType(isPerkSlotsLeft(), CardType.Perk, new List<PerkType>())
            //     .RemoveMaxed(_citadel.IsMaxLevelExists(), _citadel.GetMaxedCards())
            //     .Construct();
        }

        public CardInfo GetTowerByType(TowerType towerType) {
            var towerCardInfo = _cardPool[CardType.Tower]
                .Select(el => (TowerCardInfo) el)
                .FirstOrDefault(el => el.towerType.Equals(towerType));
            if (towerCardInfo == null) {
                Debug.Log("There is no tower for given type in cardPool!");
                 throw new ArgumentException("There is no tower for given type in cardPool!");
            }
            return towerCardInfo;
        }

        private static bool NoMoreCardInPool(int cardsCount, int currentCardNumber) {
            return cardsCount < currentCardNumber;
        }
    }

}