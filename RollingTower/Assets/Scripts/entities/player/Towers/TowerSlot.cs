using UnityEngine;

public class TowerSlot : MonoBehaviour {


    [field: SerializeField]
    private bool isUnlocked { get; set; }

    private Tower tower;


    public bool unlockSlot() {
        if (isUnlocked) {
            Debug.Log("Slot is already unlocked!");
            return false;
        }
        isUnlocked = true;
        return true;
    }


}