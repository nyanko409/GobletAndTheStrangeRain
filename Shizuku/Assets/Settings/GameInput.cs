// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""72cbf2b9-8261-4447-a593-2b3213027949"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b0c52ebd-5f8f-421a-909a-4146486f55de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77728557-68af-4cfa-b176-cf997fe758f3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""55008414-9251-40d4-b42c-4785514391fa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop Droplet"",
                    ""type"": ""Button"",
                    ""id"": ""5d2d6012-24e0-42f9-83aa-0d6873255bff"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""c99c4592-725e-4f0d-9647-4d16328d6273"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e89db2dd-ab13-4d61-8924-47f50ecb28ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dc11f35b-c9b8-4965-b8e2-2b2b28c282ff"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f8d22436-7505-4307-b481-a901bb23d06a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0aeb9197-e9ba-4ae7-9eaa-708eb0b3b499"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f318d457-2592-40f8-bf55-b3239927d796"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""fe1e9cd8-fb9d-4908-89ff-2f69d1a4d1ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ed6b0a7b-8747-484c-92ab-4f88c4ffbe81"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6bc96628-cc4b-44cb-8254-43c671e959a0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""17e4d2b9-69cc-48a7-8939-117b73d43b12"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a750dd3c-8403-4c92-944f-d8d15c731394"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""63aaad73-b355-4c39-8a93-7861aa3f35d9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84d30b5f-89a5-440a-87b3-dddb3b4b4509"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce0aacb2-a0d0-4542-96f0-062cb54e9ab6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e9bf83a-e3a3-4ecf-8f07-3e1c422e5372"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Drop Droplet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a5f77e5-20fc-4a26-9658-3534282bf687"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Drop Droplet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Mouse Look"",
                    ""id"": ""6ef2de43-b029-4e68-bd76-625743d3cf48"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""23f631d3-8fac-429e-ac9d-a857051ac1e6"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Camera Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4d39401b-2531-4bf7-9711-486598218a77"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Camera Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d92ae977-3d2d-42d2-bece-2767f918c3c3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Camera Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f9e9cece-adff-4caa-bf90-02cf532de089"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Camera Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""00b09188-87ad-40dd-bf84-e6c3ab3549ac"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Camera Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1f49ea7-dd80-41c6-9797-b861aa3415da"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e9cf930-4b7d-4ef0-a7d4-ae0a78c35e3e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI Title"",
            ""id"": ""aaab999e-b277-425c-a71b-dc419f3e16df"",
            ""actions"": [
                {
                    ""name"": ""Press To Start"",
                    ""type"": ""Button"",
                    ""id"": ""d7041dfc-013e-4f26-aa8f-5cfc197ec104"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Up"",
                    ""type"": ""Button"",
                    ""id"": ""35fa15db-6b93-4d81-b3f1-b2a543fd75a7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Down"",
                    ""type"": ""Button"",
                    ""id"": ""b3a44066-57e4-4083-8313-72ddde4fd619"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""5c67921e-256b-426f-b5d4-a40db883c0e4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd55e90a-2f10-4573-af1b-650c209648d6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Press To Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""166cdfb3-f8bc-43c9-8a85-552ba3d439d1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Press To Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c24cb427-75de-4115-95df-a163064e3407"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf5863d1-3487-442a-bde4-2611385b9e4f"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2384d04e-c07c-47a9-ac62-431e5145bcbd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6426eda4-d583-4bfe-981c-90afa63a1642"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adb4a7ae-e0d8-4308-bf53-958043de70d5"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d519a655-1870-4674-a913-488af31db47d"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f4651d-5485-48b3-b7af-f266441946c5"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5964bcbe-b062-4471-84ee-b48882e8c3db"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI Stage Select"",
            ""id"": ""a69c44cf-1f2e-4aad-85aa-3a4c6d2b1cb3"",
            ""actions"": [
                {
                    ""name"": ""Stage Select Left"",
                    ""type"": ""Button"",
                    ""id"": ""b0ea38e2-3082-4910-9a5d-f7f72f6a8d98"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stage Select Right"",
                    ""type"": ""Button"",
                    ""id"": ""e328c5d8-59d8-4cd3-b492-8c2dd8344083"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm Stage"",
                    ""type"": ""Button"",
                    ""id"": ""657a9170-ecd5-4565-938c-ce32f1ea3fa3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return To Title"",
                    ""type"": ""Button"",
                    ""id"": ""165a3f44-9d53-457a-baff-2ab6c7070b35"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a5f901b-2613-41ca-8582-e2f045d80702"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Stage Select Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1151166-7361-498c-8b87-d28df833d70f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Stage Select Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b541126-f2cf-4199-8e0c-e763254e9692"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Stage Select Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa2eff1e-467d-4d10-9a8e-93b8220facf7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stage Select Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c71cddb-0687-4ecd-9d43-938e5d80300a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Stage Select Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88000379-3378-42b2-af0a-a7d6a1274ecf"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Stage Select Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6802269-2547-4691-80d5-83fe14c5039d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Stage Select Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d7cfabb-9e0b-46d0-b266-86df7a78c4a0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stage Select Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16f83738-e4d3-4759-a2f7-2205a597c4fc"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Confirm Stage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffedf1d2-0492-406f-9446-ce5c8438c69a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Confirm Stage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22df31cc-080a-4045-ac1d-c95ac2722cc8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Return To Title"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f03caf11-11dc-4dd8-aa9b-13239df17962"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Return To Title"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI Pause Menu"",
            ""id"": ""6d8b2b63-e0d0-4d40-b85f-9d72dce243af"",
            ""actions"": [
                {
                    ""name"": ""Toggle Pause Menu"",
                    ""type"": ""Button"",
                    ""id"": ""26d3fe27-f4e5-4910-9851-cc3df9abb7d2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Up"",
                    ""type"": ""Button"",
                    ""id"": ""299c9b06-abe9-4e01-8e16-68c837014e2c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Down"",
                    ""type"": ""Button"",
                    ""id"": ""72b21733-deda-4096-8d14-7879293f2f80"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""bfa5cc85-25b0-4ff1-9e5f-a69e887221a8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""leftstick"",
                    ""type"": ""Button"",
                    ""id"": ""c06ca4fd-7c75-4433-9f7a-56a5704622e0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rightstick"",
                    ""type"": ""Button"",
                    ""id"": ""3b120146-845c-4dae-a1ca-bbb518f6325f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""38d3b943-16de-45e7-bd8e-335ce49efdb2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f52442a-3a64-403b-966e-28677bb4112c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427f83ee-73e3-4bf9-bee6-c449c83225a6"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""752ee163-a947-44e1-8a25-650cf3ff890f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2ba8106-211c-4b30-a29b-3386d0ed8e16"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9673b66-4784-4fc8-b686-b9c783011f91"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a54d689-de00-40dc-ae10-4c4082930d48"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9df14ef3-4098-433f-96e4-4f7066c2e130"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61f2f5e1-cf84-441a-8f6f-c5825fe079bc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Toggle Pause Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8fcf72b-3929-48e7-810e-ca387117848f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Toggle Pause Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23b8fab8-b514-4521-ae2f-563945fe537d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftstick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e305df37-6474-47cb-9cf9-96755a7733f0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightstick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Tutorial Menu"",
            ""id"": ""6f5526b2-8ed5-43d3-b67c-a3f88358a2d3"",
            ""actions"": [
                {
                    ""name"": ""NextUI"",
                    ""type"": ""Button"",
                    ""id"": ""1a15a246-0aaa-412d-8c46-0ee60835d2ce"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackUI"",
                    ""type"": ""Button"",
                    ""id"": ""ba154d66-0c91-470b-94aa-23eb3d32f0bc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68babee7-d9e9-4840-8349-0ac58d46e691"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7467776a-61c8-4662-bdd0-653c6bc7cf2d"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0be2b06-33be-47c1-bc3c-52fee44cffc2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7d0c8cf-febf-426c-b975-cc01eb1b9611"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""NextUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c874382-5001-4af6-8d3e-c49b66ba1450"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""NextUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94fa863c-b88d-484e-bf98-1f59b22411a8"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BackUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dae80ca-14ee-4c74-86b7-61af6c684885"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BackUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea610011-c1f0-47eb-86dc-b972c7ca03cb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BackUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""905edb73-3c37-4c7f-b2f4-2d21eb5e2cdd"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BackUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b76812e-ee34-4cac-a5eb-67ea2f3bb1d7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""BackUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_CameraLook = m_Player.FindAction("Camera Look", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_DropDroplet = m_Player.FindAction("Drop Droplet", throwIfNotFound: true);
        m_Player_Drag = m_Player.FindAction("Drag", throwIfNotFound: true);
        // UI Title
        m_UITitle = asset.FindActionMap("UI Title", throwIfNotFound: true);
        m_UITitle_PressToStart = m_UITitle.FindAction("Press To Start", throwIfNotFound: true);
        m_UITitle_NavigateUp = m_UITitle.FindAction("Navigate Up", throwIfNotFound: true);
        m_UITitle_NavigateDown = m_UITitle.FindAction("Navigate Down", throwIfNotFound: true);
        m_UITitle_Confirm = m_UITitle.FindAction("Confirm", throwIfNotFound: true);
        // UI Stage Select
        m_UIStageSelect = asset.FindActionMap("UI Stage Select", throwIfNotFound: true);
        m_UIStageSelect_StageSelectLeft = m_UIStageSelect.FindAction("Stage Select Left", throwIfNotFound: true);
        m_UIStageSelect_StageSelectRight = m_UIStageSelect.FindAction("Stage Select Right", throwIfNotFound: true);
        m_UIStageSelect_ConfirmStage = m_UIStageSelect.FindAction("Confirm Stage", throwIfNotFound: true);
        m_UIStageSelect_ReturnToTitle = m_UIStageSelect.FindAction("Return To Title", throwIfNotFound: true);
        // UI Pause Menu
        m_UIPauseMenu = asset.FindActionMap("UI Pause Menu", throwIfNotFound: true);
        m_UIPauseMenu_TogglePauseMenu = m_UIPauseMenu.FindAction("Toggle Pause Menu", throwIfNotFound: true);
        m_UIPauseMenu_NavigateUp = m_UIPauseMenu.FindAction("Navigate Up", throwIfNotFound: true);
        m_UIPauseMenu_NavigateDown = m_UIPauseMenu.FindAction("Navigate Down", throwIfNotFound: true);
        m_UIPauseMenu_Confirm = m_UIPauseMenu.FindAction("Confirm", throwIfNotFound: true);
        m_UIPauseMenu_leftstick = m_UIPauseMenu.FindAction("leftstick", throwIfNotFound: true);
        m_UIPauseMenu_rightstick = m_UIPauseMenu.FindAction("rightstick", throwIfNotFound: true);
        // Tutorial Menu
        m_TutorialMenu = asset.FindActionMap("Tutorial Menu", throwIfNotFound: true);
        m_TutorialMenu_NextUI = m_TutorialMenu.FindAction("NextUI", throwIfNotFound: true);
        m_TutorialMenu_BackUI = m_TutorialMenu.FindAction("BackUI", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_CameraLook;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_DropDroplet;
    private readonly InputAction m_Player_Drag;
    public struct PlayerActions
    {
        private @GameInput m_Wrapper;
        public PlayerActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @CameraLook => m_Wrapper.m_Player_CameraLook;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @DropDroplet => m_Wrapper.m_Player_DropDroplet;
        public InputAction @Drag => m_Wrapper.m_Player_Drag;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @CameraLook.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLook;
                @CameraLook.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLook;
                @CameraLook.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLook;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @DropDroplet.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropDroplet;
                @DropDroplet.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropDroplet;
                @DropDroplet.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropDroplet;
                @Drag.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraLook.started += instance.OnCameraLook;
                @CameraLook.performed += instance.OnCameraLook;
                @CameraLook.canceled += instance.OnCameraLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @DropDroplet.started += instance.OnDropDroplet;
                @DropDroplet.performed += instance.OnDropDroplet;
                @DropDroplet.canceled += instance.OnDropDroplet;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI Title
    private readonly InputActionMap m_UITitle;
    private IUITitleActions m_UITitleActionsCallbackInterface;
    private readonly InputAction m_UITitle_PressToStart;
    private readonly InputAction m_UITitle_NavigateUp;
    private readonly InputAction m_UITitle_NavigateDown;
    private readonly InputAction m_UITitle_Confirm;
    public struct UITitleActions
    {
        private @GameInput m_Wrapper;
        public UITitleActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressToStart => m_Wrapper.m_UITitle_PressToStart;
        public InputAction @NavigateUp => m_Wrapper.m_UITitle_NavigateUp;
        public InputAction @NavigateDown => m_Wrapper.m_UITitle_NavigateDown;
        public InputAction @Confirm => m_Wrapper.m_UITitle_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_UITitle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UITitleActions set) { return set.Get(); }
        public void SetCallbacks(IUITitleActions instance)
        {
            if (m_Wrapper.m_UITitleActionsCallbackInterface != null)
            {
                @PressToStart.started -= m_Wrapper.m_UITitleActionsCallbackInterface.OnPressToStart;
                @PressToStart.performed -= m_Wrapper.m_UITitleActionsCallbackInterface.OnPressToStart;
                @PressToStart.canceled -= m_Wrapper.m_UITitleActionsCallbackInterface.OnPressToStart;
                @NavigateUp.started -= m_Wrapper.m_UITitleActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.performed -= m_Wrapper.m_UITitleActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.canceled -= m_Wrapper.m_UITitleActionsCallbackInterface.OnNavigateUp;
                @NavigateDown.started -= m_Wrapper.m_UITitleActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.performed -= m_Wrapper.m_UITitleActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.canceled -= m_Wrapper.m_UITitleActionsCallbackInterface.OnNavigateDown;
                @Confirm.started -= m_Wrapper.m_UITitleActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_UITitleActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_UITitleActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_UITitleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressToStart.started += instance.OnPressToStart;
                @PressToStart.performed += instance.OnPressToStart;
                @PressToStart.canceled += instance.OnPressToStart;
                @NavigateUp.started += instance.OnNavigateUp;
                @NavigateUp.performed += instance.OnNavigateUp;
                @NavigateUp.canceled += instance.OnNavigateUp;
                @NavigateDown.started += instance.OnNavigateDown;
                @NavigateDown.performed += instance.OnNavigateDown;
                @NavigateDown.canceled += instance.OnNavigateDown;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public UITitleActions @UITitle => new UITitleActions(this);

    // UI Stage Select
    private readonly InputActionMap m_UIStageSelect;
    private IUIStageSelectActions m_UIStageSelectActionsCallbackInterface;
    private readonly InputAction m_UIStageSelect_StageSelectLeft;
    private readonly InputAction m_UIStageSelect_StageSelectRight;
    private readonly InputAction m_UIStageSelect_ConfirmStage;
    private readonly InputAction m_UIStageSelect_ReturnToTitle;
    public struct UIStageSelectActions
    {
        private @GameInput m_Wrapper;
        public UIStageSelectActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @StageSelectLeft => m_Wrapper.m_UIStageSelect_StageSelectLeft;
        public InputAction @StageSelectRight => m_Wrapper.m_UIStageSelect_StageSelectRight;
        public InputAction @ConfirmStage => m_Wrapper.m_UIStageSelect_ConfirmStage;
        public InputAction @ReturnToTitle => m_Wrapper.m_UIStageSelect_ReturnToTitle;
        public InputActionMap Get() { return m_Wrapper.m_UIStageSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIStageSelectActions set) { return set.Get(); }
        public void SetCallbacks(IUIStageSelectActions instance)
        {
            if (m_Wrapper.m_UIStageSelectActionsCallbackInterface != null)
            {
                @StageSelectLeft.started -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnStageSelectLeft;
                @StageSelectLeft.performed -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnStageSelectLeft;
                @StageSelectLeft.canceled -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnStageSelectLeft;
                @StageSelectRight.started -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnStageSelectRight;
                @StageSelectRight.performed -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnStageSelectRight;
                @StageSelectRight.canceled -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnStageSelectRight;
                @ConfirmStage.started -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnConfirmStage;
                @ConfirmStage.performed -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnConfirmStage;
                @ConfirmStage.canceled -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnConfirmStage;
                @ReturnToTitle.started -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnReturnToTitle;
                @ReturnToTitle.performed -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnReturnToTitle;
                @ReturnToTitle.canceled -= m_Wrapper.m_UIStageSelectActionsCallbackInterface.OnReturnToTitle;
            }
            m_Wrapper.m_UIStageSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StageSelectLeft.started += instance.OnStageSelectLeft;
                @StageSelectLeft.performed += instance.OnStageSelectLeft;
                @StageSelectLeft.canceled += instance.OnStageSelectLeft;
                @StageSelectRight.started += instance.OnStageSelectRight;
                @StageSelectRight.performed += instance.OnStageSelectRight;
                @StageSelectRight.canceled += instance.OnStageSelectRight;
                @ConfirmStage.started += instance.OnConfirmStage;
                @ConfirmStage.performed += instance.OnConfirmStage;
                @ConfirmStage.canceled += instance.OnConfirmStage;
                @ReturnToTitle.started += instance.OnReturnToTitle;
                @ReturnToTitle.performed += instance.OnReturnToTitle;
                @ReturnToTitle.canceled += instance.OnReturnToTitle;
            }
        }
    }
    public UIStageSelectActions @UIStageSelect => new UIStageSelectActions(this);

    // UI Pause Menu
    private readonly InputActionMap m_UIPauseMenu;
    private IUIPauseMenuActions m_UIPauseMenuActionsCallbackInterface;
    private readonly InputAction m_UIPauseMenu_TogglePauseMenu;
    private readonly InputAction m_UIPauseMenu_NavigateUp;
    private readonly InputAction m_UIPauseMenu_NavigateDown;
    private readonly InputAction m_UIPauseMenu_Confirm;
    private readonly InputAction m_UIPauseMenu_leftstick;
    private readonly InputAction m_UIPauseMenu_rightstick;
    public struct UIPauseMenuActions
    {
        private @GameInput m_Wrapper;
        public UIPauseMenuActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TogglePauseMenu => m_Wrapper.m_UIPauseMenu_TogglePauseMenu;
        public InputAction @NavigateUp => m_Wrapper.m_UIPauseMenu_NavigateUp;
        public InputAction @NavigateDown => m_Wrapper.m_UIPauseMenu_NavigateDown;
        public InputAction @Confirm => m_Wrapper.m_UIPauseMenu_Confirm;
        public InputAction @leftstick => m_Wrapper.m_UIPauseMenu_leftstick;
        public InputAction @rightstick => m_Wrapper.m_UIPauseMenu_rightstick;
        public InputActionMap Get() { return m_Wrapper.m_UIPauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIPauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IUIPauseMenuActions instance)
        {
            if (m_Wrapper.m_UIPauseMenuActionsCallbackInterface != null)
            {
                @TogglePauseMenu.started -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnTogglePauseMenu;
                @TogglePauseMenu.performed -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnTogglePauseMenu;
                @TogglePauseMenu.canceled -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnTogglePauseMenu;
                @NavigateUp.started -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.performed -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.canceled -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnNavigateUp;
                @NavigateDown.started -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.performed -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.canceled -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnNavigateDown;
                @Confirm.started -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnConfirm;
                @leftstick.started -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnLeftstick;
                @leftstick.performed -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnLeftstick;
                @leftstick.canceled -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnLeftstick;
                @rightstick.started -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnRightstick;
                @rightstick.performed -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnRightstick;
                @rightstick.canceled -= m_Wrapper.m_UIPauseMenuActionsCallbackInterface.OnRightstick;
            }
            m_Wrapper.m_UIPauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TogglePauseMenu.started += instance.OnTogglePauseMenu;
                @TogglePauseMenu.performed += instance.OnTogglePauseMenu;
                @TogglePauseMenu.canceled += instance.OnTogglePauseMenu;
                @NavigateUp.started += instance.OnNavigateUp;
                @NavigateUp.performed += instance.OnNavigateUp;
                @NavigateUp.canceled += instance.OnNavigateUp;
                @NavigateDown.started += instance.OnNavigateDown;
                @NavigateDown.performed += instance.OnNavigateDown;
                @NavigateDown.canceled += instance.OnNavigateDown;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @leftstick.started += instance.OnLeftstick;
                @leftstick.performed += instance.OnLeftstick;
                @leftstick.canceled += instance.OnLeftstick;
                @rightstick.started += instance.OnRightstick;
                @rightstick.performed += instance.OnRightstick;
                @rightstick.canceled += instance.OnRightstick;
            }
        }
    }
    public UIPauseMenuActions @UIPauseMenu => new UIPauseMenuActions(this);

    // Tutorial Menu
    private readonly InputActionMap m_TutorialMenu;
    private ITutorialMenuActions m_TutorialMenuActionsCallbackInterface;
    private readonly InputAction m_TutorialMenu_NextUI;
    private readonly InputAction m_TutorialMenu_BackUI;
    public struct TutorialMenuActions
    {
        private @GameInput m_Wrapper;
        public TutorialMenuActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextUI => m_Wrapper.m_TutorialMenu_NextUI;
        public InputAction @BackUI => m_Wrapper.m_TutorialMenu_BackUI;
        public InputActionMap Get() { return m_Wrapper.m_TutorialMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TutorialMenuActions set) { return set.Get(); }
        public void SetCallbacks(ITutorialMenuActions instance)
        {
            if (m_Wrapper.m_TutorialMenuActionsCallbackInterface != null)
            {
                @NextUI.started -= m_Wrapper.m_TutorialMenuActionsCallbackInterface.OnNextUI;
                @NextUI.performed -= m_Wrapper.m_TutorialMenuActionsCallbackInterface.OnNextUI;
                @NextUI.canceled -= m_Wrapper.m_TutorialMenuActionsCallbackInterface.OnNextUI;
                @BackUI.started -= m_Wrapper.m_TutorialMenuActionsCallbackInterface.OnBackUI;
                @BackUI.performed -= m_Wrapper.m_TutorialMenuActionsCallbackInterface.OnBackUI;
                @BackUI.canceled -= m_Wrapper.m_TutorialMenuActionsCallbackInterface.OnBackUI;
            }
            m_Wrapper.m_TutorialMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextUI.started += instance.OnNextUI;
                @NextUI.performed += instance.OnNextUI;
                @NextUI.canceled += instance.OnNextUI;
                @BackUI.started += instance.OnBackUI;
                @BackUI.performed += instance.OnBackUI;
                @BackUI.canceled += instance.OnBackUI;
            }
        }
    }
    public TutorialMenuActions @TutorialMenu => new TutorialMenuActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCameraLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDropDroplet(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
    public interface IUITitleActions
    {
        void OnPressToStart(InputAction.CallbackContext context);
        void OnNavigateUp(InputAction.CallbackContext context);
        void OnNavigateDown(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
    public interface IUIStageSelectActions
    {
        void OnStageSelectLeft(InputAction.CallbackContext context);
        void OnStageSelectRight(InputAction.CallbackContext context);
        void OnConfirmStage(InputAction.CallbackContext context);
        void OnReturnToTitle(InputAction.CallbackContext context);
    }
    public interface IUIPauseMenuActions
    {
        void OnTogglePauseMenu(InputAction.CallbackContext context);
        void OnNavigateUp(InputAction.CallbackContext context);
        void OnNavigateDown(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnLeftstick(InputAction.CallbackContext context);
        void OnRightstick(InputAction.CallbackContext context);
    }
    public interface ITutorialMenuActions
    {
        void OnNextUI(InputAction.CallbackContext context);
        void OnBackUI(InputAction.CallbackContext context);
    }
}
