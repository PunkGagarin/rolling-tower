using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour {

    protected Transform _targetTransform;
    protected bool _isMove = true;
    protected float _speed;
    protected float _stopDistance;
    protected LayerMask _targetLayer;

    protected void InitDefaultStats(float speed, float stopDistance, Transform target) {
        _speed = speed;
        _stopDistance = stopDistance;
        _targetTransform = target;
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