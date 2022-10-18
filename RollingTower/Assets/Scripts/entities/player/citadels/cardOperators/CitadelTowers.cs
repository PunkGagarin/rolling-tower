using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Citadels.Towers;
using entities.player.citadels.cardOperators;
using entities.player.towers;
using enums.gameSession.cards;
using enums.towers;
using gameSession.cards.cardInfo;
using UnityEngine;

namespace entities.player.citadels {

    public class CitadelTowers : AbstractCardOperator, ITowerOperator, ICardHolder {

        public event Action<Tower> OnTowerBuild = delegate { };


        private readonly List<Tower> _towers = new();

        private List<CustomKeyValue<int, TowerSlot>> _towerSlots = new();

        private TowerCardInfo _cardInfoToOperate;

        private void Awake() {
            FindAllTowerSlots();
        }

        private void FindAllTowerSlots() {
            var slots = GetComponentsInChildren<TowerSlot>(true);
            for (int i = 1; i <= slots.Length; i++) {
                var towerSlot = slots[i - 1];
                _towerSlots.Add(new CustomKeyValue<int, TowerSlot>(i, towerSlot));
            }
        }

        public void InitFirstSlot(Tower startTowerPrefab) {
            if (startTowerPrefab == null) {
                Debug.Log("There is no StartingTower!!!!!");
            }
            var slot = UnlockSlot();
            Tower tower = Instantiate(startTowerPrefab, slot.transform);
            UnlockSlot().AddTower(tower);
            _towers.Add(tower);
        }

        public TowerSlot UnlockSlot() {
            var firstOrDefault = _towerSlots.FirstOrDefault(el => !el.value.isUnlocked);
            if (firstOrDefault == null) {
            }
            TowerSlot slotToUnlock = firstOrDefault?.value;
            if (slotToUnlock.isUnlocked) {
                throw new Exception("This slot is already unlocked!!!");
            }
            slotToUnlock.gameObject.SetActive(true);
            slotToUnlock.unlockSlot();
            return slotToUnlock;
        }

        //todo: should we move it to TowerSlot or not?
        private void BuildTower(Tower towerPrefab) {
            TowerSlot slot = FindFirstAvailableSlot();
            Tower tower = Instantiate(towerPrefab, slot.transform);
            slot.AddTower(towerPrefab);
            _towers.Add(tower);

            OnTowerBuild.Invoke(tower);
        }

        private TowerSlot FindFirstAvailableSlot() {
            var firstAvailableSlot = _towerSlots.FirstOrDefault(value => value.value._isFree && value.value.isUnlocked);
            if (firstAvailableSlot == null) {
                Debug.Log("Trying to find free slot, but there is not slot available!");
                throw new Exception("Trying find slot, but no slot available!");
            }
            return firstAvailableSlot.value;
        }

        public override void OperateChosenCard(CardInfo cardInfo) {
            _cardInfoToOperate = cardInfo as TowerCardInfo;
            base.OperateChosenCard(_cardInfoToOperate);
        }

        public override bool CardExists() {
            TowerCardInfo info = _cardInfoToOperate;
            return _towers.Exists(el => el.type.Equals(info.towerType));
        }

        public override void UpgradeCard() {
            var currentTower = FindTowerByType(_cardInfoToOperate.towerType);
            currentTower.UpgradeLevel();
        }

        private Tower FindTowerByType(TowerType type) {
            var currentTower = _towers.FirstOrDefault(el => el.type.Equals(_cardInfoToOperate.towerType));
            if (currentTower == null) {
                Debug.Log("Trying to upgrade non-existing tower!");
                throw new Exception("Trying to upgrade non-existing tower!");
            }
            return currentTower;
        }

        public override void CreateCard() {
            BuildTower(_cardInfoToOperate.prefab);
        }

        public void AddStatFromCitadel(TowerStatType type, TowerStat stat) {
            var currentTower = FindTowerByType(_cardInfoToOperate.towerType);
            currentTower.AddStatFromCitadel(type, stat);
        }

        public void AddStatForEachTower(TowerStatType type, TowerStat stat) {
            foreach (var tower in _towers) {
                tower.AddStatFromCitadel(type, stat);
            }
        }

        public bool IsCardFreeSlotsLeft() {
            return _towerSlots.Exists(pair => pair.value._isFree);
        }
        
        public List<TowerType> GetCurrentCardTypes() {
            return _towers.Select(el => el.type).ToList();
        }

        public List<CustomKeyValue<CardType, IConvertible>> GetMaxedCards() {
            //todo: implement for perks and supports
            var list = _towers.FindAll(el => el.IsMaxLevel())
                .Select(el => new CustomKeyValue<CardType, IConvertible>(CardType.Tower, el.type))
                .ToList();
        
            return list;
        }

        public bool IsMaxLevelExists() {
            return _towers.Exists(el => el.IsMaxLevel());
        }
    }

}