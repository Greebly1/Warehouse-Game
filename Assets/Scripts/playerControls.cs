//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/playerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerControls"",
    ""maps"": [
        {
            ""name"": ""gamePlay"",
            ""id"": ""809dd2ed-b7b3-485a-a2d0-6ffe83764d55"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""cdf5f6e5-6483-4cf1-83f1-8f9174f8fc22"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""mouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""193a0fbb-5cf2-40d9-8ab6-29154accfccb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""358fa7e2-9c76-4ce2-a771-4edd1f279fed"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8d5d8e82-d36b-4af3-a751-746f7eaad151"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f02dea9d-6c21-45a7-95ca-b0fcc4859de0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""581f4c1b-aa62-4da7-a129-01b1417a6fdd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7dc99429-3c22-4022-9a8b-16184ce0e3f9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""425fa22a-ee99-45ba-9a3c-07cb38132537"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b737c8d8-16ce-457d-b2e4-3f9f1ea36197"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""mouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""title"",
            ""id"": ""ee047cbd-fc6e-4d4c-825a-5eaa6945ac7f"",
            ""actions"": [
                {
                    ""name"": ""submit"",
                    ""type"": ""Button"",
                    ""id"": ""f3ae6c16-3dbc-43e7-bf8a-9eab47cf0014"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f66e3329-8439-46e0-88c2-26959d653514"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""menu"",
            ""id"": ""32f16a31-d3a4-4174-a04c-f49f18d3001c"",
            ""actions"": [
                {
                    ""name"": ""play"",
                    ""type"": ""Button"",
                    ""id"": ""39df85cb-76a8-41e3-929a-a7a73cbbe2e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""exit"",
                    ""type"": ""Button"",
                    ""id"": ""0673d035-6bb4-4ec0-8d74-38237d53206c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""246fbd98-489a-4403-ade6-190b80953041"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdcf7ff9-1777-48fc-bb42-ae9240bbcf11"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""M&K"",
            ""bindingGroup"": ""M&K"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gamePlay
        m_gamePlay = asset.FindActionMap("gamePlay", throwIfNotFound: true);
        m_gamePlay_move = m_gamePlay.FindAction("move", throwIfNotFound: true);
        m_gamePlay_mouseMove = m_gamePlay.FindAction("mouseMove", throwIfNotFound: true);
        // title
        m_title = asset.FindActionMap("title", throwIfNotFound: true);
        m_title_submit = m_title.FindAction("submit", throwIfNotFound: true);
        // menu
        m_menu = asset.FindActionMap("menu", throwIfNotFound: true);
        m_menu_play = m_menu.FindAction("play", throwIfNotFound: true);
        m_menu_exit = m_menu.FindAction("exit", throwIfNotFound: true);
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

    // gamePlay
    private readonly InputActionMap m_gamePlay;
    private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
    private readonly InputAction m_gamePlay_move;
    private readonly InputAction m_gamePlay_mouseMove;
    public struct GamePlayActions
    {
        private @PlayerControls m_Wrapper;
        public GamePlayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_gamePlay_move;
        public InputAction @mouseMove => m_Wrapper.m_gamePlay_mouseMove;
        public InputActionMap Get() { return m_Wrapper.m_gamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void AddCallbacks(IGamePlayActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @mouseMove.started += instance.OnMouseMove;
            @mouseMove.performed += instance.OnMouseMove;
            @mouseMove.canceled += instance.OnMouseMove;
        }

        private void UnregisterCallbacks(IGamePlayActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @mouseMove.started -= instance.OnMouseMove;
            @mouseMove.performed -= instance.OnMouseMove;
            @mouseMove.canceled -= instance.OnMouseMove;
        }

        public void RemoveCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePlayActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePlayActions @gamePlay => new GamePlayActions(this);

    // title
    private readonly InputActionMap m_title;
    private List<ITitleActions> m_TitleActionsCallbackInterfaces = new List<ITitleActions>();
    private readonly InputAction m_title_submit;
    public struct TitleActions
    {
        private @PlayerControls m_Wrapper;
        public TitleActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @submit => m_Wrapper.m_title_submit;
        public InputActionMap Get() { return m_Wrapper.m_title; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TitleActions set) { return set.Get(); }
        public void AddCallbacks(ITitleActions instance)
        {
            if (instance == null || m_Wrapper.m_TitleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TitleActionsCallbackInterfaces.Add(instance);
            @submit.started += instance.OnSubmit;
            @submit.performed += instance.OnSubmit;
            @submit.canceled += instance.OnSubmit;
        }

        private void UnregisterCallbacks(ITitleActions instance)
        {
            @submit.started -= instance.OnSubmit;
            @submit.performed -= instance.OnSubmit;
            @submit.canceled -= instance.OnSubmit;
        }

        public void RemoveCallbacks(ITitleActions instance)
        {
            if (m_Wrapper.m_TitleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITitleActions instance)
        {
            foreach (var item in m_Wrapper.m_TitleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TitleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TitleActions @title => new TitleActions(this);

    // menu
    private readonly InputActionMap m_menu;
    private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
    private readonly InputAction m_menu_play;
    private readonly InputAction m_menu_exit;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @play => m_Wrapper.m_menu_play;
        public InputAction @exit => m_Wrapper.m_menu_exit;
        public InputActionMap Get() { return m_Wrapper.m_menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
            @play.started += instance.OnPlay;
            @play.performed += instance.OnPlay;
            @play.canceled += instance.OnPlay;
            @exit.started += instance.OnExit;
            @exit.performed += instance.OnExit;
            @exit.canceled += instance.OnExit;
        }

        private void UnregisterCallbacks(IMenuActions instance)
        {
            @play.started -= instance.OnPlay;
            @play.performed -= instance.OnPlay;
            @play.canceled -= instance.OnPlay;
            @exit.started -= instance.OnExit;
            @exit.performed -= instance.OnExit;
            @exit.canceled -= instance.OnExit;
        }

        public void RemoveCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuActions @menu => new MenuActions(this);
    private int m_MKSchemeIndex = -1;
    public InputControlScheme MKScheme
    {
        get
        {
            if (m_MKSchemeIndex == -1) m_MKSchemeIndex = asset.FindControlSchemeIndex("M&K");
            return asset.controlSchemes[m_MKSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
    }
    public interface ITitleActions
    {
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnPlay(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
