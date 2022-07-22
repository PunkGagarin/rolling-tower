using System;
using System.Collections.Generic;
using Entities.Citadels.Towers;
using entities.player.towers;
using enums.towers;
using UnityEngine;

namespace entities.player.citadels {

    public class Citadel : CitadelHealthUnit {

        [SerializeField]
        private Tower _startingTowerPrefab;

        private CitadelTowerStats _sharedBaseTowerStats;

        private List<CustomKeyValue<int, TowerSlot>> _towerSlots = new();

        //TODO: should we have towers here or we should call them through towerSlots??
        private List<Tower> _towers = new();

        public static Citadel GetInstance;


        protected override void Awake() {
            if (GetInstance == null) {
                GetInstance = this;
            }

            base.Awake();
            _sharedBaseTowerStats = GetComponent<CitadelTowerStats>();
            FindAllTowerSlots();
            InitFirstSlot();
        }

        private void FindAllTowerSlots() {
            var slots = GetComponentsInChildren<TowerSlot>(true);
            for (int i = 1; i <= slots.Length; i++) {
                var towerSlot = slots[i - 1];
                towerSlot.InitSlot(this);
                _towerSlots.Add(new CustomKeyValue<int, TowerSlot>(i, towerSlot));
            }
        }

        private void InitFirstSlot() {
            if (_startingTowerPrefab == null) {
                Debug.Log("There is no StartingTower!!!!!");
            }
            var tower = UnlockTowerSlot(0).AddTowerWithInstantiate(_startingTowerPrefab);
            _towers.Add(tower);
        }

        public TowerSlot UnlockTowerSlot(int slotNumber) {
            if (slotNumber > _towerSlots.Count || slotNumber < 0) {
                Debug.Log("Wrong slot number: " + slotNumber + "there is only " + _towerSlots.Count +
                          " slots in this citadel");
                throw new Exception("No such slot number");
            }
            TowerSlot slotToUnlock = _towerSlots[slotNumber].value;
            if (slotToUnlock.isUnlocked) {
                throw new Exception("This slot is already unlocked!!!");
            }
            slotToUnlock.gameObject.SetActive(true);
            slotToUnlock.unlockSlot();
            return slotToUnlock;
        }

        //todo: should we move it to TowerSlot or not?
        public void AddTower(Tower towerPrefab, int slotNumber) {
            //possible bug because of slotNUmber index
            var tower = _towerSlots[slotNumber-1].value.AddTowerWithInstantiate(towerPrefab);
            _towers.Add(tower);
            foreach (var towerStat in _sharedBaseTowerStats.getAllStats()) {
                var statType = towerStat.Value.getStatType();
                tower.AddStatFromCitadel(statType, towerStat.Value);
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
            foreach (var tower in _towers) {
                tower.AddStatFromCitadel(type, stat);
            }
        }
    }

}