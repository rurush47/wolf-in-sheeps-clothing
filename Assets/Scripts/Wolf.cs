using System.Collections.Generic;
using UnityEngine;

public class Wolf : AnimalController
{
    private BoxCollider _attackCollider;
    public float GlowTime;
    public List<Light> Eyes;

    private float _currentGlowingTime;
    private bool _eyesGlowing;
    
    void Start()
    {
        _currentGlowingTime = GlowTime;
    }

    private void Update()
    {
        if (!ControlledByPlayer) return;
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            float h = Input.GetAxis(Horizontal);
            float v = Input.GetAxis(Vertical);

            _moveDirection = (h * right + v * forward);
            _moveDirection *= Speed;
        }

        _moveDirection.y -= Time.deltaTime;
        controller.Move(_moveDirection * Time.deltaTime);

        Vector3 facingrotation = Vector3.Normalize(new Vector3(Input.GetAxis(Horizontal),
            0f,
            Input.GetAxis(Vertical)));

        if (facingrotation != StopRotatingVector)
        {
            transform.rotation = Quaternion.LookRotation(_moveDirection);
        }
        
        if (_eyesGlowing)
        {
            if (_currentGlowingTime > 0)
            {
                _currentGlowingTime -= Time.deltaTime;
            }
            else
            {
                EyesOff();
                _currentGlowingTime = GlowTime;
                _eyesGlowing = false;
            }    
        }
    }

    public void EyesOn()
    {
        foreach (var eye in Eyes)
        {
            _eyesGlowing = true;
            eye.gameObject.SetActive(true);
        }
    }
    
    private void EyesOff()
    {
        foreach (var eye in Eyes)
        {
            eye.gameObject.SetActive(false);
        }
    }
}