using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;                 // movespeed of the player
    public float dragSpeedMultiplier = 0.5F;    // the speed multiplier while dragging
    public float rotationSpeed = 10;            // rotation speed of the player
    public float jumpHeight = 5;                // jump height the player
    public float slopeLimit = 10;               // max degree of slope to climb
    public float floorOffsetY = 1;              // offset to the floor

    GameInput action;
    Vector2 movementInput;
    Vector3 moveDirection;
    new Rigidbody rigidbody;
    float jumpFalloff = 2;
    Vector3 gravity;
    Vector3 floorNormal;
    Rigidbody dragRigidbody;                    // the rigidbody of the dragging object
    bool isDragging;                            // true if dragging
    Vector3 dragStartDiff;

   
    private void Awake()
    {
        // init listeners
        action = new GameInput();
        action.Player.Move.performed += context => { movementInput = context.ReadValue<Vector2>(); };
        action.Player.Drag.started += context => isDragging = true;
        action.Player.Drag.canceled += context => isDragging = false;
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

        // get direction from input
        // if not dragging, move based on camera direction
        Vector3 vertical, horizontal;
        if (!dragRigidbody)
        {
            vertical = movementInput.y * Camera.main.transform.forward;
            horizontal = movementInput.x * Camera.main.transform.right;
        }
        // if dragging, move based on player direction
        else
        {
            vertical = movementInput.y * transform.forward;
            horizontal = movementInput.x * transform.right;
        }

        // normalize direction
        moveDirection = vertical + horizontal;
        moveDirection.y = 0;
        moveDirection.Normalize();

        // rotate to moving direction
        if (!dragRigidbody && moveDirection != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(moveDirection);
            Quaternion targetRot = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
            transform.rotation = targetRot;
        }
    }

    private void FixedUpdate()
    {
        if (!IsGrounded())
        {
            gravity += Vector3.up * Physics.gravity.y * jumpFalloff * Time.fixedDeltaTime;
        }

        // update the velocity
        rigidbody.velocity = moveDirection * GetMoveSpeed();
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

    private void LateUpdate()
    {
        DragObject();
    }

    // returns the movespeed of the player
    private float GetMoveSpeed()
    {
        return dragRigidbody ? moveSpeed * dragSpeedMultiplier : moveSpeed;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(!dragRigidbody && IsGrounded())
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

    private void DragObject()
    {
        if (isDragging && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1.5F))
        {
            if (hit.transform.TryGetComponent(out Tag tag) && tag.HasTag(TagType.Moveable))
            {
                if(!dragRigidbody)
                {
                    // look at object
                    transform.rotation = Quaternion.LookRotation(-hit.normal);

                    // cache rigidbody of target and start position difference
                    dragRigidbody = hit.transform.GetComponent<Rigidbody>();
                    dragStartDiff = transform.position - dragRigidbody.transform.position;
                }

                // move the target back to start drag position when player is moving too fast
                var diff = transform.position - dragRigidbody.transform.position;
                if (diff != dragStartDiff)
                {
                    transform.position += dragStartDiff - diff;
                }

                // move the target with player
                dragRigidbody.velocity = moveDirection * GetMoveSpeed();
            }
        }
        else if (dragRigidbody)
        {
            dragRigidbody.velocity = Vector3.zero;
            dragRigidbody = null;
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
