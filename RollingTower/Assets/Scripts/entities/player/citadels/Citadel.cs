using Entities.Citadels.Towers;
using entities.player.citadels.cardOperators;
using entities.player.towers;
using enums.gameSession.cards;
using enums.towers;
using gameSession.cards;
using gameSession.cards.cardInfo;
using gameSession.cards.Pool;
using UnityEngine;
using Zenject;

namespace entities.player.citadels {

    public class Citadel : CitadelHealthUnit {

        [SerializeField]
        private TowerType _startingTowerType;

        private CitadelTowerStats _sharedBaseTowerStats;

        private ITowerOperator _citadelTowers;

        [Inject]
        private ICardPool _cardPool;
        
        // private List<Supports> _towers = new();
        
        // private List<Perks> _towers = new();
        
        public static Citadel GetInstance { get; private set; }

        protected override void Awake() {
            base.Awake();
            _sharedBaseTowerStats = GetComponent<CitadelTowerStats>();
        }
    
        private void Start() {
            _citadelTowers = GetComponent<ITowerOperator>();
            _citadelTowers.OnTowerBuild += AddStatsToTower;
            OperateStartingTower();
        }

        private void OperateStartingTower() {
            _citadelTowers.UnlockSlot();
            _citadelTowers.OperateChosenCard(_cardPool.GetTowerByType(_startingTowerType));
        }

        private void AddStatsToTower(Tower tower) {
            foreach (var towerStat in _sharedBaseTowerStats.getAllStats()) {
                var statType = towerStat.Value.getStatType();
                _citadelTowers.AddStatFromCitadel(statType, towerStat.Value);
            }
        }

        public void AddFightingStatToCitadel(TowerStatType type, float statValue) {
            Debug.Log("We are adding stat to Citadel, stat: " + type + " value: " + statValue);
            TowerStat stat = _sharedBaseTowerStats.getStatByType(type);
            Debug.Log("Stat before increasing: " + stat);
            stat.IncreaseMaxValue(statValue);
            Debug.Log("Stat after increasing: " + stat);
            AddStatToTowers(type, stat);
        }

        private void AddStatToTowers(TowerStatType type, TowerStat stat) {
            Debug.Log("we are adding stats to towers");
                _citadelTowers.AddStatForEachTower(type, stat);
        }

        public void CardChoseHandle(CardInfo chosenCard) {
            if (chosenCard.type.Equals(CardType.Tower)) {
                _citadelTowers.OperateChosenCard(chosenCard);
            }
        }

        public void UnlockTowerSlot() {
            _citadelTowers.UnlockSlot();
        }

        public void BuildTower(TowerCardInfo towerCardInfo) {
            _citadelTowers.OperateChosenCard(towerCardInfo);
        }
    }
}