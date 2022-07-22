using entities.player.towers;
using UnityEngine;


    //TODO: remove this script after tests
public class TowerProjectile : MonoBehaviour {

    [SerializeField]
    private float _baseSpeed = 30f;

    [SerializeField]
    private float _lifeTime = 2f;

    private Tower _towerOwner;

    private float _bonusProjectileSpeed;

    private LayerMask _enemyLayer;

    private void Awake() {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void Start() {
        Invoke(nameof(DestroyProjectile), _lifeTime);
    }

    public void Init(Tower owner) {
        _towerOwner = owner;
        _bonusProjectileSpeed = _towerOwner.GetProjectileSpeed();
    }

    private void Update() {
        MoveProjectile();
    }

    private void MoveProjectile() {
        transform.Translate(Vector2.up * ((_baseSpeed + _bonusProjectileSpeed) * Time.deltaTime));
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == _enemyLayer) {
            // Debug.Log("We hit an enemy");
            _towerOwner.DealDamage(other.gameObject.GetComponent<IDamageable>());
            DestroyProjectile();
        }
    }


    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}