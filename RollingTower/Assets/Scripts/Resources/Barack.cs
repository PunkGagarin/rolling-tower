using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Barack : MonoBehaviour {
    [SerializeField]
    private Worker _workerPrefab;

    [SerializeField]
    private ChooseWorkersJobUI _workersJobUI;

    [SerializeField]
    private Transform _parent;

    [Space] [SerializeField]
    private List<Transform> _worketsPlacesToSpawn;

    [SerializeField]
    private Button _returnWorkers;

    [Space] [SerializeField]
    private int _workerCount;

    private readonly List<Worker> _workers = new();
    private List<Transform> _worketsFreePlacesToSpawn = new();

    private void Awake() {
        _returnWorkers.onClick.AddListener(ReturnAllWorkers);
        _workersJobUI.OnWorkerSpawnButtonClick += SpawnWorkers;
        _workersJobUI.Init(_workerCount);
    }

    private void SpawnWorkers(List<ResourceType> resourcesToTake) {
        _returnWorkers.gameObject.SetActive(true);
        _worketsFreePlacesToSpawn = new List<Transform>(_worketsPlacesToSpawn);
        foreach (var resourceToTake in resourcesToTake) {
            SpawnWorker(resourceToTake);
        }
    }

    private void SpawnWorker(ResourceType resourceToTake) {
        var worker = Instantiate(_workerPrefab, _parent.transform.position, Quaternion.identity);
        worker.Init(resourceToTake);
        worker.transform.position = GetPlaceToSpawnWorker().position;
        _workers.Add(worker);
    }

    private void ReturnAllWorkers() {
        foreach (var worker in _workers) {
            worker.ReturnToBase();
        }
    }

    private Transform GetPlaceToSpawnWorker() {
        if (_worketsFreePlacesToSpawn.Count == 0) {
            throw new IndexOutOfRangeException("Have no free place to spawn");
        } else {
            var place = _worketsFreePlacesToSpawn[Random.Range(0, _worketsFreePlacesToSpawn.Count)];
            _worketsFreePlacesToSpawn.Remove(place);
            return place;
        }
    }

    private void OnDestroy() {
        _returnWorkers.onClick.RemoveListener(ReturnAllWorkers);
        _workersJobUI.OnWorkerSpawnButtonClick -= SpawnWorkers;
    }
}