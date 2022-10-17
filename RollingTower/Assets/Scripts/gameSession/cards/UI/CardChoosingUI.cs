using System;
using System.Collections.Generic;
using gameSession.cards.cardInfo;
using UI;
using UnityEngine;

namespace gameSession.cards.UI {

    public class CardChoosingUI : AbstractScreen {

        public Action<CardInfo> OnCardChoose = delegate { };

        private readonly List<SkillCardUI> _cardPanels = new();

        public static CardChoosingUI GetInstance { get; private set; }

        protected override void Awake() {
            if (GetInstance != null && GetInstance != this) {
                Destroy(this);
            } else {
                GetInstance = this;
            }
            _cardPanels.AddRange(GetComponentsInChildren<SkillCardUI>());
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
                throw new AggregateException("Choosen cards count is greater then card panels count!");
            }
            for (int i = 0; i < cards.Count; i++) {
                _cardPanels[i].InitCardInfo(cards[i]);
            }
        }
    }

}