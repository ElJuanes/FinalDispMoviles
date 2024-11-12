using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.right;
    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Tap.performed += OnTap;
    }

    private void OnDisable()
    {
        inputActions.Player.Tap.performed -= OnTap;
        inputActions.Disable();
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        moveDirection = moveDirection == Vector2.right ? Vector2.left : Vector2.right;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}

