using System;
using entities.player.towers;
using enums.gameSession.cards;
using enums.towers;
using gameSession.cards.so;
using UnityEngine;

namespace gameSession.cards.cardInfo {

    [Serializable]
    public class TowerCardInfo : CardInfo {

        [field: SerializeField]
        public Tower prefab { get; set; }

        [field: SerializeField]
        public TowerType towerType { get; set; }

        public TowerCardInfo() {
            type = CardType.Tower;
        }

        public TowerCardInfo(TowerCardInfoDTO cardInfo) : base(cardInfo) {
            type = CardType.Tower;
            prefab = cardInfo.prefab;
        }

    }

}