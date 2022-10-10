using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrentResourcesHudHolder : MonoBehaviour {

    [SerializeField]
    private GameObjectCreator<UIResourceInGameHud> _gameObjectCreator;

    [SerializeField]
    private ResourceSourceHolder _resourceSourceHolder;

    private readonly List<UIResourceInGameHud> _allResources = new();
    private UIResourceInGameHud _currentResourceUI;

    private void Awake() {
        foreach (var resourceSource in _resourceSourceHolder.resourceSources) {
            var panel = _gameObjectCreator.CreatePanel();
            panel.Init(resourceSource.resourceIcon, resourceSource.resourceType);
            _allResources.Add(panel);
        }
    }

    public void UpdateResourceByType(ResourceType resourceType, float count) {
        _currentResourceUI = _allResources.FirstOrDefault(r => r.type.Equals(resourceType));
        _currentResourceUI?.SetResourceCount(count);
    }
}