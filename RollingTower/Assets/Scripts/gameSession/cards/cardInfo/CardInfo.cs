using System;
using enums.gameSession.cards;
using gameSession.cards.so;
using UnityEngine;

namespace gameSession.cards.cardInfo {

    [Serializable]
    public abstract class CardInfo {

        [field: SerializeField]
        public Sprite cardIcon { get; set; }

        [field: SerializeField]
        public string cardName { get; set; }

        [field: SerializeField]
        public string cardDescription { get; set; }

        [field: SerializeField]
        public CardType type { get; protected set; }

        [field: SerializeField]
        public int currentCardLevel { get; private set; }

        [field: SerializeField]
        public int maxCardLevel { get; set; }

        protected CardInfo() {
        }

        protected CardInfo(CardInfoDTO cardInfo) {
            cardIcon = cardInfo.cardIcon;
            cardName = cardInfo.cardName;
            cardDescription = cardInfo.cardDescription;
            type = cardInfo.type;
            currentCardLevel = cardInfo.currentCardLevel;
            maxCardLevel = cardInfo.maxCardLevel;
        }

        public void IncrementCurrentCardLevel() {
            currentCardLevel++;
        }

    }

}