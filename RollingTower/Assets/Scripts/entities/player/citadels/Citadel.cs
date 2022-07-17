using System;
using System.Collections.Generic;
using entities.bases;
using Entities.Citadels;
using enums.citadels;
using UnityEngine;

namespace entities.player.citadels {

    public class Citadel : CitadelHealthUnit {

        [SerializeField]
        private Tower _startingTower;

        private List<CustomKeyValue<int, TowerSlot>> _towerSlots = new();

        //todo: or towerSlots???
        private List<CustomKeyValue<int, Tower>> _towers = new();

        protected override void Awake() {
            base.Awake();
            FindAllTowerSlots();
            InitFirstSlot();
        }

        private void FindAllTowerSlots() {
            var slots = GetComponentsInChildren<TowerSlot>(true);
            for (int index = 0; index < slots.Length; index++) {
                var towerSlot = slots[index];
                _towerSlots.Add(new CustomKeyValue<int, TowerSlot>(index, towerSlot));
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
    }

}