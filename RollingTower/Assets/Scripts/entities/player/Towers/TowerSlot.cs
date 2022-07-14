using UnityEngine;

public class TowerSlot : MonoBehaviour {

    private Tower _tower;

    [field: SerializeField]
    private bool isUnlocked { get; set; }


    public void AddTower(Tower tower) {
        _tower = tower;
        //todo: updateUIMethod 
    }

    public bool unlockSlot() {
        if (isUnlocked) {
            Debug.Log("Slot is already unlocked!");
            return false;
        }
        isUnlocked = true;
        return true;
    }
}