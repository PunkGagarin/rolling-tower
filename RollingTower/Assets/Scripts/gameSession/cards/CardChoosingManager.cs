using System;
using UnityEngine;

namespace gameSession.cards {

    public class CardChoosingManager : MonoBehaviour, IStageManager {
    
        public Action OnCardChoose = delegate { };
    
        private CardChoosingUI _cardChoosingUI;

        private void Start() {
            _cardChoosingUI = CardChoosingUI.GetInstance;
            _cardChoosingUI.OnCardChoose += EndStage;
        }

        public void StartStage() {
            _cardChoosingUI.Show();
        }

        public void EndStage() {
            OnCardChoose.Invoke();
        }
    }

}