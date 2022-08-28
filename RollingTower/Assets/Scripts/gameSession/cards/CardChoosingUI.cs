using System;
using System.Collections.Generic;
using UI;

namespace gameSession.cards {

    public class CardChoosingUI : AbstractScreen {

        public Action OnCardChoose = delegate { };

        private List<SkillCardUI> _cards = new();

        public static CardChoosingUI GetInstance { get; private set; }

        protected override void Awake() {
            if (GetInstance != null && GetInstance != this) {
                Destroy(this);
            } else {
                GetInstance = this;
            }
            _cards.AddRange(GetComponentsInChildren<SkillCardUI>());
            foreach (var cardUI in _cards) {
                cardUI.OnCardChoose += CardChooseHandler;
            }
            base.Awake();
        }

        private void CardChooseHandler(SkillCardUI obj) {
            OnCardChoose.Invoke();
            Hide();
        }
    }

}