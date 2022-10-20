using enums.gameSession.cards;
using UnityEngine;

namespace gameSession.cards.so {

    [CreateAssetMenu(fileName = "new PerkCardInfo", menuName = "Card/Perk")]
    public class PerkCardInfoDto : CardInfoDTO {
        
        private void Awake() {
            type = CardType.Perk;
        }
    }

}