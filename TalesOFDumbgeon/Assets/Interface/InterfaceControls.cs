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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu principal
        m_Menuprincipal = asset.FindActionMap("Menu principal", throwIfNotFound: true);
        m_Menuprincipal_Animacionpuerta = m_Menuprincipal.FindAction("Animacion puerta", throwIfNotFound: true);
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
    public interface IMenuprincipalActions
    {
        void OnAnimacionpuerta(InputAction.CallbackContext context);
    }
}
