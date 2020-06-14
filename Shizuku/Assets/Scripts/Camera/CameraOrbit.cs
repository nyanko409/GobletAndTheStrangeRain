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

    Camera cam;
    GameInput action;
    Vector2 cameraLookInput;
    Vector3 eulerAngles;
    GameObject player;
    PlayerController playerCtrl;
    Vector3 halfExtends;


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
        cam = GetComponent<Camera>();

        transform.position = pivot.position + (-transform.forward * distance);
        eulerAngles = pivot.transform.eulerAngles;

        // calculate cameras half extends
        halfExtends = new Vector3();
        halfExtends.y =
            cam.nearClipPlane *
            Mathf.Tan(0.5f * Mathf.Deg2Rad * cam.fieldOfView);
        halfExtends.x = halfExtends.y * cam.aspect;
        halfExtends.z = 0f;
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

        // clip inside the stage
        ClipInsideStage();

        // reset the z angle so it does not look tilted (happens when drag is canceled)
        if(pivot.eulerAngles.z != 0)
        {
            pivot.rotation = Quaternion.Euler(pivot.eulerAngles.x, pivot.eulerAngles.y, 0);
        }
    }

    private void ClipInsideStage()
    {
        // prevent camera from clipping into objects
        var newDist = distance;

        if (collideWithStage &&
            Physics.BoxCast(pivot.position, halfExtends, transform.position - pivot.position, out RaycastHit hit, transform.rotation, 1000, LayerMask.GetMask("Room")))
        {
            if (hit.distance < distance)
                newDist = hit.distance + cam.nearClipPlane - 1;
        }

        transform.position = pivot.position + (-transform.forward * newDist);
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
