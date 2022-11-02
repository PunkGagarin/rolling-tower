using System;
using UnityEngine;

[Serializable]
public class PlaceForSpawn {
    public bool IsFree { get; set; }

    [field: SerializeField]
    public Transform position { get; private set; }
}