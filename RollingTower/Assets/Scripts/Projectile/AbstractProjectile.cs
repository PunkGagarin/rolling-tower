using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour {

    protected Transform _targetTransform;
    private bool _isMove = true;
    private float _speed;
    private float _stopDistance;

    protected void InitDefaultStats(float speed, float stopDistance, Transform target) {
        _speed = speed;
        _stopDistance = stopDistance;
        _targetTransform = target;
    }

    protected virtual void ProjectileMove() {
        var speed = _speed * Time.deltaTime;
        var targetPos = _targetTransform.position;
        var ownPos = transform.position;
        transform.position = Vector3.MoveTowards(ownPos, targetPos, speed);

        var direction = targetPos - ownPos;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float directionMagnitude = direction.sqrMagnitude;

        if (directionMagnitude < _stopDistance) {
            Hit();
        }
    }

    private void Update() {
        if (_isMove) {
            ProjectileMove();
        }
    }

    protected virtual void Hit() {
        _isMove = false;
    }
}