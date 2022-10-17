using System;
using gameSession.cards.cardInfo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace gameSession.cards.UI {

    public class SkillCardUI : MonoBehaviour {

        public Action<CardInfo> OnCardChoose = delegate { };

        private CardInfo _cardInfo;

        private Button _cardButton;

        [SerializeField]
        private TextMeshProUGUI _cardName;

        [SerializeField]
        private TextMeshProUGUI _cardDescription;
    
        [SerializeField]
        private Image _cardIcon;

        private void Awake() {
            _cardButton = GetComponent<Button>();
            _cardButton.onClick.AddListener(ChooseCardToBuild);
        }

        private void ChooseCardToBuild() {
            OnCardChoose.Invoke(_cardInfo);
        }

        public void InitCardInfo(CardInfo cardInfo) {
            _cardInfo = cardInfo;
            _cardName.text = cardInfo.cardName;
            _cardDescription.text = cardInfo.cardDescription;
            _cardIcon.sprite = cardInfo.cardIcon;
        }
    }

}