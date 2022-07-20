using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour {
    [SerializeField]
    protected float _speed;
    
    protected bool _isMove = true;
    protected LayerMask _targetLayer;
    protected IDamageDealer _damageDealer;
    protected float _moveSpeedMultiplier;

    public virtual void Init(AbstractProjectileDTO projectileDto) {
        _targetLayer = projectileDto.targetLayer;
        _damageDealer = projectileDto.damageDealer;
        _moveSpeedMultiplier = projectileDto.moveSpeedMultiplier;
    }

    protected abstract void ProjectileMove();
    
    protected void LookAtPos(Vector2 direction) {
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Update() {
        if (_isMove) {
            ProjectileMove();
        }
    }
    
    protected void DestroyProjectile() {
        Destroy(gameObject);
    }

    protected abstract void Hit();
}