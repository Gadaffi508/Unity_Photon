using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationX = 0;

    [HideInInspector] public bool canMove = true;
    [SerializeField] private float _cameraYOffset = 0.4f;
    private Camera _playerCamera;

    private Alteruna.Avatar _avatar;

    private void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe) return;

        _characterController = GetComponent<CharacterController>();
        _playerCamera = Camera.main;
        _playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + _cameraYOffset,
            transform.position.z);
        _playerCamera.transform.SetParent(transform);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!_avatar.IsMe) return;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = _moveDirection.y;
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetKeyDown(KeyCode.Space) && canMove && _characterController.isGrounded)
        {
            _moveDirection.y = jumpSpeed;
        }
        else
        {
            _moveDirection.y = movementDirectionY;
        }

        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        _characterController.Move(_moveDirection * Time.deltaTime);

        _rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        _playerCamera.transform.localRotation =
            Quaternion.Euler(_rotationX, 0, 0) * Quaternion.Euler(0, transform.localEulerAngles.y, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}