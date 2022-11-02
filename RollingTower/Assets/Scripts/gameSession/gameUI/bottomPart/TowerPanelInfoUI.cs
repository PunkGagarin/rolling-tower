using enums.towers;
using gameSession.cards.cardInfo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace gameSession.gameUI {

    public class TowerPanelInfoUI : MonoBehaviour {


        public TowerType towerType { get; private set; }

        [SerializeField]
        private Image _iconImage;

        [SerializeField]
        private TextMeshProUGUI _nameText;

        [SerializeField]
        private TextMeshProUGUI _levelText;
    
        //TODO: show all towerInfo like damage, attack speed etc.
    
    
        public void InitByInfo(TowerCardInfo info) {
            _iconImage.sprite = info.cardIcon;
            _nameText.text = info.cardName;
            _levelText.text = $"{info.currentCardLevel} / {info.maxCardLevel}";
            towerType = info.towerType;
        }

        public void CleanUpPanel() {
        
            _iconImage = null;
            _nameText.text = "defaultName";
            _levelText.text = "0/0";
        }

        public void ChangeLevelText(int currentLevel, int maxLevel) {
            _levelText.text = $"{currentLevel} / {maxLevel}";
        }
    
    
    }

}