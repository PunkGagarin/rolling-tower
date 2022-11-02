using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceSourceHolder : MonoBehaviour {
    [SerializeField]
    public List<ResourceSource> resourceSources;

    public static ResourceSourceHolder GetInstance { get; private set; }

    private void Awake() {
        GetInstance = this;
    }

    public ResourceSource GetFreeResourceSourceByType(ResourceType resourceType) {
        foreach (var resourceSource in resourceSources) {
            if (!resourceSource.isEmpty && resourceSource.resourceType == resourceType) {
                return resourceSource;
            }
        }
        return null;
    }

    public List<ResourceType> GetResourcesType() {
        List<ResourceType> resourceTypes = new();
        foreach (var resourceType in resourceSources) {
            resourceTypes.Add(resourceType.resourceType);
        }
        return resourceTypes;
    }

    public ResourceSource GetResourceSourceByType(ResourceType resourceType) =>
        resourceSources.FirstOrDefault(r => r.resourceType.Equals(resourceType));
}