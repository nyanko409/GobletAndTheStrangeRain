using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;                 // movespeed of the player
    public float dragSpeedMultiplier = 0.5F;    // the speed multiplier while dragging
    public float dragDistance = 1.5F;
    public float rotationSpeed = 10;             // rotation speed of the player
    public float jumpHeight = 5;                // jump height the player
    public float fallMultiplier = 2.5F;         // fall speed multiplier
    public float lowJumpMultiplier = 3;         // fall multiplier if jump button is released midair
    public float slopeLimit = 10;               // max degree of slope to climb
    public float floorOffsetY = 1;              // offset to the floor

    private GameInput action;
    private Animator anim;
    private Vector2 movementInput;
    private Vector3 moveDirection;
    private new Rigidbody rigidbody;
    private float jumpFalloff = 2.5F;
    private bool jumpPressed;
    private Vector3 gravity;
    private Rigidbody dragRigidbody = null;     // the rigidbody of the dragging object
    private bool inDragRange;
    private bool isDragging;                    // is true when drag keybind is pressed
    private bool isColliding;
    private Vector3 dragStartDiff;

    private AudioSource audioRun;


    public bool IsInDragRange()
    {
        return inDragRange;
    }

    public bool IsDragging()
    {
        return dragRigidbody;
    }

   
    private void Awake()
    {
        // init listeners
        action = new GameInput();
        action.Player.Move.performed += context => { movementInput = context.ReadValue<Vector2>(); };

        action.Player.Drag.started += context => isDragging = true;
        action.Player.Drag.canceled += context => isDragging = false;

        action.Player.Jump.started += context => { jumpPressed = true;  Jump(); };
        action.Player.Jump.canceled += context => { jumpPressed = false; };
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        AudioManager manager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioRun = manager.GetAudioSourceByType(AudioManager.AudioType.SE_PlayerRun);

        isDragging = false;
    }

    private void Update()
    {
        // return if pausing
        if (Time.timeScale == 0)
            return;

        // reset movement
        moveDirection = Vector3.zero;

        // idle and walking animation
        anim.SetBool("isWalking", movementInput == Vector2.zero ? false : true);

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

        // play running sound effect
        if (moveDirection != Vector3.zero && !audioRun.isPlaying && !dragRigidbody && IsGrounded())
            audioRun.Play();
        else if (moveDirection == Vector3.zero || (audioRun.isPlaying && !IsGrounded()))
            audioRun.Pause();

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

            if(gravity.y < 0)
            {
                // fall faster to the ground
                gravity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
            }
            else if(gravity.y > 0 && !jumpPressed)
            {
                // fall faster if jump button is released midair
                gravity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
            }
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

    private void Jump()
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
        return FloorRaycast(0, 0, floorOffsetY + 1) != Vector3.zero;
    }

    private Vector3 FloorRaycast(float offsetX, float offsetZ, float raycastDistance)
    {
        Vector3 rayOrigin = transform.TransformPoint(offsetX, 0.5F, offsetZ);

        if(Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, raycastDistance, LayerMask.GetMask("Room", "Obstacle", "Ignore Ripple")))
        {
            if (Vector3.Angle(hit.normal, Vector3.up) <= slopeLimit)
            {
                return hit.point + new Vector3(0, floorOffsetY, 0);
            }
        }

        return Vector3.zero;
    }

    private void DragObject()
    {
        if (IsGrounded() && !isColliding &&
           Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.forward, out RaycastHit hit, dragDistance, LayerMask.GetMask("Obstacle", "Ignore Ripple")) &&
           hit.normal.y <= 0.01F && hit.transform.TryGetComponent(out Tag tag) && tag.HasTag(TagType.Moveable))
        {
            inDragRange = true;

            if (isDragging)
            {
                if (!dragRigidbody)
                {
                    // look at object
                    transform.rotation = Quaternion.LookRotation(-hit.normal);

                    // cache rigidbody of target and start position difference
                    dragRigidbody = hit.transform.GetComponent<Rigidbody>();
                    dragStartDiff = transform.position - dragRigidbody.transform.position;

                    // set the rigidbody constraints
                    dragRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                }

                // move the target back to start drag position when player is moving too fast
                var diff = transform.position - dragRigidbody.transform.position;
                if (diff != dragStartDiff)
                {
                    transform.position += dragStartDiff - diff;
                }

                // move the target with player
                dragRigidbody.velocity = moveDirection * GetMoveSpeed();

                // switch to push animation
                anim.SetBool("isPushing", true);
            }
            else if (dragRigidbody)
            {
                ResetDragRigidbody();
            }
        }
        else if (dragRigidbody)
        {
            ResetDragRigidbody();
        }
        else
        {
            inDragRange = false;
        }
    }

    private void ResetDragRigidbody()
    {
        // reset the rigidbody
        dragRigidbody.velocity = Vector3.zero;
        dragRigidbody.constraints = RigidbodyConstraints.None;
        if (dragRigidbody.GetComponent<Tag>().HasTag(TagType.FreezeRotation))
            dragRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        dragRigidbody = null;

        anim.SetBool("isPushing", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isDragging ||
            dragRigidbody && collision.transform.TryGetComponent(out Rigidbody rb) && rb == dragRigidbody)
            return;

        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
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
