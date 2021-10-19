// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Touch.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Touch : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Touch()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Touch"",
    ""maps"": [
        {
            ""name"": ""Swipe"",
            ""id"": ""6635d544-9f9f-424b-bb79-294dacc4290a"",
            ""actions"": [
                {
                    ""name"": ""Primary Contact"",
                    ""type"": ""Button"",
                    ""id"": ""5e1117ea-984f-4f10-b6cf-088b663c8d62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Primary Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bdcb997d-2a89-43e7-bc8b-b5247186a124"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8cac84fb-b2be-4523-a322-1d599dd01580"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Primary Contact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8792ff30-b8c1-4076-a256-146151384161"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Web"",
                    ""action"": ""Primary Contact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a597da6-e9f3-497d-9db4-a4171e4bf5e7"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Primary Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b41ee4fb-e017-4254-8a7d-fef2bde0dc53"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Web"",
                    ""action"": ""Primary Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": []
        },
        {
            ""name"": ""Web"",
            ""bindingGroup"": ""Web"",
            ""devices"": []
        }
    ]
}");
        // Swipe
        m_Swipe = asset.FindActionMap("Swipe", throwIfNotFound: true);
        m_Swipe_PrimaryContact = m_Swipe.FindAction("Primary Contact", throwIfNotFound: true);
        m_Swipe_PrimaryPosition = m_Swipe.FindAction("Primary Position", throwIfNotFound: true);
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

    // Swipe
    private readonly InputActionMap m_Swipe;
    private ISwipeActions m_SwipeActionsCallbackInterface;
    private readonly InputAction m_Swipe_PrimaryContact;
    private readonly InputAction m_Swipe_PrimaryPosition;
    public struct SwipeActions
    {
        private @Touch m_Wrapper;
        public SwipeActions(@Touch wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryContact => m_Wrapper.m_Swipe_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_Swipe_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Swipe; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SwipeActions set) { return set.Get(); }
        public void SetCallbacks(ISwipeActions instance)
        {
            if (m_Wrapper.m_SwipeActionsCallbackInterface != null)
            {
                @PrimaryContact.started -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_SwipeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public SwipeActions @Swipe => new SwipeActions(this);
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    private int m_WebSchemeIndex = -1;
    public InputControlScheme WebScheme
    {
        get
        {
            if (m_WebSchemeIndex == -1) m_WebSchemeIndex = asset.FindControlSchemeIndex("Web");
            return asset.controlSchemes[m_WebSchemeIndex];
        }
    }
    public interface ISwipeActions
    {
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}
