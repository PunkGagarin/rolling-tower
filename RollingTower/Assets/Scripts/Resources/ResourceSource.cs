using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceSource : MonoBehaviour {
    
    public Action OnEmpty = delegate {};
    
    [SerializeField]
    private SpriteRenderer _image;

    [SerializeField]
    private Sprite _filledSourceImage;

    [SerializeField]
    private Sprite _emptySourceImage;
    
    [SerializeField]
    private float _extractRange;

    [Space][SerializeField]
    private float _poolSize;

    [SerializeField]
    private ResourceType _resourceType;

    [field: SerializeField]
    public Sprite resourceIcon { get; set; }

    private Queue<Resource> _resources = new();
    public bool isEmpty { get; private set; }

    private void Awake() {
        for (int i = 0; i < _poolSize; i++) {
            _resources.Enqueue(new Resource(_resourceType, resourceIcon));
        }
    }

    public Resource GetResource() {
        SetImageByFill();
        if (_resources.Count == 1) {
            isEmpty = true;
            OnEmpty?.Invoke();
        }
        return _resources.Dequeue();
    }

    private void SetImageByFill() {
        if (_resources.Count - 1 == 0) {
            _image.sprite = _emptySourceImage;
        }
    }

    public float extractRange => _extractRange;
    public ResourceType resourceType => _resourceType;
}