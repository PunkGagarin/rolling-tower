using entities.player.citadels;
using entities.player.towers;
using UnityEngine;

public class TowerSlot : MonoBehaviour {

    private Tower _tower;

    [field: SerializeField]
    public bool isUnlocked { get; private set; }

    public bool _isFree { get; private set; } = true;

    public void AddTower(Tower towerPrefab) {
        _tower = towerPrefab;
        //todo: updateUIMethod 
        _isFree = false;
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