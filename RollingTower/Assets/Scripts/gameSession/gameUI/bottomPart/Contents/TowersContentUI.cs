using System;
using System.Collections.Generic;
using System.Linq;
using enums.towers;
using gameSession.cards.cardInfo;
using UnityEngine;

namespace gameSession.gameUI.bottomPart.Contents {

    public class TowersContentUI : GameSessionContentUI {

        private List<TowerCardInfo> _towerCardInfos;

        private List<TowerPanelInfoUI> _towersPanels;

        [SerializeField]
        private TowerPanelInfoUI _panelPrefab;

        protected override void Awake() {
            type = InGameTabType.Towers;
            base.Awake();
        }

        public void CrateTowerPanel(TowerCardInfo info) {
            if (_towersPanels.Exists(el => info.towerType.Equals(el.towerType))) {
                Debug.Log("trying to add already existing tower into towerPanel");
                throw new ArgumentException("trying to add already existing tower into towerPanel");
            }
            var newTowerPanel = Instantiate(_panelPrefab, _content.transform);
            newTowerPanel.InitByInfo(info);
            _towersPanels.Add(newTowerPanel);
        }

        public void ChangeTowerLevel(TowerType towerType, int currentLevel, int maxLevel) {
            var towerPanel = _towersPanels.FirstOrDefault(el => towerType.Equals(el.towerType));
            if (towerPanel != null) {
                towerPanel.ChangeLevelText(currentLevel, maxLevel);
            } else {
                Debug.Log("Trying to change level of non existing tower card!");
            }
        }


    }

}