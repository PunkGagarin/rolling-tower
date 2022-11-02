using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ResourceIconFactory", fileName = "ResourceIconFactory")]
public class ResourceIconFactory : ScriptableObject {
    [SerializeField]
    private List<ResourceIconWithTypeModel> _resourcesIcon;

    public Sprite GetResourceIconByType(ResourceType resourceType) =>
        _resourcesIcon.Find(r => r.resourceType.Equals(resourceType)).sprite;

    [Serializable]
    public class ResourceIconWithTypeModel {
        [field: SerializeField]
        public Sprite sprite { get; private set; }

        [field: SerializeField]
        public ResourceType resourceType { get; private set; }
    }
}