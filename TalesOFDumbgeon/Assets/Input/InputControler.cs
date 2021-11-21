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
                    ""name"": ""Hechizo"",
                    ""type"": ""Button"",
                    ""id"": ""f74cebfa-95a1-43e9-a10a-7c9591b9464b"",
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
                    ""name"": """",
                    ""id"": ""316e1c9c-37f6-4eb5-b890-249a553e87fa"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Movil;keyboard and mouse"",
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
                    ""id"": ""c010437f-915e-49aa-af78-f4feae2401c2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Movil;keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""id"": ""49a76a04-deb1-48ee-a40f-176df16535e1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Hechizo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d63718d3-a41b-4da2-8669-5d4b61f7d180"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse;Movil"",
                    ""action"": ""Hechizo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Cartas"",
            ""id"": ""d45b7e8c-4058-4d5b-b2f3-ff1bf250f8cc"",
            ""actions"": [
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""e7b26a5e-e6f8-42f5-9467-b4907869b8b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterSelection"",
                    ""type"": ""Button"",
                    ""id"": ""ade597e0-007f-4d9c-8e83-8c7d9695c7e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NuevaCarta"",
                    ""type"": ""Button"",
                    ""id"": ""a7800c16-b3a1-4a6d-837d-52a9a34caaad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SacarCartas"",
                    ""type"": ""Button"",
                    ""id"": ""e1403435-90b3-4875-9682-ba86743463a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ModoEliminar"",
                    ""type"": ""Button"",
                    ""id"": ""978e5f93-af25-411b-8992-d990a8ae92fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fce220d1-5f7e-4336-8a01-c33b6783d009"",
                    ""path"": ""<Keyboard>/pageDown"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""NuevaCarta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d801b3ee-7d00-4e53-b55e-ac654f1d8d19"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""EnterSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5ea9f418-0831-4ed6-9185-a18ac772b6d9"",
                    ""path"": ""1DAxis(minValue=0)"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(max=1)"",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9fdbd5bd-30bc-4628-9077-383cee4b1404"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bbea5f70-caba-4e37-bad9-7eeb450ffbe0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard and mouse"",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8e2e4203-293e-4af8-a1e6-2f0fd75ffe35"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModoEliminar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbd63b1c-edda-4398-9f50-5b6325c5a5cd"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SacarCartas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        },
        {
            ""name"": ""Movil"",
            ""bindingGroup"": ""Movil"",
            ""devices"": []
        }
    ]
}");
        // Jugador
        m_Jugador = asset.FindActionMap("Jugador", throwIfNotFound: true);
        m_Jugador_Atacar = m_Jugador.FindAction("Atacar", throwIfNotFound: true);
        m_Jugador_Hechizo = m_Jugador.FindAction("Hechizo", throwIfNotFound: true);
        m_Jugador_Move = m_Jugador.FindAction("Move", throwIfNotFound: true);
        m_Jugador_Habilidad1 = m_Jugador.FindAction("Habilidad1", throwIfNotFound: true);
        m_Jugador_Habilidad2 = m_Jugador.FindAction("Habilidad2", throwIfNotFound: true);
        m_Jugador_Habilidad3 = m_Jugador.FindAction("Habilidad3", throwIfNotFound: true);
        m_Jugador_Habilidad4 = m_Jugador.FindAction("Habilidad4", throwIfNotFound: true);
        // Cartas
        m_Cartas = asset.FindActionMap("Cartas", throwIfNotFound: true);
        m_Cartas_Selection = m_Cartas.FindAction("Selection", throwIfNotFound: true);
        m_Cartas_EnterSelection = m_Cartas.FindAction("EnterSelection", throwIfNotFound: true);
        m_Cartas_NuevaCarta = m_Cartas.FindAction("NuevaCarta", throwIfNotFound: true);
        m_Cartas_SacarCartas = m_Cartas.FindAction("SacarCartas", throwIfNotFound: true);
        m_Cartas_ModoEliminar = m_Cartas.FindAction("ModoEliminar", throwIfNotFound: true);
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
    private readonly InputAction m_Jugador_Hechizo;
    private readonly InputAction m_Jugador_Move;
    private readonly InputAction m_Jugador_Habilidad1;
    private readonly InputAction m_Jugador_Habilidad2;
    private readonly InputAction m_Jugador_Habilidad3;
    private readonly InputAction m_Jugador_Habilidad4;
    public struct JugadorActions
    {
        private @InputControler m_Wrapper;
        public JugadorActions(@InputControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Atacar => m_Wrapper.m_Jugador_Atacar;
        public InputAction @Hechizo => m_Wrapper.m_Jugador_Hechizo;
        public InputAction @Move => m_Wrapper.m_Jugador_Move;
        public InputAction @Habilidad1 => m_Wrapper.m_Jugador_Habilidad1;
        public InputAction @Habilidad2 => m_Wrapper.m_Jugador_Habilidad2;
        public InputAction @Habilidad3 => m_Wrapper.m_Jugador_Habilidad3;
        public InputAction @Habilidad4 => m_Wrapper.m_Jugador_Habilidad4;
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
                @Hechizo.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHechizo;
                @Hechizo.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHechizo;
                @Hechizo.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnHechizo;
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
            }
            m_Wrapper.m_JugadorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Atacar.started += instance.OnAtacar;
                @Atacar.performed += instance.OnAtacar;
                @Atacar.canceled += instance.OnAtacar;
                @Hechizo.started += instance.OnHechizo;
                @Hechizo.performed += instance.OnHechizo;
                @Hechizo.canceled += instance.OnHechizo;
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
            }
        }
    }
    public JugadorActions @Jugador => new JugadorActions(this);

    // Cartas
    private readonly InputActionMap m_Cartas;
    private ICartasActions m_CartasActionsCallbackInterface;
    private readonly InputAction m_Cartas_Selection;
    private readonly InputAction m_Cartas_EnterSelection;
    private readonly InputAction m_Cartas_NuevaCarta;
    private readonly InputAction m_Cartas_SacarCartas;
    private readonly InputAction m_Cartas_ModoEliminar;
    public struct CartasActions
    {
        private @InputControler m_Wrapper;
        public CartasActions(@InputControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Selection => m_Wrapper.m_Cartas_Selection;
        public InputAction @EnterSelection => m_Wrapper.m_Cartas_EnterSelection;
        public InputAction @NuevaCarta => m_Wrapper.m_Cartas_NuevaCarta;
        public InputAction @SacarCartas => m_Wrapper.m_Cartas_SacarCartas;
        public InputAction @ModoEliminar => m_Wrapper.m_Cartas_ModoEliminar;
        public InputActionMap Get() { return m_Wrapper.m_Cartas; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CartasActions set) { return set.Get(); }
        public void SetCallbacks(ICartasActions instance)
        {
            if (m_Wrapper.m_CartasActionsCallbackInterface != null)
            {
                @Selection.started -= m_Wrapper.m_CartasActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_CartasActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_CartasActionsCallbackInterface.OnSelection;
                @EnterSelection.started -= m_Wrapper.m_CartasActionsCallbackInterface.OnEnterSelection;
                @EnterSelection.performed -= m_Wrapper.m_CartasActionsCallbackInterface.OnEnterSelection;
                @EnterSelection.canceled -= m_Wrapper.m_CartasActionsCallbackInterface.OnEnterSelection;
                @NuevaCarta.started -= m_Wrapper.m_CartasActionsCallbackInterface.OnNuevaCarta;
                @NuevaCarta.performed -= m_Wrapper.m_CartasActionsCallbackInterface.OnNuevaCarta;
                @NuevaCarta.canceled -= m_Wrapper.m_CartasActionsCallbackInterface.OnNuevaCarta;
                @SacarCartas.started -= m_Wrapper.m_CartasActionsCallbackInterface.OnSacarCartas;
                @SacarCartas.performed -= m_Wrapper.m_CartasActionsCallbackInterface.OnSacarCartas;
                @SacarCartas.canceled -= m_Wrapper.m_CartasActionsCallbackInterface.OnSacarCartas;
                @ModoEliminar.started -= m_Wrapper.m_CartasActionsCallbackInterface.OnModoEliminar;
                @ModoEliminar.performed -= m_Wrapper.m_CartasActionsCallbackInterface.OnModoEliminar;
                @ModoEliminar.canceled -= m_Wrapper.m_CartasActionsCallbackInterface.OnModoEliminar;
            }
            m_Wrapper.m_CartasActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
                @EnterSelection.started += instance.OnEnterSelection;
                @EnterSelection.performed += instance.OnEnterSelection;
                @EnterSelection.canceled += instance.OnEnterSelection;
                @NuevaCarta.started += instance.OnNuevaCarta;
                @NuevaCarta.performed += instance.OnNuevaCarta;
                @NuevaCarta.canceled += instance.OnNuevaCarta;
                @SacarCartas.started += instance.OnSacarCartas;
                @SacarCartas.performed += instance.OnSacarCartas;
                @SacarCartas.canceled += instance.OnSacarCartas;
                @ModoEliminar.started += instance.OnModoEliminar;
                @ModoEliminar.performed += instance.OnModoEliminar;
                @ModoEliminar.canceled += instance.OnModoEliminar;
            }
        }
    }
    public CartasActions @Cartas => new CartasActions(this);
    private int m_keyboardandmouseSchemeIndex = -1;
    public InputControlScheme keyboardandmouseScheme
    {
        get
        {
            if (m_keyboardandmouseSchemeIndex == -1) m_keyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("keyboard and mouse");
            return asset.controlSchemes[m_keyboardandmouseSchemeIndex];
        }
    }
    private int m_MovilSchemeIndex = -1;
    public InputControlScheme MovilScheme
    {
        get
        {
            if (m_MovilSchemeIndex == -1) m_MovilSchemeIndex = asset.FindControlSchemeIndex("Movil");
            return asset.controlSchemes[m_MovilSchemeIndex];
        }
    }
    public interface IJugadorActions
    {
        void OnAtacar(InputAction.CallbackContext context);
        void OnHechizo(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnHabilidad1(InputAction.CallbackContext context);
        void OnHabilidad2(InputAction.CallbackContext context);
        void OnHabilidad3(InputAction.CallbackContext context);
        void OnHabilidad4(InputAction.CallbackContext context);
    }
    public interface ICartasActions
    {
        void OnSelection(InputAction.CallbackContext context);
        void OnEnterSelection(InputAction.CallbackContext context);
        void OnNuevaCarta(InputAction.CallbackContext context);
        void OnSacarCartas(InputAction.CallbackContext context);
        void OnModoEliminar(InputAction.CallbackContext context);
    }
}
