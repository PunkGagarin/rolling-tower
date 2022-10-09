using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Barack : MonoBehaviour {
    
    [SerializeField]
    private Worker _workerPrefab;
    
    [SerializeField]
    private List<Worker> _workers;

    [SerializeField]
    private List<ResourceType> _resourcesToExtract;

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private List<Transform> _worketsPlacesToSpawn;
    
    private List<Transform> _worketsFreePlacesToSpawn = new();

    [SerializeField]
    private Button _spawnWorkers;
    
    [SerializeField]
    private Button _returnWorkers;

    private void Awake() {
        _spawnWorkers.onClick.AddListener(SpawnWorkers);
        _returnWorkers.onClick.AddListener(ReturnAllWorkers);
    }

    public void SpawnWorkers() {
        _worketsFreePlacesToSpawn = new List<Transform>(_worketsPlacesToSpawn);
        foreach (var _resourceType in _resourcesToExtract) {
            var worker = Instantiate(_workerPrefab,_parent.transform.position, Quaternion.identity);
            worker.Init(_resourceType);
            worker.transform.position = GetPlaceToSpawnWorker().position;
            _workers.Add(worker);
        }
    }

    public void ReturnAllWorkers() {
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
}