using UnityEngine;

public class WorkersUIHudHolder : MonoBehaviour {
    public static WorkersUIHudHolder GetInstance;

    private void Awake() {
        GetInstance = this;
    }
}
