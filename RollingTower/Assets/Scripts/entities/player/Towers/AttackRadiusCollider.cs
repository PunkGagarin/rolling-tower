using System;
using UnityEngine;

public class AttackRadiusCollider : MonoBehaviour {

    //todo: find the way to change it from code(radius)

    private Tower _owner;

    private LayerMask _enemyLayer;

    private void Awake() {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        _owner = GetComponentInParent<Tower>();
    }

    private void Start() {
        Debug.Log("enemyLayer for attack: " + _enemyLayer);
        Debug.Log("_owner: " + _owner.transform.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Smth enter our collider" + other.gameObject.layer);
        if (other.gameObject.layer == _enemyLayer)
            _owner.AddEnemyInRange(other.GetComponent<Enemy>());
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == _enemyLayer)
            _owner.RemoveEnemyInRange(other.GetComponent<Enemy>());
    }
}