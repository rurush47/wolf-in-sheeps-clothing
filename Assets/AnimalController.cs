using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {
	public float Speed = 6.0F;
        public float Gravity = 20.0F;
        private float rot = 0.0f;
        private Vector3 _moveDirection = Vector3.zero;
    
        void Update() {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded) {
                Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
                forward.y = 0;
                forward = forward.normalized;
                Vector3 right  = new Vector3(forward.z, 0, -forward.x);
                float h = Input.GetAxis("Horizontal");
                float v =Input.GetAxis("Vertical");
             
                _moveDirection  = (h * right  + v * forward);
                _moveDirection *= Speed;
            }
 
            _moveDirection.y -= Gravity * Time.deltaTime;
            controller.Move (_moveDirection * Time.deltaTime);
        }
}
