using UnityEngine;

public class WorkerView : MonoBehaviour{

    [SerializeField]
    private WorkerHudUI _workerHudPrefab;
    
    private WorkerHudUI _workerHud;

    public void SpawnWorkerView(WorkerBackPack backPack ,Sprite resourceSprite) {
        _workerHud = GameObject.Instantiate(_workerHudPrefab, WorkersUIHudHolder.GetInstance.transform);
        _workerHud.Init(transform, backPack, resourceSprite);
    }

    public void DestroyHud() {
        Destroy(_workerHud.gameObject);
    }

    public void Tick() {
        _workerHud.SetPosition();
    }
}