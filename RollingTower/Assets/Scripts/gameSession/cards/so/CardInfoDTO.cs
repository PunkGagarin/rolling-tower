using System;
using enums.gameSession.cards;
using UnityEngine;

namespace gameSession.cards.so {

    public class CardInfoDTO : ScriptableObject {
        
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
    }

}