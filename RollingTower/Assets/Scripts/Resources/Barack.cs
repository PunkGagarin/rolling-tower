using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Barack : MonoBehaviour {
    [SerializeField]
    private Worker _workerPrefab;

    [SerializeField]
    private ChooseWorkersJobUIController workersJobUIController;

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private Button _returnWorkers;

    [Space] [SerializeField]
    private int _workerCount;
    
    [Space][SerializeField]
    private PlacesForSpawn _placesForSpawn;

    private readonly List<Worker> _workers = new();

    private void Awake() {
        _returnWorkers.onClick.AddListener(ReturnAllWorkers);
        workersJobUIController.OnWorkerSpawnButtonClick += SpawnWorkers;
        workersJobUIController.Init(_workerCount);
    }

    private void SpawnWorkers(List<ResourceType> resourcesToTake) {
        _returnWorkers.gameObject.SetActive(true);
        _placesForSpawn.FreeAllPlaces();
        foreach (var resourceToTake in resourcesToTake) {
            SpawnWorker(resourceToTake);
        }
    }

    private void SpawnWorker(ResourceType resourceToTake) {
        var worker = Instantiate(_workerPrefab, _parent.transform.position, Quaternion.identity);
        worker.Init(resourceToTake);
        worker.transform.position = _placesForSpawn.GetFreePlaceToSpawn().position;
        _workers.Add(worker);
    }

    private void ReturnAllWorkers() {
        foreach (var worker in _workers) {
            worker.ReturnToBase();
        }
    }

    private void OnDestroy() {
        _returnWorkers.onClick.RemoveListener(ReturnAllWorkers);
        workersJobUIController.OnWorkerSpawnButtonClick -= SpawnWorkers;
    }
}