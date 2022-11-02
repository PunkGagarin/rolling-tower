using gameSession.cards.cardInfo;
using UnityEngine;

namespace entities.player.citadels.cardOperators {

    public abstract class AbstractCardOperator : MonoBehaviour, ICardOperator {
        public virtual void OperateChosenCard(CardInfo cardInfo) {
            if (CardExists()) {
                UpgradeCard();
            } else {
                CreateCard();
            }
            cardInfo.IncrementCurrentCardLevel();
        }

        public abstract bool CardExists();

        public abstract void UpgradeCard();

        public abstract void CreateCard();

    }

}