using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    Animator anim;
    GameInput action;


    private void Awake()
    {
        action = new GameInput();

        action.UIStageSelect.StageSelectLeft.performed += context =>
        {
            if (anim.GetCurrentAnimatorStateInfo(
                anim.GetLayerIndex("Left Arrow")).IsName("ArrowLeft_Animation"))
                return;

            anim.SetTrigger("LeftTrigger");
        };

        action.UIStageSelect.StageSelectRight.performed += context =>
        {
            if (anim.GetCurrentAnimatorStateInfo(
                anim.GetLayerIndex("Right Arrow")).IsName("ArrowRight_Animation"))
                return;

            anim.SetTrigger("RightTrigger");
        };
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
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
