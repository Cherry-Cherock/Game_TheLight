//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Player/PlayerController/PlayerControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControl"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""479a0618-8e6e-49fc-8515-f0899219dd53"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""689edd46-1a03-4fdd-b28c-0bf121633a6f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7268d495-6983-4ebf-a6d0-3f5d0d60daef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""9c797111-fcee-484f-aee3-eb058c23d385"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FindPath"",
                    ""type"": ""Button"",
                    ""id"": ""1f8da190-d89f-42f4-bba0-e05ec94415bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InventoryRight"",
                    ""type"": ""Button"",
                    ""id"": ""0d205199-02d0-4a17-b917-3b8de1d56310"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InventoryLeft"",
                    ""type"": ""Button"",
                    ""id"": ""0a052d57-500e-49b8-94fe-93a286b310ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""dropItem"",
                    ""type"": ""Button"",
                    ""id"": ""950a1f99-02d6-4951-9dd7-8fba9af0d3bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4887f630-b5b1-445c-8fa8-5ba144843c9f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f5bb4a4-58c4-44e6-b701-831846ad5a06"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2ef72dd3-d695-41a3-b8ff-f7383fa3392e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e0483e51-68e4-46f3-a933-4a338d5609a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9f1eeb90-c98b-4d4f-b962-d0b3a620eeb0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""40f48b49-c0ab-479d-89c8-d919409e1bed"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7ad8689b-527d-44f5-8794-e5e0d6185f79"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""60c1017c-29c5-4c8f-8ebf-1e504b417436"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FindPath"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc3e22f3-8038-4370-93ba-1cceb56eeb3a"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8195d6e-32c6-4017-b8fa-4d1510cdf962"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fba4508-12da-4a0d-bce1-f828a44290d3"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""dropItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""9a30905d-93d3-4c41-b918-fc2cea629a39"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""fec1d882-2664-44d0-8a15-7eb0ef563fb9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f34b2833-9d38-430f-9279-1eedfd70e5df"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""a7f3bb66-984d-4989-9236-a44aaecd09bc"",
            ""actions"": [
                {
                    ""name"": ""PausedGame"",
                    ""type"": ""Button"",
                    ""id"": ""76fc4b63-164a-4451-b475-eaaf1376f958"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""d4dd6305-72cc-4807-a0bd-168c7c32f4dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MapSetTarget"",
                    ""type"": ""Button"",
                    ""id"": ""114b6d29-0aed-4027-9bfe-a0287106d63a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""265bfa74-c1f9-4290-a2ff-d9289c3ded50"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PausedGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23c9f7a7-26b7-4afb-a46c-9e9d182d25d1"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8370f51-c15f-4ce7-9694-134f783d2d8d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MapSetTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_FindPath = m_Player.FindAction("FindPath", throwIfNotFound: true);
        m_Player_InventoryRight = m_Player.FindAction("InventoryRight", throwIfNotFound: true);
        m_Player_InventoryLeft = m_Player.FindAction("InventoryLeft", throwIfNotFound: true);
        m_Player_dropItem = m_Player.FindAction("dropItem", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_PausedGame = m_Game.FindAction("PausedGame", throwIfNotFound: true);
        m_Game_Map = m_Game.FindAction("Map", throwIfNotFound: true);
        m_Game_MapSetTarget = m_Game.FindAction("MapSetTarget", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_FindPath;
    private readonly InputAction m_Player_InventoryRight;
    private readonly InputAction m_Player_InventoryLeft;
    private readonly InputAction m_Player_dropItem;
    public struct PlayerActions
    {
        private @PlayerControl m_Wrapper;
        public PlayerActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @FindPath => m_Wrapper.m_Player_FindPath;
        public InputAction @InventoryRight => m_Wrapper.m_Player_InventoryRight;
        public InputAction @InventoryLeft => m_Wrapper.m_Player_InventoryLeft;
        public InputAction @dropItem => m_Wrapper.m_Player_dropItem;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @FindPath.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFindPath;
                @FindPath.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFindPath;
                @FindPath.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFindPath;
                @InventoryRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryRight;
                @InventoryRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryRight;
                @InventoryRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryRight;
                @InventoryLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryLeft;
                @InventoryLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryLeft;
                @InventoryLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryLeft;
                @dropItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @dropItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
                @dropItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDropItem;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @FindPath.started += instance.OnFindPath;
                @FindPath.performed += instance.OnFindPath;
                @FindPath.canceled += instance.OnFindPath;
                @InventoryRight.started += instance.OnInventoryRight;
                @InventoryRight.performed += instance.OnInventoryRight;
                @InventoryRight.canceled += instance.OnInventoryRight;
                @InventoryLeft.started += instance.OnInventoryLeft;
                @InventoryLeft.performed += instance.OnInventoryLeft;
                @InventoryLeft.canceled += instance.OnInventoryLeft;
                @dropItem.started += instance.OnDropItem;
                @dropItem.performed += instance.OnDropItem;
                @dropItem.canceled += instance.OnDropItem;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Zoom;
    public struct CameraActions
    {
        private @PlayerControl m_Wrapper;
        public CameraActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_PausedGame;
    private readonly InputAction m_Game_Map;
    private readonly InputAction m_Game_MapSetTarget;
    public struct GameActions
    {
        private @PlayerControl m_Wrapper;
        public GameActions(@PlayerControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @PausedGame => m_Wrapper.m_Game_PausedGame;
        public InputAction @Map => m_Wrapper.m_Game_Map;
        public InputAction @MapSetTarget => m_Wrapper.m_Game_MapSetTarget;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @PausedGame.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPausedGame;
                @PausedGame.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPausedGame;
                @PausedGame.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPausedGame;
                @Map.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMap;
                @Map.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMap;
                @Map.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMap;
                @MapSetTarget.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMapSetTarget;
                @MapSetTarget.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMapSetTarget;
                @MapSetTarget.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMapSetTarget;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PausedGame.started += instance.OnPausedGame;
                @PausedGame.performed += instance.OnPausedGame;
                @PausedGame.canceled += instance.OnPausedGame;
                @Map.started += instance.OnMap;
                @Map.performed += instance.OnMap;
                @Map.canceled += instance.OnMap;
                @MapSetTarget.started += instance.OnMapSetTarget;
                @MapSetTarget.performed += instance.OnMapSetTarget;
                @MapSetTarget.canceled += instance.OnMapSetTarget;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnFindPath(InputAction.CallbackContext context);
        void OnInventoryRight(InputAction.CallbackContext context);
        void OnInventoryLeft(InputAction.CallbackContext context);
        void OnDropItem(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnZoom(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnPausedGame(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
        void OnMapSetTarget(InputAction.CallbackContext context);
    }
}
