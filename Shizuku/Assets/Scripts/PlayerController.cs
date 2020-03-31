using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;
    public float maxSpeed = 10;
    public float jumpHeight = 5;

    GameInput action;
    Vector2 movementInput;
    new Rigidbody rigidbody;
    bool isJumping;


    private void Awake()
    {
        // init listeners
        action = new GameInput();
        action.Player.Move.performed += context => { movementInput = context.ReadValue<Vector2>(); };
        action.Player.Jump.performed += Jump;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        isJumping = false;
    }

    private void FixedUpdate()
    {
        // move player
        rigidbody.AddForce(new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);

        // face player forward
        if(movementInput.x != 0 && movementInput.y != 0)
            transform.forward = new Vector3(movementInput.x, 0, movementInput.y).normalized;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isJumping) return;

        rigidbody.velocity += new Vector3(0, jumpHeight, 0);
        isJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.contacts[0].thisCollider;
        if(col.name.Equals("Foot"))
        {
            isJumping = false;
        }
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
