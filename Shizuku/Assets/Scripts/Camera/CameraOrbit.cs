using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform pivot;
    public float horizontalSpeed = 400;
    public float verticalSpeed = 100;
    public int clampMaxRot = 30;
    public int clampMinRot = -30;
    public Vector3 offset;

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
        transform.position = pivot.position + offset;
        eulerAngles = pivot.transform.eulerAngles;
    }

    private void LateUpdate()
    {
        eulerAngles += new Vector3(cameraLookInput.y * verticalSpeed, cameraLookInput.x * horizontalSpeed, 0) * Time.deltaTime;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, clampMinRot, clampMaxRot);
        pivot.transform.eulerAngles = eulerAngles;
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
