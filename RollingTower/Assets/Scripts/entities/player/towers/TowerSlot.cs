using entities.player.towers;
using UnityEngine;

public class TowerSlot : MonoBehaviour {

    private Tower _tower;

    [field: SerializeField]
    public bool isUnlocked { get; private set; }


    public void AddTower(Tower tower) {
        _tower = tower;
        //todo: updateUIMethod 
        Instantiate(tower, transform);
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