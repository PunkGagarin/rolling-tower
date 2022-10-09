using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameResourceStorage : MonoBehaviour {
    [SerializeField]
    private CurrentResourcesCountUI _resourceCountUI;

    private Dictionary<ResourceType, Queue<Resource>> _resources = new() {
        {ResourceType.Iron, new Queue<Resource>()},
        {ResourceType.Wood, new Queue<Resource>()},
        {ResourceType.Magic, new Queue<Resource>()},
        {ResourceType.Empty, new Queue<Resource>()}
    };

    public Action<ResourceType, float> OnResourceUpdate = delegate{  };

    public static InGameResourceStorage GetInstance;

    private void Awake() {
        GetInstance = this;
        OnResourceUpdate += _resourceCountUI.UpdateResourceByType;
    }

    public void AddResourceToStorage(Resource resource) {
        _resources[resource.type].Enqueue(resource);
        OnResourceUpdate?.Invoke(resource.type, _resources[resource.type].Count);
    }

    public bool SpendResources(float count, ResourceType type) {
        var resourceList = _resources[type];
        if (count > resourceList.Count) {
            return false;
        }
        for (int i = 0; i < count; i++) {
            resourceList.Dequeue();
        }
        OnResourceUpdate?.Invoke(type, resourceList.Count);
        return true;
    }

    public Queue<Resource> GetResourceByType(ResourceType type) {
        return _resources[type];
    }
}