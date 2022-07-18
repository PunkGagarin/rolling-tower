using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackRadiusCollider : MonoBehaviour {

    //todo: find the way to change it from code(radius)

    private Tower _owner;

    private LayerMask _enemyLayer;

    [SerializeField]
    private PolygonCollider2D _radiusCollider;

    private void Awake() {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        _owner = GetComponentInParent<Tower>();

        // Debug.Log("Collider pathCount: " + _radiusCollider.pathCount);
        // Debug.Log("Collider pathCount: " + _radiusCollider.GetPath(0)[0]);
        // Debug.Log("Collider pathCount: " + _radiusCollider.GetPath(0)[_radiusCollider.GetPath(0).Length - 1]);
        
        _radiusCollider.pathCount = 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == _enemyLayer)
            _owner.AddEnemyInRange(other.GetComponent<Enemy>());
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == _enemyLayer)
            _owner.RemoveEnemyInRange(other.GetComponent<Enemy>());
    }

    
    //todo: find proper way or fix this
    public void ChangeRange(float range) {
        var currentPath = _radiusCollider.GetPath(0);
        
        _radiusCollider.enabled = false;
        
        var firstPointPrev = new Vector2(currentPath[0].x - range / 10, currentPath[0].y + range);
        var lastPointPrev = new Vector2(currentPath[^1].x + range / 10, currentPath[^1].y + range);

        currentPath[0] = firstPointPrev;
        currentPath[^1] = lastPointPrev;
        
        _radiusCollider.SetPath(0, currentPath);
        _radiusCollider.enabled = true; 
    }
}