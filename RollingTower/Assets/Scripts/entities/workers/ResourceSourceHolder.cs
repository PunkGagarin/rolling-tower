using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ResourceSourceHolder : MonoBehaviour {
    [FormerlySerializedAs("_resourceSources")] [SerializeField]
    public List<ResourceSource> resourceSources;

    public static ResourceSourceHolder GetInstance;

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

    public List<ResourceSource> GetListOfResources() => resourceSources;

    public ResourceSource GetResourceSourceByType(ResourceType resourceType) =>
        resourceSources.FirstOrDefault(r => r.resourceType.Equals(resourceType));
}