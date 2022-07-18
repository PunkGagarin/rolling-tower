using System;
using System.Collections.Generic;
using Entities.Citadels;
using entities.player.towers;
using enums.citadels;
using enums.towers;
using UnityEngine;

namespace entities.player.citadels {

    public class Citadel : CitadelHealthUnit {

        [SerializeField]
        private Tower _startingTower;

        private List<CustomKeyValue<int, TowerSlot>> _towerSlots = new();

        //todo: or towerSlots???
        private List<CustomKeyValue<int, Tower>> _towers = new();

        public static Citadel GetInstance;


        protected override void Awake() {
            if (GetInstance == null) {
                GetInstance = this;
            }
            
            base.Awake();
            FindAllTowerSlots();
            InitFirstSlot();
        }

        private void FindAllTowerSlots() {
            var slots = GetComponentsInChildren<TowerSlot>(true);
            for (int i = 1; i <= slots.Length; i++) {
                var towerSlot = slots[i-1];
                _towerSlots.Add(new CustomKeyValue<int, TowerSlot>(i, towerSlot));
            }
        }

        private void InitFirstSlot() {
            if (_startingTower == null) {
                Debug.Log("There is no StartingTower!!!!!");
            }
            _towers.Add(new CustomKeyValue<int, Tower>(0, _startingTower));
            var firstTowerSlot = _towerSlots[0].value;
            firstTowerSlot.gameObject.SetActive(true);
            firstTowerSlot.unlockSlot();
            firstTowerSlot.AddTower(_startingTower);
        }

        public void UnlockTowerSlot(int slotNumber) {
            if (slotNumber > _towerSlots.Count || slotNumber <= 0) {
                Debug.Log("Wrong slot number: " + slotNumber + "there is only " + _towerSlots.Count + " slots in this citadel");
                throw new Exception("No such slot number");
            }
            TowerSlot slotToUnlock = _towerSlots[slotNumber].value;
            if (slotToUnlock.isUnlocked) {
                Debug.Log("This slot is already unlocked!!!");
                return;
            }
            slotToUnlock.gameObject.SetActive(true);
            slotToUnlock.unlockSlot();
        }

        public void ChangeTowersRadius(float radius) {
            Debug.Log("Changing radius from citadel");
            foreach (var tower in _towers) {
                tower.value.ChangeAttackRadius(radius);
            }
        }

        //todo: remove after tests
        public void AddTower(Tower tower) {
            _towerSlots[2].value.AddTower(tower);
        }

        public void AddStatToTowers(CitadelStatType type, CitadelStat stat) {
            TowerStatType towerStatType = CitadelStat.ConvertTypeToTower(type);
        }
    }

}