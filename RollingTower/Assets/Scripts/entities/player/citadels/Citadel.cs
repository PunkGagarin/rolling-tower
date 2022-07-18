using System.Collections.Generic;
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

        public void ChangeTowersRadius(float radius) {
            Debug.Log("Changing radius from citadel");
            foreach (var tower in _towers) {
                tower.value.ChangeAttackRadius(radius);
            }
        }
    }

}