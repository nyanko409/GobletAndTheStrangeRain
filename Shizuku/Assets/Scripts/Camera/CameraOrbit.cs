using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform pivot;
    public float horizontalSpeed = 400;
    public float verticalSpeed = 100;
    public int clampMaxRot = 30;
    public int clampMinRot = -30;
    public float distance = 25;
    public bool collideWithStage = true;

    GameInput action;
    Vector2 cameraLookInput;
    Vector3 eulerAngles;


    private void Awake()
    {
        // init actions
        action = new GameInput();

        action.Player.CameraLook.performed += context => cameraLookInput = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        transform.position = pivot.position + (-transform.forward * distance);
        eulerAngles = pivot.transform.eulerAngles;
    }

    private void LateUpdate()
    {
        // calculate new angle based on input
        eulerAngles += new Vector3(cameraLookInput.y * verticalSpeed, cameraLookInput.x * horizontalSpeed, 0) * Time.deltaTime;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, clampMinRot, clampMaxRot);

        // rotate the pivot
        pivot.transform.eulerAngles = eulerAngles;

        // prevent camera from clipping into objects
        var newDist = distance;
        if (collideWithStage &&
            Physics.Raycast(pivot.position, transform.position - pivot.position, out RaycastHit hit, 1000, LayerMask.GetMask("Room")))
        {
            if (hit.distance < distance)
                newDist = hit.distance - 1;
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
