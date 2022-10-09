using System;
using System.Collections.Generic;

public class WorkerBackPack {
    public Action<int, ResourceType> OnValueChange = delegate { };
    public Action OnFilled = delegate {};
    public Action OnEmpty = delegate {};
    
    private Queue<Resource> _resources = new();
    private WorkerStat _capacity;

    public WorkerBackPack(WorkerStat capacity) {
        _capacity = capacity;
    }

    public void AddResource(Resource resource) {
        if (!(_resources.Count + 1 <= _capacity.currentValue)) return;
        
        _resources.Enqueue(resource);
        OnValueChange?.Invoke(1, resource.type);
        if(_resources.Count == _capacity.currentValue)
            OnFilled?.Invoke();
    }

    public Resource GetResource() {
        if (_resources.Count == 1) {
            OnEmpty?.Invoke();
        }
        var resource = _resources.Dequeue();
        OnValueChange?.Invoke(-1, resource.type);
        return resource;
    }

    public bool IsEmpty() => _resources.Count == 0;

    public float workerCapacity => _capacity.currentValue;
}