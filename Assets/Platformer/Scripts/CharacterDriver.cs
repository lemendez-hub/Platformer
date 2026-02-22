using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerDriver : MonoBehaviour
{
    [Header("Ground Config")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float groundAcceleration = 15f;

    [Header("Air Config")]
    public float airAcceleration = 0.5f;
    public float apexHeight = 4.5f;
    public float apexTime = 0.5f;

    CharacterController _controller;
    Animator _animator;
    float _xVelocity;
    float _yVelocity;

    Quaternion _facingRight;
    Quaternion _facingLeft;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _facingRight = Quaternion.Euler(0f, 90f, 0f);
        _facingLeft = Quaternion.Euler(0f, -90f, 0f);
    }

    void Update()
    {
        // Poll Input 
        float direction = 0f;
        if (Keyboard.current.aKey.isPressed) direction -= 1f;
        if (Keyboard.current.dKey.isPressed) direction += 1f;

        bool jumpPressedThisFrame = Keyboard.current.spaceKey.wasPressedThisFrame;
        bool jumpHeld = Keyboard.current.spaceKey.isPressed;
        bool runHeld = Keyboard.current.leftShiftKey.isPressed;

        if (_controller.isGrounded) // Ground-based movement
        {
            if (direction != 0f)
            {
                _xVelocity += direction * groundAcceleration * Time.deltaTime;
                transform.rotation = (direction > 0f) ? _facingRight : _facingLeft;
            }
            else
                _xVelocity = Mathf.MoveTowards(_xVelocity, 0f, groundAcceleration * Time.deltaTime);

            if (jumpPressedThisFrame)
            {
                float jumpImpulse = 2f * apexHeight / apexTime;
                _yVelocity = jumpImpulse;
            }
            else if (_yVelocity < 0f)
                _yVelocity = -1f; // Keep it sticky (i.e. stay grounded)
        }
        else // Air-based movement
        {
            float gravity = -2f * apexHeight / (apexTime * apexTime);

            if (!jumpHeld)
                gravity *= 2f;

            _yVelocity += gravity * Time.deltaTime;
            _xVelocity += direction * airAcceleration * Time.deltaTime;
        }

        // Speed Clamping
        float xMaxSpeed = runHeld ? runSpeed : walkSpeed;
        _xVelocity = Mathf.Clamp(_xVelocity, -xMaxSpeed, xMaxSpeed);

        // Apply velocity to change position
        Vector3 deltaPosition = new Vector3(_xVelocity, _yVelocity, 0f) * Time.deltaTime;
        CollisionFlags collisionFlags = _controller.Move(deltaPosition);

        // Reset velocities based on collisions
        if ((collisionFlags & CollisionFlags.Above) != 0 && _yVelocity > 0f)
            _yVelocity = 0f;

        if ((collisionFlags & CollisionFlags.Sides) != 0)
            _xVelocity = 0f;
        _animator.SetFloat("Speed", Mathf.Abs(_xVelocity));
        _animator.SetBool("Grounded", _controller.isGrounded);
    }
}