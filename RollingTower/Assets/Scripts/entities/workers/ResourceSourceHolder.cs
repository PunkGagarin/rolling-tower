using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceSourceHolder : MonoBehaviour {
    [SerializeField]
    public List<ResourceSource> _resourceSources;

    public static ResourceSourceHolder GetInstance;

    private void Awake() {
        GetInstance = this;
    }

    public ResourceSource GetFreeResourceSourceByType(ResourceType resourceType) {
        foreach (var resourceSource in _resourceSources) {
            if (!resourceSource.isEmpty && resourceSource.resourceType == resourceType) {
                return resourceSource;
            }
        }
        return null;
    }

    public ResourceSource GetResourceSourceByType(ResourceType resourceType) =>
        _resourceSources.FirstOrDefault(r => r.resourceType.Equals(resourceType));
}