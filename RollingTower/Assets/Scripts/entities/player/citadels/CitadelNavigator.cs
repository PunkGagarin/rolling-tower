using UnityEngine;

namespace entities.player.citadels {

    public class CitadelNavigator : MonoBehaviour {
        
        //todo: Вспомнить нафига он нужен
        private float offset;

        private Vector3 direction;
        
        private float rotZ;
        
        
        private Camera _mainCamera;

        
        private void Awake() {
            _mainCamera = Camera.main;
        }

        public void Update() {
            NavigateCitadel();
        }
        
        private void NavigateCitadel() {
            direction = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(direction.x, direction.y) * -Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        
        
    }

}