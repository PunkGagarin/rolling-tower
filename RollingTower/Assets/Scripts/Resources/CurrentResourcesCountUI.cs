using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CurrentResourcesCountUI : MonoBehaviour {
    [SerializeField]
    private List<SerializableCurrentResourceCountUI> _allResources;

    private SerializableCurrentResourceCountUI _currentResourceUI;

    public void UpdateResourceByType(ResourceType resourceType, float count) {
        _currentResourceUI = _allResources.FirstOrDefault(r => r.type.Equals(resourceType));
        _currentResourceUI?.SetResourceCount(count);
    }
}

[System.Serializable]
public class SerializableCurrentResourceCountUI {
    [field: SerializeField]
    public ResourceType type;
    
    [SerializeField]
    private TextMeshProUGUI _text;

    public void SetResourceCount(float count) {
        _text.text = count.ToString();
    }
}