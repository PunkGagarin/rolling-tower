using System;
using System.Collections.Generic;
using System.Linq;
using entities.player.citadels;
using enums.gameSession.cards;
using gameSession.cards.cardInfo;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace gameSession.cards.Pool {

    public class SelfCardPool : ICardPool {
        private const int CardCapacity = 3;

        private readonly Dictionary<CardType, List<CardInfo>> _cardPool = new();

        private ICardHolder _citadel;

        //Информация о текущих картах хранится в пуле и в цитадели возможно стоит это пересмотреть
        private void RemoveCardIfMaxLevel(CardInfo poolCard) {
            
            if (poolCard.currentCardLevel >= poolCard.maxCardLevel) {
                RemoveCardFromPool(poolCard);
            }
        }

        public void HandleCardChosen(CardInfo cardInfo) {
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

        private void InitCardPool() {
            //todo: implement
            //get all possible cards from somewhere
        }

        public List<CardInfo> GetThreeCardFromPool() {
            List<CardInfo> preparedCards = _cardPool.Values.SelectMany(el => el).ToList();
            int preparedCardsCount = preparedCards.Count;
            var finalCards = new List<CardInfo>(CardCapacity);
            for (int i = 0; i < CardCapacity; i++) {
                if (NoMoreCardInPool(preparedCardsCount, i + 1)) break;
                int randomElementIndex = new Random().NextInt(preparedCards.Count);
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

        private static bool NoMoreCardInPool(int cardsCount, int currentCardNumber) {
            return cardsCount < currentCardNumber;
        }
    }

}