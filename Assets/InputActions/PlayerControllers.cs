// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PlayerControllers.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControllers : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllers()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllers"",
    ""maps"": [
        {
            ""name"": ""New action map"",
            ""id"": ""bb1f3d94-f0fe-41a4-bba3-1be460abd622"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""86bfa314-1b93-49f6-9bc9-1b0270265219"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SetMovePostion"",
                    ""type"": ""Button"",
                    ""id"": ""d4bb7404-9e35-4124-86a5-bb1733b92a18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""b2144ccf-4c42-4279-a650-976da779c43c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f0d52d7-ef6b-4f61-967b-73eb0722ea0b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d307240-aa84-4628-993b-d8df1d11b0a6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetMovePostion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa576cc6-24ad-47f4-8e85-8d591980c0d5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
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
        }
    ]
}");
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Fire = m_Newactionmap.FindAction("Fire", throwIfNotFound: true);
        m_Newactionmap_SetMovePostion = m_Newactionmap.FindAction("SetMovePostion", throwIfNotFound: true);
        m_Newactionmap_Reset = m_Newactionmap.FindAction("Reset", throwIfNotFound: true);
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

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Fire;
    private readonly InputAction m_Newactionmap_SetMovePostion;
    private readonly InputAction m_Newactionmap_Reset;
    public struct NewactionmapActions
    {
        private @PlayerControllers m_Wrapper;
        public NewactionmapActions(@PlayerControllers wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Newactionmap_Fire;
        public InputAction @SetMovePostion => m_Wrapper.m_Newactionmap_SetMovePostion;
        public InputAction @Reset => m_Wrapper.m_Newactionmap_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnFire;
                @SetMovePostion.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSetMovePostion;
                @SetMovePostion.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSetMovePostion;
                @SetMovePostion.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSetMovePostion;
                @Reset.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @SetMovePostion.started += instance.OnSetMovePostion;
                @SetMovePostion.performed += instance.OnSetMovePostion;
                @SetMovePostion.canceled += instance.OnSetMovePostion;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface INewactionmapActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnSetMovePostion(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}
