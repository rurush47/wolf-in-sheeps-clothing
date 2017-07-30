using UnityEngine;

public class AnimalController : MonoBehaviour {
	public float Speed = 6.0F;
    public float Gravity = 20.0F;
    public Vector3 StopRotatingVector;
    public bool ControlledByPlayer = true;
    protected Vector3 _moveDirection = Vector3.zero;
    public string Horizontal = "Horizontal_1";
    public string Vertical = "Vertical_1";
    public string AttackButton = "Jump_1";
    public string WofButton = "Wof_1";
    public Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update() {
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

        _moveDirection.y -= Gravity* Time.deltaTime;
        controller.Move(_moveDirection * Time.deltaTime);

        Vector3 facingrotation = Vector3.Normalize(new Vector3(Input.GetAxis(Horizontal),
            0f,
            Input.GetAxis(Vertical)));

        if (facingrotation != StopRotatingVector)
        {
            transform.rotation = Quaternion.LookRotation(_moveDirection);
            Animator.SetBool("move", true);
        }
        else
        {
            Animator.SetBool("move", false);
        }
    }

    public void OnDestroy()
    {
        // stop being tracked by camera
        CameraController.Instance.RemoveTarget(gameObject.transform);
        // unregister from the list of active characters
        GameplayManager.Instance.Players.Remove(gameObject);
    }

}
