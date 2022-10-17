using gameSession.cards.cardInfo;

namespace entities.player.citadels {

    public interface ICardOperator {

        public void OperateChosenCard(CardInfo cardInfo);
        public bool CardExists();
        public void UpgradeCard();
        public void CreateCard();
    }

}