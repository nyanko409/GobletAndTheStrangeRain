using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform pivot;
    public float speed = 500;
    public Vector3 offset;

    GameInput action;
    Vector2 cameraLookInput;


    private void Awake()
    {
        // init actions
        action = new GameInput();

        action.Player.CameraLook.performed += context => cameraLookInput = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        transform.position = pivot.position + offset;
    }

    private void LateUpdate()
    {
        pivot.transform.eulerAngles += new Vector3(0, cameraLookInput.x, 0) * speed * Time.deltaTime;
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
