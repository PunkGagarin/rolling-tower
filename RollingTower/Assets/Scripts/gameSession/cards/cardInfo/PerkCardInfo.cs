using enums.citadels;
using enums.gameSession.cards;
using gameSession.cards.so;

namespace gameSession.cards.cardInfo {

    public class PerkCardInfo : CardInfo {

        public PerkCardInfo() {
            type = CardType.Perk;
        }
    
        public PerkCardInfo(PerkCardInfoDto cardInfo) : base(cardInfo) {
            type = CardType.Perk;
        }

    }

}