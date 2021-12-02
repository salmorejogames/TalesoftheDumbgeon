// GENERATED AUTOMATICALLY FROM 'Assets/Interface/InterfaceControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InterfaceControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InterfaceControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InterfaceControls"",
    ""maps"": [
        {
            ""name"": ""Menu principal"",
            ""id"": ""ea2ff777-5172-4a88-b68d-b39a85b8879e"",
            ""actions"": [
                {
                    ""name"": ""Animacion puerta"",
                    ""type"": ""Button"",
                    ""id"": ""ea65e7a6-970a-4649-998c-a1bf88c6bef1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce05256d-c4e2-4727-91ba-702fa3fd815d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Animacion puerta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512edf37-252e-41aa-b8ba-e0779af1bf4e"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Animacion puerta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu pausa"",
            ""id"": ""816d2441-a456-43dc-9f06-055af2fecf42"",
            ""actions"": [
                {
                    ""name"": ""Pausa"",
                    ""type"": ""Button"",
                    ""id"": ""fdf406b5-3bcf-44f3-ba27-05c43fa53c21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dd32c09e-38a9-4391-ad09-a7e041bb14a1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu principal
        m_Menuprincipal = asset.FindActionMap("Menu principal", throwIfNotFound: true);
        m_Menuprincipal_Animacionpuerta = m_Menuprincipal.FindAction("Animacion puerta", throwIfNotFound: true);
        // Menu pausa
        m_Menupausa = asset.FindActionMap("Menu pausa", throwIfNotFound: true);
        m_Menupausa_Pausa = m_Menupausa.FindAction("Pausa", throwIfNotFound: true);
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

    // Menu principal
    private readonly InputActionMap m_Menuprincipal;
    private IMenuprincipalActions m_MenuprincipalActionsCallbackInterface;
    private readonly InputAction m_Menuprincipal_Animacionpuerta;
    public struct MenuprincipalActions
    {
        private @InterfaceControls m_Wrapper;
        public MenuprincipalActions(@InterfaceControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Animacionpuerta => m_Wrapper.m_Menuprincipal_Animacionpuerta;
        public InputActionMap Get() { return m_Wrapper.m_Menuprincipal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuprincipalActions set) { return set.Get(); }
        public void SetCallbacks(IMenuprincipalActions instance)
        {
            if (m_Wrapper.m_MenuprincipalActionsCallbackInterface != null)
            {
                @Animacionpuerta.started -= m_Wrapper.m_MenuprincipalActionsCallbackInterface.OnAnimacionpuerta;
                @Animacionpuerta.performed -= m_Wrapper.m_MenuprincipalActionsCallbackInterface.OnAnimacionpuerta;
                @Animacionpuerta.canceled -= m_Wrapper.m_MenuprincipalActionsCallbackInterface.OnAnimacionpuerta;
            }
            m_Wrapper.m_MenuprincipalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Animacionpuerta.started += instance.OnAnimacionpuerta;
                @Animacionpuerta.performed += instance.OnAnimacionpuerta;
                @Animacionpuerta.canceled += instance.OnAnimacionpuerta;
            }
        }
    }
    public MenuprincipalActions @Menuprincipal => new MenuprincipalActions(this);

    // Menu pausa
    private readonly InputActionMap m_Menupausa;
    private IMenupausaActions m_MenupausaActionsCallbackInterface;
    private readonly InputAction m_Menupausa_Pausa;
    public struct MenupausaActions
    {
        private @InterfaceControls m_Wrapper;
        public MenupausaActions(@InterfaceControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pausa => m_Wrapper.m_Menupausa_Pausa;
        public InputActionMap Get() { return m_Wrapper.m_Menupausa; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenupausaActions set) { return set.Get(); }
        public void SetCallbacks(IMenupausaActions instance)
        {
            if (m_Wrapper.m_MenupausaActionsCallbackInterface != null)
            {
                @Pausa.started -= m_Wrapper.m_MenupausaActionsCallbackInterface.OnPausa;
                @Pausa.performed -= m_Wrapper.m_MenupausaActionsCallbackInterface.OnPausa;
                @Pausa.canceled -= m_Wrapper.m_MenupausaActionsCallbackInterface.OnPausa;
            }
            m_Wrapper.m_MenupausaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pausa.started += instance.OnPausa;
                @Pausa.performed += instance.OnPausa;
                @Pausa.canceled += instance.OnPausa;
            }
        }
    }
    public MenupausaActions @Menupausa => new MenupausaActions(this);
    public interface IMenuprincipalActions
    {
        void OnAnimacionpuerta(InputAction.CallbackContext context);
    }
    public interface IMenupausaActions
    {
        void OnPausa(InputAction.CallbackContext context);
    }
}
