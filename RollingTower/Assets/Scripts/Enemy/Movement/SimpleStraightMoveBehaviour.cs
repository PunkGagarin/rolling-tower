using UnityEngine;

public class SimpleStraightMoveBehaviour : AbstractMovement {
    
    public override void Move() {
        var direction =  _targetTransform.position - _ownerTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        
        _rigidbody2D.rotation = angle;
        _rigidbody2D.MovePosition(_ownerTransform.position + (direction * _speed * Time.deltaTime));
        
    }
}