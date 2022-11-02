using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PlacesForSpawn {

    [SerializeField]
    private List<PlaceForSpawn> _placesForSpawns = new();

    public Transform GetFreePlaceToSpawn() {
        CheckOnFreePlacesForSpawn();
        var place = _placesForSpawns[Random.Range(0, _placesForSpawns.Count)];
        if (!place.IsFree) {
            return GetFreePlaceToSpawn();
        }
        return place.position;
    }

    private void CheckOnFreePlacesForSpawn() {
        bool haveFreePlaces = false;
        foreach (var placeForSpawn in _placesForSpawns) {
            if (placeForSpawn.IsFree) haveFreePlaces = true;
            break;
        }
        if (!haveFreePlaces) {
            throw new Exception("Place for spawn have no free places");
        }
    }

    public void FreeAllPlaces() {
        foreach (var placeForSpawn in _placesForSpawns) {
            placeForSpawn.IsFree = true;
        }
    }
}