using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform pivot;
    public float horizontalSpeed = 400;
    public float verticalSpeed = 100;
    public int clampMaxRot = 30;
    public int clampMinRot = -30;
    public float distance = 25;
    public float dragRotation = 5;
    public bool collideWithStage = true;
    public bool activateInput = false;

    GameInput action;
    Vector2 cameraLookInput;
    Vector3 eulerAngles;
    GameObject player;
    PlayerController playerCtrl;


    private void Awake()
    {
        // init actions
        action = new GameInput();

        action.Player.CameraLook.performed += context =>
        {
            if (!activateInput) return;
            cameraLookInput = context.ReadValue<Vector2>();
        };
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCtrl = player.GetComponent<PlayerController>();

        transform.position = pivot.position + (-transform.forward * distance);
        eulerAngles = pivot.transform.eulerAngles;
    }

    private void FixedUpdate()
    {
        // if player is dragging, fixate the camera
        if(playerCtrl.IsDragging())
        {
            Quaternion targetRot = player.transform.rotation;
            targetRot.eulerAngles += new Vector3(dragRotation, 0, 0);

            pivot.rotation = Quaternion.Lerp(pivot.rotation, targetRot, 0.1F);
            eulerAngles = pivot.transform.eulerAngles;

            ClipInsideStage();

            return;
        }

        // calculate new angle based on input
        eulerAngles += new Vector3(cameraLookInput.y * verticalSpeed, cameraLookInput.x * horizontalSpeed, 0) * Time.deltaTime;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, clampMinRot, clampMaxRot);

        // rotate the pivot
        pivot.transform.eulerAngles = eulerAngles;

        ClipInsideStage();
    }

    private void ClipInsideStage()
    {
        // prevent camera from clipping into objects
        var newDist = distance;

        if (collideWithStage &&
            Physics.Raycast(pivot.position, transform.position - pivot.position, out RaycastHit hit, 1000, LayerMask.GetMask("Room")))
        {
            if (hit.distance < distance)
                newDist = hit.distance - 1;
        }

        Vector3 lerpPos = pivot.position + (-transform.forward * newDist);
        transform.position = Vector3.Lerp(transform.position, lerpPos, 0.1F);
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
