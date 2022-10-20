using entities.player.towers;
using enums.gameSession.cards;
using enums.towers;
using UnityEngine;

namespace gameSession.cards.so {

    [CreateAssetMenu(fileName = "new TowerCardInfo", menuName = "Card/Tower")]
    public class TowerCardInfoDTO : CardInfoDTO {
        
        [field: SerializeField]
        public Tower prefab { get; set; }

        [field: SerializeField]
        public TowerType towerType { get; set; }

        private void Awake() {
            type = CardType.Tower;
        }
    }

}