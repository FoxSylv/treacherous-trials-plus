using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct GameplayActions
	{
		private Controls m_Wrapper;

		public InputAction Move
		{
			get
			{
				return m_Wrapper.m_Gameplay_Move;
			}
		}

		public InputAction GamepadMove
		{
			get
			{
				return m_Wrapper.m_Gameplay_GamepadMove;
			}
		}

		public InputAction Jump
		{
			get
			{
				return m_Wrapper.m_Gameplay_Jump;
			}
		}

		public InputAction Down
		{
			get
			{
				return m_Wrapper.m_Gameplay_Down;
			}
		}

		public InputAction Action
		{
			get
			{
				return m_Wrapper.m_Gameplay_Action;
			}
		}

		public InputAction Pause
		{
			get
			{
				return m_Wrapper.m_Gameplay_Pause;
			}
		}

		public InputAction Back
		{
			get
			{
				return m_Wrapper.m_Gameplay_Back;
			}
		}

		public InputAction Restart
		{
			get
			{
				return m_Wrapper.m_Gameplay_Restart;
			}
		}

		public InputAction Mute
		{
			get
			{
				return m_Wrapper.m_Gameplay_Mute;
			}
		}

		public InputAction Fullscreen
		{
			get
			{
				return m_Wrapper.m_Gameplay_Fullscreen;
			}
		}

		public bool enabled
		{
			get
			{
				return Get().enabled;
			}
		}

		public GameplayActions(Controls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Gameplay;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(GameplayActions set)
		{
			return set.Get();
		}

		public void SetCallbacks(IGameplayActions instance)
		{
			if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
			{
				Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
				Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
				Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
				GamepadMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGamepadMove;
				GamepadMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGamepadMove;
				GamepadMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGamepadMove;
				Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
				Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
				Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
				Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
				Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
				Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
				Action.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
				Action.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
				Action.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
				Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
				Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
				Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
				Back.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
				Back.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
				Back.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBack;
				Restart.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
				Restart.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
				Restart.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRestart;
				Mute.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMute;
				Mute.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMute;
				Mute.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMute;
				Fullscreen.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFullscreen;
				Fullscreen.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFullscreen;
				Fullscreen.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFullscreen;
			}
			m_Wrapper.m_GameplayActionsCallbackInterface = instance;
			if (instance != null)
			{
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				GamepadMove.started += instance.OnGamepadMove;
				GamepadMove.performed += instance.OnGamepadMove;
				GamepadMove.canceled += instance.OnGamepadMove;
				Jump.started += instance.OnJump;
				Jump.performed += instance.OnJump;
				Jump.canceled += instance.OnJump;
				Down.started += instance.OnDown;
				Down.performed += instance.OnDown;
				Down.canceled += instance.OnDown;
				Action.started += instance.OnAction;
				Action.performed += instance.OnAction;
				Action.canceled += instance.OnAction;
				Pause.started += instance.OnPause;
				Pause.performed += instance.OnPause;
				Pause.canceled += instance.OnPause;
				Back.started += instance.OnBack;
				Back.performed += instance.OnBack;
				Back.canceled += instance.OnBack;
				Restart.started += instance.OnRestart;
				Restart.performed += instance.OnRestart;
				Restart.canceled += instance.OnRestart;
				Mute.started += instance.OnMute;
				Mute.performed += instance.OnMute;
				Mute.canceled += instance.OnMute;
				Fullscreen.started += instance.OnFullscreen;
				Fullscreen.performed += instance.OnFullscreen;
				Fullscreen.canceled += instance.OnFullscreen;
			}
		}
	}

	public interface IGameplayActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnGamepadMove(InputAction.CallbackContext context);

		void OnJump(InputAction.CallbackContext context);

		void OnDown(InputAction.CallbackContext context);

		void OnAction(InputAction.CallbackContext context);

		void OnPause(InputAction.CallbackContext context);

		void OnBack(InputAction.CallbackContext context);

		void OnRestart(InputAction.CallbackContext context);

		void OnMute(InputAction.CallbackContext context);

		void OnFullscreen(InputAction.CallbackContext context);
	}

	[CompilerGenerated]
	private readonly InputActionAsset _003Casset_003Ek__BackingField;

	private readonly InputActionMap m_Gameplay;

	private IGameplayActions m_GameplayActionsCallbackInterface;

	private readonly InputAction m_Gameplay_Move;

	private readonly InputAction m_Gameplay_GamepadMove;

	private readonly InputAction m_Gameplay_Jump;

	private readonly InputAction m_Gameplay_Down;

	private readonly InputAction m_Gameplay_Action;

	private readonly InputAction m_Gameplay_Pause;

	private readonly InputAction m_Gameplay_Back;

	private readonly InputAction m_Gameplay_Restart;

	private readonly InputAction m_Gameplay_Mute;

	private readonly InputAction m_Gameplay_Fullscreen;

	private int m_GamepadSchemeIndex = -1;

	private int m_KeyboardMouseSchemeIndex = -1;

	public InputActionAsset asset
	{
		[CompilerGenerated]
		get
		{
			return _003Casset_003Ek__BackingField;
		}
	}

	public InputBinding? bindingMask
	{
		get
		{
			return asset.bindingMask;
		}
		set
		{
			asset.bindingMask = value;
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return asset.devices;
		}
		set
		{
			asset.devices = value;
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes
	{
		get
		{
			return asset.controlSchemes;
		}
	}

	public IEnumerable<InputBinding> bindings
	{
		get
		{
			return asset.bindings;
		}
	}

	public GameplayActions Gameplay
	{
		get
		{
			return new GameplayActions(this);
		}
	}

	public InputControlScheme GamepadScheme
	{
		get
		{
			if (m_GamepadSchemeIndex == -1)
			{
				m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
			}
			return asset.controlSchemes[m_GamepadSchemeIndex];
		}
	}

	public InputControlScheme KeyboardMouseScheme
	{
		get
		{
			if (m_KeyboardMouseSchemeIndex == -1)
			{
				m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
			}
			return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
		}
	}

	public Controls()
	{
		_003Casset_003Ek__BackingField = InputActionAsset.FromJson("{\n    \"name\": \"Controls\",\n    \"maps\": [\n        {\n            \"name\": \"Gameplay\",\n            \"id\": \"273f247e-7ede-4607-9179-565ba36b2eeb\",\n            \"actions\": [\n                {\n                    \"name\": \"Move\",\n                    \"type\": \"Value\",\n                    \"id\": \"a6d9108d-0c4f-4263-b8fd-0b1d0a1e7e36\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"GamepadMove\",\n                    \"type\": \"Value\",\n                    \"id\": \"28eedbc5-926c-4b91-96b5-aaf195d24dd9\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Jump\",\n                    \"type\": \"Button\",\n                    \"id\": \"8ca82146-06d5-432f-b24e-18b8860d74c3\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Down\",\n                    \"type\": \"Button\",\n                    \"id\": \"5ca0cb71-e4d6-4b65-8499-2c6c967bea1c\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Action\",\n                    \"type\": \"Button\",\n                    \"id\": \"b7154308-706a-4795-b10c-ad0a40f1c440\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Pause\",\n                    \"type\": \"Button\",\n                    \"id\": \"4a5252b3-f9e6-45ff-9e4e-269a980f8dd8\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Back\",\n                    \"type\": \"Button\",\n                    \"id\": \"566cbbcc-501b-4d4d-b3a6-a62e4e97e515\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Restart\",\n                    \"type\": \"Button\",\n                    \"id\": \"59c6200d-3105-4a1b-b39b-6a6dfa5d3f88\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Mute\",\n                    \"type\": \"Button\",\n                    \"id\": \"52ade34f-7e54-49d4-b5c9-35b1099b78e9\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Fullscreen\",\n                    \"type\": \"Button\",\n                    \"id\": \"32b94f89-1ca6-4a46-9be6-67e0b4092b3f\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"WASD\",\n                    \"id\": \"93633e04-515c-4d1d-8e52-8e119735815f\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Move\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"c6badcc4-7422-40be-8725-53dcd2bef7f7\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"baa6cdfd-4dec-4faa-b882-dcfcbef3321e\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"IJKL\",\n                    \"id\": \"c49527ec-bfc5-4be0-bfd5-9814d7f4dcb2\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Move\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"9b7196ef-63cf-4f1f-9083-84ff87ef50ee\",\n                    \"path\": \"<Keyboard>/j\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"e3648b70-8f82-487f-83c6-16a78af26509\",\n                    \"path\": \"<Keyboard>/l\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"Arrows\",\n                    \"id\": \"c731f792-00d7-4aff-bbb9-4e14fdb0b460\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Move\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"9b961ecf-5289-4e9b-813c-d4360db2501f\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"19169136-2756-4278-90f9-2687d1046955\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c603c58c-f370-4351-ab3d-7f98e07efa51\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3db9a7fd-99e7-45f5-b658-007ac44362c7\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c2721f0b-82a8-4978-8dd4-9670e88134e5\",\n                    \"path\": \"<Keyboard>/space\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1232d291-6a6d-4f88-9bd2-7b92b50d307a\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6782a66a-f05b-4f17-8ae5-03ccb389b506\",\n                    \"path\": \"<Keyboard>/i\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3fafc087-c68e-4038-970a-324b272dd47b\",\n                    \"path\": \"<Keyboard>/upArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"13fada76-187d-43aa-8ca0-4fe53439bfb0\",\n                    \"path\": \"<Gamepad>/buttonNorth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"58a59992-19c5-454b-b756-3911e2db1f40\",\n                    \"path\": \"<Gamepad>/buttonWest\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b289667f-29a4-4317-9c9b-627e7b43bd6b\",\n                    \"path\": \"<Keyboard>/z\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4e5afa9b-1cca-4c67-a418-7aae6cbb5b37\",\n                    \"path\": \"<Keyboard>/x\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"5e37f681-9957-42df-9ff1-02caa65b5299\",\n                    \"path\": \"<Keyboard>/shift\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"8adb20b4-1f1e-45b5-808e-c0fdd27a24af\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"cee5c330-8327-4271-ae93-da2245ccd2b1\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a6c08482-c63e-4dc9-94c6-6c6cb677b9e7\",\n                    \"path\": \"<Gamepad>/start\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Pause\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b2ed834a-340b-483e-a8f5-0ca0614c0459\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Pause\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"cc4d510c-14b3-4e34-9134-42f4845a4bc9\",\n                    \"path\": \"<Keyboard>/tab\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Pause\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"cd9ca2b7-c442-47f3-b631-ca4d3a9ba919\",\n                    \"path\": \"<Keyboard>/p\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Pause\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4e005a6e-3ad0-4736-8c5a-163e67fb037e\",\n                    \"path\": \"<Gamepad>/start\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Back\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0ec132ea-1670-4c92-8382-d8d304540cc3\",\n                    \"path\": \"<XboxOneGampadiOS>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Back\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"2446cdf3-3493-4874-b042-028b3558470f\",\n                    \"path\": \"<XInputController>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Back\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"649cd36a-ae38-4533-8dcc-297a03daeedb\",\n                    \"path\": \"<SwitchProControllerHID>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Back\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6b6de850-df53-45bb-af41-18210dc56028\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Back\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"23872a93-c54a-48e8-a23d-c67cec3063a6\",\n                    \"path\": \"<Gamepad>/select\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Restart\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e360bd2f-a65e-473a-94c3-de9d119e19f7\",\n                    \"path\": \"<Keyboard>/r\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Restart\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e9768b15-3484-46ea-b801-614d2bda9029\",\n                    \"path\": \"<Gamepad>/leftStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"GamepadMove\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"8eb7923c-9e50-44cc-af55-4c501af621ea\",\n                    \"path\": \"<Gamepad>/dpad\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"GamepadMove\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e8446a7e-3e4f-4346-b59b-967d625f5f37\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Down\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b6019d06-97f1-4e5a-b141-5b4cf03fe9ee\",\n                    \"path\": \"<Keyboard>/k\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Down\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a458a3f3-8384-400f-8ce0-0f076a34f2e3\",\n                    \"path\": \"<Keyboard>/downArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Down\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"44e4ad4c-ec0b-41ab-9dc2-856c3634a0ca\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Down\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7bbb95d6-4198-4128-924a-496f3513be73\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Down\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7ceed83d-17e0-43bd-9bf8-0c239c267e32\",\n                    \"path\": \"<Keyboard>/m\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Mute\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"05d38ec9-2aff-47b4-988d-27e581998886\",\n                    \"path\": \"<Keyboard>/f4\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Fullscreen\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"Gamepad\",\n            \"bindingGroup\": \"Gamepad\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Gamepad>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"KeyboardMouse\",\n            \"bindingGroup\": \"KeyboardMouse\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Keyboard>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                },\n                {\n                    \"devicePath\": \"<Mouse>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                }\n            ]\n        }\n    ]\n}");
		m_Gameplay = asset.FindActionMap("Gameplay", true);
		m_Gameplay_Move = m_Gameplay.FindAction("Move", true);
		m_Gameplay_GamepadMove = m_Gameplay.FindAction("GamepadMove", true);
		m_Gameplay_Jump = m_Gameplay.FindAction("Jump", true);
		m_Gameplay_Down = m_Gameplay.FindAction("Down", true);
		m_Gameplay_Action = m_Gameplay.FindAction("Action", true);
		m_Gameplay_Pause = m_Gameplay.FindAction("Pause", true);
		m_Gameplay_Back = m_Gameplay.FindAction("Back", true);
		m_Gameplay_Restart = m_Gameplay.FindAction("Restart", true);
		m_Gameplay_Mute = m_Gameplay.FindAction("Mute", true);
		m_Gameplay_Fullscreen = m_Gameplay.FindAction("Fullscreen", true);
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(asset);
	}

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

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return asset.FindAction(actionNameOrId, throwIfNotFound);
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		return asset.FindBinding(bindingMask, out action);
	}
}
