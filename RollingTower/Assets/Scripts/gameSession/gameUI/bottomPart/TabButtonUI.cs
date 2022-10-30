using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace gameSession.gameUI.bottomPart {

    public class TabButtonUI : ButtonUI {

        public Action<InGameTabType> OnTabButtonClicked = delegate {  };

        private Button _tabButton;

        [field: SerializeField]
        public InGameTabType tabType { get; private set; }

        protected override void ButtonAction() {
            OnTabButtonClicked.Invoke(tabType);
            Debug.Log("we jsut clicked tab button: " + tabType);
            //TODO: add glow or any animation effect to see which tab is active currently
        }
    }

}