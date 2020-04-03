using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;
    public float rotationSpeed = 10;
    public float jumpHeight = 5;
    public float jumpFalloff = 2;
    public float slopeLimit = 10;
    public float floorOffsetY = 1;

    GameInput action;
    Vector2 movementInput;
    Vector3 moveDirection;
    new Rigidbody rigidbody;
    Vector3 gravity;
    Vector3 floorNormal;

   
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
    }

    private void Update()
    {
        // reset movement
        moveDirection = Vector3.zero;

        Vector3 vertical = movementInput.y * Camera.main.transform.forward;
        Vector3 horizontal = movementInput.x * Camera.main.transform.right;

        moveDirection = vertical + horizontal;
        moveDirection.y = 0;
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(moveDirection);
            Quaternion targetRot = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
            transform.rotation = targetRot;
        }
    }

    private void FixedUpdate()
    {
        if(!IsGrounded())
        {
            gravity += Vector3.up * Physics.gravity.y * jumpFalloff * Time.fixedDeltaTime;
        }

        // update the velocity
        rigidbody.velocity = moveDirection * moveSpeed;
        rigidbody.velocity += gravity;

        // find the y position
        Vector3 floorPos = new Vector3(rigidbody.position.x, FindFloor().y, rigidbody.position.z);

        // stick to floor when grounded
        if (floorPos != rigidbody.position && IsGrounded() && rigidbody.velocity.y <= 0)
        {
            rigidbody.MovePosition(floorPos);
            gravity.y = 0;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded())
        {
            gravity.y = jumpHeight;
        }
    }

    private Vector3 FindFloor()
    {
        float raycastWidth = 0.5F;
        int average = 1;

        Vector3 combinedRaycast = FloorRaycast(0, 0, floorOffsetY + 1);

        Vector3 temp = FloorRaycast(raycastWidth, 0, floorOffsetY + 1);
        if (temp != Vector3.zero)
        {
            combinedRaycast += temp;
            average++;
        }
        temp = FloorRaycast(-raycastWidth, 0, floorOffsetY + 1);
        if (temp != Vector3.zero)
        {
            combinedRaycast += temp;
            average++;
        }
        temp = FloorRaycast(0, raycastWidth, floorOffsetY + 1);
        if (temp != Vector3.zero)
        {
            combinedRaycast += temp;
            average++;
        }
        temp = FloorRaycast(0, -raycastWidth, floorOffsetY + 1);
        if (temp != Vector3.zero)
        {
            combinedRaycast += temp;
            average++;
        }

        return combinedRaycast / average;
    }

    private bool IsGrounded()
    {
        if(FloorRaycast(0, 0, floorOffsetY + 1) != Vector3.zero)
        {
            return true;
        }

        return false;
    }

    private Vector3 FloorRaycast(float offsetX, float offsetZ, float raycastDistance)
    {
        Vector3 rayOrigin = transform.TransformPoint(offsetX, 0.5F, offsetZ);
        Debug.DrawRay(rayOrigin, Vector3.down * (floorOffsetY + 1), Color.blue);

        if(Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, raycastDistance))
        {
            floorNormal = hit.normal;

            if (Vector3.Angle(hit.normal, Vector3.up) <= slopeLimit)
            {
                return hit.point + new Vector3(0, floorOffsetY, 0);
            }
        }

        return Vector3.zero;
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
