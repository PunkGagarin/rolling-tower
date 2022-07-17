using UnityEngine;

namespace entities.Enemy.Movement {

    public class SimpleStraightMoveTranslateBehaviour : AbstractMovement {


        public override void Move() {
            var direction = _targetTransform.position - _ownerTransform.position;
            direction.Normalize();

            //Todo: find proper way to rotate, probably rotate one time at the start of the movement, not rotate EACH frame;
            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _ownerTransform.rotation = Quaternion.Euler(0f, 0f, rotZ);

            _ownerTransform.Translate(Vector2.right * (_speed * Time.deltaTime));
        }
    }

}