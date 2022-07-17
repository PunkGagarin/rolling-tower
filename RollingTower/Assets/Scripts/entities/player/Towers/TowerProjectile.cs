using System;
using UnityEngine;

public class TowerProjectile : MonoBehaviour {

    [SerializeField]
    private float _baseSpeed = 30f;

    [SerializeField]
    private float _lifeTime = 2f;

    private LayerMask _enemyLayer;

    private Tower _towerOwner;

    private void Awake() {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void Start() {
        Invoke(nameof(DestroyBullet), _lifeTime);
    }

    public void Init(Tower owner) {
        _towerOwner = owner;
    }

    private void Update() {
        transform.Translate(Vector2.up * (_baseSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.gameObject.layer == _enemyLayer) {
            Debug.Log("We hit an enemy");
            _towerOwner.DamageEnemy(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void DestroyBullet() {
        Destroy(gameObject);
    }
}