// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace StretchySurgeons.Input.Actions
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""c1ef018b-d4c7-43ba-829d-5acedda36de1"",
            ""actions"": [
                {
                    ""name"": ""North"",
                    ""type"": ""Button"",
                    ""id"": ""e6981dd4-9080-4a0b-9d49-169c4ee3d96c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""East"",
                    ""type"": ""Button"",
                    ""id"": ""ea1715aa-82c8-4f6d-bb62-8af31bda727f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""South"",
                    ""type"": ""Button"",
                    ""id"": ""63e5d014-8f7e-435b-b623-f5b069b697de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""West"",
                    ""type"": ""Button"",
                    ""id"": ""38e38e0f-93f5-42b1-9020-48b81a60272a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Activate"",
                    ""type"": ""Button"",
                    ""id"": ""3fdc7aa5-c09f-4bee-9ab3-8136e091e4a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""b8a98e34-ca61-41be-9413-b5f1c34a51ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61fc08f7-c879-4fd0-ac8f-12fcbbde270e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftHalfOfDevice"",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""967a095e-2a8d-42d8-a837-c351e485ad0c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightHalfOfDevice"",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13743ad8-66b1-49de-868e-2ebac7cbc673"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eec880a5-d2bd-4433-b22b-7be390b7eb96"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""North"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4293456-5edb-48aa-aec8-f0897cc96ae5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftHalfOfDevice"",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b62d1cfc-9186-4233-9bd3-5f2ca0ca3700"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightHalfOfDevice"",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3de19e3e-a1f0-4679-9e5f-8ea5e729267a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cb883a5-4403-4536-acd1-5f7ad1b774f0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""East"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85683d49-565d-46e6-9944-6391e0be665d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftHalfOfDevice"",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13f69667-b6a2-41ca-9be9-f2fd5ee1aad6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightHalfOfDevice"",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""570c243f-e1c0-466d-a525-f7bc63dd1b0f"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d252b008-82e6-451d-9583-08abf233e320"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""South"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eb568b6-c4f0-4ade-8f74-050d74c41f26"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftHalfOfDevice"",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e489c81e-b836-47e2-bff3-7cc350140af8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightHalfOfDevice"",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""725a2fe7-1fac-4be7-9a94-8bfb9762bc84"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf7249a4-1c9b-43f2-af8d-892b888eddfa"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""West"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e486201-bac3-4276-a1d2-0c60b01824b3"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftHalfOfDevice"",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5ffe720-6556-4a65-8b90-5adf11c30ac1"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightHalfOfDevice"",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c7b7adc-ec16-4b7e-8411-39f5565724d1"",
                    ""path"": ""*/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae3c7f68-d6ff-4924-83a1-41e18e082f81"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftHalfOfDevice"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78656b14-4a54-4795-b560-0936b4010211"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightHalfOfDevice"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cca2d92-807d-41c7-b5d3-b81dcdccdd0d"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""LeftHalfOfDevice"",
            ""bindingGroup"": ""LeftHalfOfDevice"",
            ""devices"": []
        },
        {
            ""name"": ""RightHalfOfDevice"",
            ""bindingGroup"": ""RightHalfOfDevice"",
            ""devices"": []
        }
    ]
}");
            // Default
            m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
            m_Default_North = m_Default.FindAction("North", throwIfNotFound: true);
            m_Default_East = m_Default.FindAction("East", throwIfNotFound: true);
            m_Default_South = m_Default.FindAction("South", throwIfNotFound: true);
            m_Default_West = m_Default.FindAction("West", throwIfNotFound: true);
            m_Default_Activate = m_Default.FindAction("Activate", throwIfNotFound: true);
            m_Default_Cancel = m_Default.FindAction("Cancel", throwIfNotFound: true);
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

        // Default
        private readonly InputActionMap m_Default;
        private IDefaultActions m_DefaultActionsCallbackInterface;
        private readonly InputAction m_Default_North;
        private readonly InputAction m_Default_East;
        private readonly InputAction m_Default_South;
        private readonly InputAction m_Default_West;
        private readonly InputAction m_Default_Activate;
        private readonly InputAction m_Default_Cancel;
        public struct DefaultActions
        {
            private @PlayerInputActions m_Wrapper;
            public DefaultActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @North => m_Wrapper.m_Default_North;
            public InputAction @East => m_Wrapper.m_Default_East;
            public InputAction @South => m_Wrapper.m_Default_South;
            public InputAction @West => m_Wrapper.m_Default_West;
            public InputAction @Activate => m_Wrapper.m_Default_Activate;
            public InputAction @Cancel => m_Wrapper.m_Default_Cancel;
            public InputActionMap Get() { return m_Wrapper.m_Default; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
            public void SetCallbacks(IDefaultActions instance)
            {
                if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
                {
                    @North.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnNorth;
                    @North.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnNorth;
                    @North.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnNorth;
                    @East.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEast;
                    @East.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEast;
                    @East.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEast;
                    @South.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSouth;
                    @South.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSouth;
                    @South.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSouth;
                    @West.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnWest;
                    @West.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnWest;
                    @West.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnWest;
                    @Activate.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnActivate;
                    @Activate.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnActivate;
                    @Activate.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnActivate;
                    @Cancel.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnCancel;
                }
                m_Wrapper.m_DefaultActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @North.started += instance.OnNorth;
                    @North.performed += instance.OnNorth;
                    @North.canceled += instance.OnNorth;
                    @East.started += instance.OnEast;
                    @East.performed += instance.OnEast;
                    @East.canceled += instance.OnEast;
                    @South.started += instance.OnSouth;
                    @South.performed += instance.OnSouth;
                    @South.canceled += instance.OnSouth;
                    @West.started += instance.OnWest;
                    @West.performed += instance.OnWest;
                    @West.canceled += instance.OnWest;
                    @Activate.started += instance.OnActivate;
                    @Activate.performed += instance.OnActivate;
                    @Activate.canceled += instance.OnActivate;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                }
            }
        }
        public DefaultActions @Default => new DefaultActions(this);
        private int m_LeftHalfOfDeviceSchemeIndex = -1;
        public InputControlScheme LeftHalfOfDeviceScheme
        {
            get
            {
                if (m_LeftHalfOfDeviceSchemeIndex == -1) m_LeftHalfOfDeviceSchemeIndex = asset.FindControlSchemeIndex("LeftHalfOfDevice");
                return asset.controlSchemes[m_LeftHalfOfDeviceSchemeIndex];
            }
        }
        private int m_RightHalfOfDeviceSchemeIndex = -1;
        public InputControlScheme RightHalfOfDeviceScheme
        {
            get
            {
                if (m_RightHalfOfDeviceSchemeIndex == -1) m_RightHalfOfDeviceSchemeIndex = asset.FindControlSchemeIndex("RightHalfOfDevice");
                return asset.controlSchemes[m_RightHalfOfDeviceSchemeIndex];
            }
        }
        public interface IDefaultActions
        {
            void OnNorth(InputAction.CallbackContext context);
            void OnEast(InputAction.CallbackContext context);
            void OnSouth(InputAction.CallbackContext context);
            void OnWest(InputAction.CallbackContext context);
            void OnActivate(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
        }
    }
}
