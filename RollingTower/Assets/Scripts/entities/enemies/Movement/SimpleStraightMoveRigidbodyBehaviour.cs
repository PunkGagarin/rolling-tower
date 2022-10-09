using UnityEngine;

public class SimpleStraightMoveRigidbodyBehaviour<S,ST> : AbstractMovement<S,ST> where S : BaseStat<S, ST>{
    
    public override void Move() {
        var direction =  _targetTransform.position - _ownerTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        
        
        //todo: Uncoment  _rigidbody2D.rotation = angle;
        // _rigidbody2D.MovePosition(_ownerTransform.position + (direction * _speed * Time.deltaTime));
    }
}