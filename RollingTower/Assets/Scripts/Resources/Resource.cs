using System;
using UnityEngine;

public class Resource {
    public ResourceType type { get; private set; }

    public Sprite icon { get; private set; }

    public Resource(ResourceType resourceType, Sprite icon) {
        type = resourceType;
        this.icon = icon;
    }
}
