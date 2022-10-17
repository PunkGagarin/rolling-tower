using System;
using entities.player.citadels;
using gameSession.cards.Pool;
using UnityEngine;
using gameSession.cards.cardInfo;
using gameSession.cards.UI;

namespace gameSession.cards {

    public class CardChoosingManager : MonoBehaviour, IStageManager {
    
        public Action OnCardChoose = delegate { };
    
        private CardChoosingUI _cardChoosingUI;

        private readonly ICardPool _cardPool = new SelfCardPool();

        private Citadel _citadel;

        private void Start() {
            _cardChoosingUI = CardChoosingUI.GetInstance;
            _citadel = Citadel.GetInstance;
            
            _cardChoosingUI.OnCardChoose += OnCardChooseHandle;
            _cardChoosingUI.OnCardChoose += _cardPool.HandleCardChosen;
        }

        private void OnCardChooseHandle(CardInfo choosenCard) {
            _citadel.CardChooseHandle(choosenCard);
            EndStage();
        }

        public void StartStage() {
            _cardChoosingUI.SetNewCardsToChooseFrom(_cardPool.GetThreeCardFromPool());
            _cardChoosingUI.Show();
        }

        public void EndStage() {
            OnCardChoose.Invoke();
        }

        private void OnDestroy() {
            _cardChoosingUI.OnCardChoose -= OnCardChooseHandle;
            _cardChoosingUI.OnCardChoose -= _cardPool.HandleCardChosen;
        }
    }

}