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

        //todo: or towerSlots???
        private List<CustomKeyValue<int, Tower>> _towers;

        private List<CustomKeyValue<int, TowerSlot>> _towerSlots;

        private void Awake() {
            InitFirstSlot();
        }

        private void InitFirstSlot() {
            if (_startingTower == null) {
                Debug.Log("There is no StartingTower!!!!!");
            }
            _towers.Add(new CustomKeyValue<int, Tower>(0, _startingTower));
            _towerSlots[0].value.unlockSlot();
            _towerSlots[0].value.AddTower(_startingTower);
        }
    }

}