using entities.player.citadels;
using entities.player.towers;
using UnityEngine;

public class TowerSlot : MonoBehaviour {

    private Tower _tower;

    private Citadel _citadelOwner;

    [field: SerializeField]
    public bool isUnlocked { get; private set; }

    public void InitSlot(Citadel citadel) {
        _citadelOwner = citadel;
    }


    public Tower AddTowerWithInstantiate(Tower towerPrefab) {
        //todo: updateUIMethod 
        _tower = Instantiate(towerPrefab, transform);
        return _tower;
    }

    public bool unlockSlot() {
        if (isUnlocked) {
            Debug.Log("Slot is already unlocked!");
            return false;
        }
        //todo: add UI to unlock, probably some VFX
        isUnlocked = true;
        return true;
    }
}