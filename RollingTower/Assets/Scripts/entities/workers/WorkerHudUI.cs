using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkerHudUI : MonoBehaviour {
    private List<ResourceInWorkerHud> _allResources = new();

    [SerializeField]
    private Camera _camera;
    
    [SerializeField]
    private Transform _worker;

    [SerializeField]
    private float _dopY;

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private ResourceInWorkerHud _resourcePrefab;

    private int _currentResourceCount = -1;
    private ResourceInWorkerHud _previousResource;

    public void Init(Transform workerTransform, WorkerBackPack backPack, Sprite resourceIcon) {
        _worker = workerTransform;
        SpawnResources(backPack.workerCapacity, resourceIcon);
        backPack.OnValueChange += GlowCorrectCountOfResource;
        _camera = Camera.main;
        SetPosition();
    }

    public void SetPosition() {
        transform.position = GetCameraWorldToScreenPoint();
    }

    private void SpawnResources(float count, Sprite resourceIcon) {
        for (int i = 0; i < count; i++) {
            var resource = Instantiate(_resourcePrefab, _parent);
            resource.SetImage(resourceIcon);
            resource.SetActivity(false);
            _allResources.Add(resource);
        }
    }

    private void GlowCorrectCountOfResource(int value, ResourceType resourceType) {
        if(resourceType.Equals(ResourceType.Empty)) return;
        
        if (value == -1) {
            _allResources[_currentResourceCount].SetActivity(false);    
            _currentResourceCount += value;
        }
        else if (value == 1) {
            _currentResourceCount += value;
            _allResources[_currentResourceCount].SetActivity(true);
        }
    }
    
    private Vector3 GetCameraWorldToScreenPoint() {
        return _camera.WorldToScreenPoint(_worker.transform.position + Vector3.up * _dopY);
    }
}