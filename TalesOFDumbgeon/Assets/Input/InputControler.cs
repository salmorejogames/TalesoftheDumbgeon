// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputControler.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControler : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControler"",
    ""maps"": [
        {
            ""name"": ""Jugador"",
            ""id"": ""dff3a509-bfff-4f54-a2a3-8057c156d575"",
            ""actions"": [
                {
                    ""name"": ""Atacar"",
                    ""type"": ""Button"",
                    ""id"": ""a4d93eab-15f8-494b-967d-e6b67c991abe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9db0b795-d70f-4922-8658-4ea12e7945d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Habilidad1"",
                    ""type"": ""Button"",
                    ""id"": ""0660f887-217b-49b5-8dba-138b6cb90692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Habilidad2"",
                    ""type"": ""Button"",
                    ""id"": ""2179bafb-a7e8-43ab-b39f-e8f38f646884"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Habilidad3"",
                    ""type"": ""Button"",
                    ""id"": ""4086f20b-0ff5-4f55-bcea-607c9da86379"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Habilidad4"",
                    ""type"": ""Button"",
                    ""id"": ""916355de-f950-47c2-9064-e36e6297740a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SacarCartas"",
                    ""type"": ""Button"",
                    ""id"": ""d2421e23-d085-4350-9a62-b63185e01aee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NuevaCarta"",
                    ""type"": ""Button"",
                    ""id"": ""a69fbfd3-a3d9-47c5-abb6-139baa45917a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectLeft"",
                    ""type"": ""Button"",
                    ""id"": ""def15830-59ac-4fa5-b47d-c793c177b68b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectRight"",
                    ""type"": ""Button"",
                    ""id"": ""0885620a-1762-4110-8b9c-089a2b1eca02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterSelection"",
                    ""type"": ""Button"",
                    ""id"": ""cb48e8d1-5b5f-4261-be86-ef000ea355d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""32ca27cc-3d56-4161-bb34-2154e6d8310f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""225e5332-d3e8-4aaf-bbe1-747451ecae5a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Atacar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2f1cda3b-13cd-42ac-a098-14c446858477"",
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
                    ""id"": ""39406c00-fb26-427a-a4f4-317623a9c9fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2500acd6-b97c-4aa3-8e1a-aac6b580b175"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f2001d28-21a9-46cd-a5e9-d7897f536188"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""92f48d24-5942-4c2a-9c8e-e9bc02c4702e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ac76bbb4-64f4-4bb6-abf9-7ae76ecc1acd"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Habilidad1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bacb882-4d41-48ba-9cb9-45ea2c1f8003"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Habilidad2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c62dc70e-ee8f-470d-9ce7-b87ee803e902"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Habilidad3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""737a2b04-c002-4aa0-99d4-713d77939250"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Habilidad4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""867a2ca4-4f5b-44a3-ad82-a4e8a9efe7a7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""SacarCartas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56f99b78-1da8-49e6-bdcd-bffba2d1457d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NuevaCarta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a1d2657-f37f-4147-ba55-84f455d13262"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4aefb0d-03df-4f0e-a8c2-d892a130fab3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03dc2ef9-3ef0-49c7-a44f-4b4c5f4ad751"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1d8831bc-d17a-447b-ae11-6b5241995fe7"",
                    ""path"": ""1DAxis(minValue=0)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""91e62002-7435-46a0-990e-e5a69d01efcb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""847b02e9-164b-42c0-997d-aa0816421f53"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard and mouse"",
            ""bindingGroup"": ""keyboard and mouse"",
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
        // Jugador
        m_Jugador = asset.FindActionMap("Jugador", throwIfNotFound: true);
        m_Jugador_Atacar = m_Jugador.FindAction("Atacar", throwIfNotFound: true);
        m_Jugador_Move = m_Jugador.FindAction("Move", throwIfNotFound: true);
        m_Jugador_Habilidad1 = m_Jugador.FindAction("Habilidad1", throwIfNotFound: true);
        m_Jugador_Habilidad2 = m_Jugador.FindAction("Habilidad2", throwIfNotFound: true);
        m_Jugador_Habilidad3 = m_Jugador.FindAction("Habilidad3", throwIfNotFound: true);
        m_Jugador_Habilidad4 = m_Jugador.FindAction("Habilidad4", throwIfNotFound: true);
        m_Jugador_SacarCartas = m_Jugador.FindAction("SacarCartas", throwIfNotFound: true);
        m_Jugador_NuevaCarta = m_Jugador.FindAction("NuevaCarta", throwIfNotFound: true);
        m_Jugador_SelectLeft = m_Jugador.FindAction("SelectLeft", throwIfNotFound: true);
        m_Jugador_SelectRight = m_Jugador.FindAction("SelectRight", throwIfNotFound: true);
        m_Jugador_EnterSelection = m_Jugador.FindAction("EnterSelection", throwIfNotFound: true);
        m_Jugador_Selection = m_Jugador.FindAction("Selection", throwIfNotFound: true);
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

    // Jugador
    private readonly InputActionMap m_Jugador;
    private IJugadorActions m_JugadorActionsCallbackInterface;
    private readonly InputAction m_Jugador_Atacar;
    private readonly InputAction m_Jugador_Move;
    private readonly InputAction m_Jugador_Habilidad1;
    private readonly InputAction m_Jugador_Habilidad2;
    private readonly InputAction m_Jugador_Habilidad3;
    private readonly InputAction m_Jugador_Habilidad4;
    private readonly InputAction m_Jugador_SacarCartas;
    private readonly InputAction m_Jugador_NuevaCarta;
    private readonly InputAction m_Jugador_SelectLeft;
    private readonly InputAction m_Jugador_SelectRight;
    private readonly InputAction m_Jugador_EnterSelection;
    private readonly InputAction m_Jugador_Selection;
    public struct JugadorActions
    {
        private @InputControler m_Wrapper;
        public JugadorActions(@InputControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Atacar => m_Wrapper.m_Jugador_Atacar;
        public InputAction @Move => m_Wrapper.m_Jugador_Move;
        public InputAction @Habilidad1 => m_Wrapper.m_Jugador_Habilidad1;
        public InputAction @Habilidad2 => m_Wrapper.m_Jugador_Habilidad2;
        public InputAction @Habilidad3 => m_Wrapper.m_Jugador_Habilidad3;
        public InputAction @Habilidad4 => m_Wrapper.m_Jugador_Habilidad4;
        public InputAction @SacarCartas => m_Wrapper.m_Jugador_SacarCartas;
        public InputAction @NuevaCarta => m_Wrapper.m_Jugador_NuevaCarta;
        public InputAction @SelectLeft => m_Wrapper.m_Jugador_SelectLeft;
        public InputAction @SelectRight => m_Wrapper.m_Jugador_SelectRight;
        public InputAction @EnterSelection => m_Wrapper.m_Jugador_EnterSelection;
        public InputAction @Selection => m_Wrapper.m_Jugador_Selection;
        public InputActionMap Get() { return m_Wrapper.m_Jugador; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JugadorActions set) { return set.Get(); }
        public void SetCallbacks(IJugadorActions instance)
        {
            if (m_Wrapper.m_JugadorActionsCallbackInterface != null)
            {
                @Atacar.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtacar;
                @Atacar.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtacar;
                @Atacar.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnAtacar;
                @Move.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnMove;
                @Habilidad1.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad1;
                @Habilidad1.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad1;
                @Habilidad1.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad1;
                @Habilidad2.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad2;
                @Habilidad2.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad2;
                @Habilidad2.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad2;
                @Habilidad3.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad3;
                @Habilidad3.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad3;
                @Habilidad3.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad3;
                @Habilidad4.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad4;
                @Habilidad4.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad4;
                @Habilidad4.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHabilidad4;
                @SacarCartas.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSacarCartas;
                @SacarCartas.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSacarCartas;
                @SacarCartas.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSacarCartas;
                @NuevaCarta.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnNuevaCarta;
                @NuevaCarta.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnNuevaCarta;
                @NuevaCarta.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnNuevaCarta;
                @SelectLeft.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelectLeft;
                @SelectLeft.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelectLeft;
                @SelectLeft.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelectLeft;
                @SelectRight.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelectRight;
                @SelectRight.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelectRight;
                @SelectRight.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelectRight;
                @EnterSelection.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnEnterSelection;
                @EnterSelection.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnEnterSelection;
                @EnterSelection.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnEnterSelection;
                @Selection.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSelection;
            }
            m_Wrapper.m_JugadorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Atacar.started += instance.OnAtacar;
                @Atacar.performed += instance.OnAtacar;
                @Atacar.canceled += instance.OnAtacar;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Habilidad1.started += instance.OnHabilidad1;
                @Habilidad1.performed += instance.OnHabilidad1;
                @Habilidad1.canceled += instance.OnHabilidad1;
                @Habilidad2.started += instance.OnHabilidad2;
                @Habilidad2.performed += instance.OnHabilidad2;
                @Habilidad2.canceled += instance.OnHabilidad2;
                @Habilidad3.started += instance.OnHabilidad3;
                @Habilidad3.performed += instance.OnHabilidad3;
                @Habilidad3.canceled += instance.OnHabilidad3;
                @Habilidad4.started += instance.OnHabilidad4;
                @Habilidad4.performed += instance.OnHabilidad4;
                @Habilidad4.canceled += instance.OnHabilidad4;
                @SacarCartas.started += instance.OnSacarCartas;
                @SacarCartas.performed += instance.OnSacarCartas;
                @SacarCartas.canceled += instance.OnSacarCartas;
                @NuevaCarta.started += instance.OnNuevaCarta;
                @NuevaCarta.performed += instance.OnNuevaCarta;
                @NuevaCarta.canceled += instance.OnNuevaCarta;
                @SelectLeft.started += instance.OnSelectLeft;
                @SelectLeft.performed += instance.OnSelectLeft;
                @SelectLeft.canceled += instance.OnSelectLeft;
                @SelectRight.started += instance.OnSelectRight;
                @SelectRight.performed += instance.OnSelectRight;
                @SelectRight.canceled += instance.OnSelectRight;
                @EnterSelection.started += instance.OnEnterSelection;
                @EnterSelection.performed += instance.OnEnterSelection;
                @EnterSelection.canceled += instance.OnEnterSelection;
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
            }
        }
    }
    public JugadorActions @Jugador => new JugadorActions(this);
    private int m_keyboardandmouseSchemeIndex = -1;
    public InputControlScheme keyboardandmouseScheme
    {
        get
        {
            if (m_keyboardandmouseSchemeIndex == -1) m_keyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("keyboard and mouse");
            return asset.controlSchemes[m_keyboardandmouseSchemeIndex];
        }
    }
    public interface IJugadorActions
    {
        void OnAtacar(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnHabilidad1(InputAction.CallbackContext context);
        void OnHabilidad2(InputAction.CallbackContext context);
        void OnHabilidad3(InputAction.CallbackContext context);
        void OnHabilidad4(InputAction.CallbackContext context);
        void OnSacarCartas(InputAction.CallbackContext context);
        void OnNuevaCarta(InputAction.CallbackContext context);
        void OnSelectLeft(InputAction.CallbackContext context);
        void OnSelectRight(InputAction.CallbackContext context);
        void OnEnterSelection(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
    }
}
