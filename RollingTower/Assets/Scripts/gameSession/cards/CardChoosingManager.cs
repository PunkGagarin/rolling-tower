using System;
using entities.player.citadels;
using enums.towers;
using gameSession.cards.Pool;
using UnityEngine;
using gameSession.cards.cardInfo;
using gameSession.cards.UI;
using Zenject;

namespace gameSession.cards {

    public class CardChoosingManager : MonoBehaviour, IStageManager {

        public Action OnCardChoose = delegate { };

        [Inject]
        private CardChoosingUI _cardChoosingUI;

        [Inject]
        private ICardPool _cardPool;

        [Inject]
        private Citadel _citadel;

        private void Awake() {
            _cardPool.InitCardPool();
        }

        private void Start() {
            _cardChoosingUI.OnCardChoose += OnCardChooseHandle;
        }

        private void OnCardChooseHandle(CardInfo chosenCard) {
            _citadel.CardChoseHandle(chosenCard);
            _cardPool.CardChosenHandle(chosenCard);
            EndStage();
        }

        public void StartStage() {
            _cardChoosingUI.SetNewCardsToChooseFrom(_cardPool.GetThreeCardFromPool());
            _cardChoosingUI.Show();
        }

        public void EndStage() {
            OnCardChoose.Invoke();
        }

        public CardInfo getTowerByType(TowerType towerType) {
            return _cardPool.GetTowerByType(towerType);
        }

        private void OnDestroy() {
            _cardChoosingUI.OnCardChoose -= OnCardChooseHandle;
            _cardChoosingUI.OnCardChoose -= _cardPool.CardChosenHandle;
        }
    }

}