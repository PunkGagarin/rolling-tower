using System;
using System.Collections.Generic;
using gameSession.cards.cardInfo;
using UI;
using UnityEngine;

namespace gameSession.cards.UI {

    public class CardChoosingUI : AbstractScreen {

        public Action<CardInfo> OnCardChoose = delegate { };

        private readonly List<SkillCardUI> _cardPanels = new();

        protected override void Awake() {
            _cardPanels.AddRange(GetComponentsInChildren<SkillCardUI>(true));
            foreach (var cardUI in _cardPanels) {
                cardUI.OnCardChoose += CardChooseHandler;
            }
            base.Awake();
        }

        private void CardChooseHandler(CardInfo card) {
            OnCardChoose.Invoke(card);
            Hide();
        }

        public void SetNewCardsToChooseFrom(List<CardInfo> cards) {
            if (cards.Count > _cardPanels.Count) {
                Debug.Log("Choosen cards count is greater then card panels count!");
                throw new ArgumentException("Choosen cards count is greater then card panels count!");
            }
            for (int i = 0; i < cards.Count; i++) {
                _cardPanels[i].InitCardInfo(cards[i]);
            }
        }
    }

}