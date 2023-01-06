using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
	public struct ShittyInputSystem
	{
		public bool held;

		public bool down;

		public bool up;

		public ShittyInputSystem(bool idk)
		{
			held = false;
			down = false;
			up = false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public string type;

		internal bool _003CcheckPressed_003Eb__0(string k)
		{
			if (!(type == "down"))
			{
				if (!(type == "up"))
				{
					return Input.GetKey(k);
				}
				return Input.GetKeyUp(k);
			}
			return Input.GetKeyDown(k);
		}
	}

	protected Controls controls;

	private float minJoystickAmount = 0.25f;

	[NonSerialized]
	public string[] RIGHT_KEYS = new string[3] { "right", "d", "l" };

	[NonSerialized]
	public string[] LEFT_KEYS = new string[3] { "left", "a", "j" };

	[NonSerialized]
	public string[] DOWN_KEYS = new string[3] { "down", "s", "k" };

	[NonSerialized]
	public string[] JUMP_KEYS = new string[4] { "up", "w", "i", "space" };

	[NonSerialized]
	public string[] ACTION_KEYS = new string[4] { "z", "x", "left shift", "right shift" };

	[NonSerialized]
	public string[] PAUSE_KEYS = new string[3] { "escape", "tab", "p" };

	[NonSerialized]
	public string[] BACK_KEYS = new string[2] { "escape", "backspace" };

	[NonSerialized]
	public string[] RESTART_KEYS = new string[1] { "r" };

	[NonSerialized]
	public ShittyInputSystem key_jump;

	[NonSerialized]
	public ShittyInputSystem key_left;

	[NonSerialized]
	public ShittyInputSystem key_right;

	[NonSerialized]
	public ShittyInputSystem key_down;

	[NonSerialized]
	public bool action_pressed;

	[NonSerialized]
	public bool action_held;

	[NonSerialized]
	public bool pause_pressed;

	[NonSerialized]
	public bool restart_pressed;

	[NonSerialized]
	public bool back_pressed;

	[NonSerialized]
	public bool mute_pressed;

	[NonSerialized]
	public bool fullscreen_pressed;

	private void Awake()
	{
		controls = new Controls();
	}

	private void OnEnable()
	{
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Disable();
	}

	public bool checkPressed(string[] keys, string type = "")
	{
		_003C_003Ec__DisplayClass25_0 _003C_003Ec__DisplayClass25_ = new _003C_003Ec__DisplayClass25_0();
		_003C_003Ec__DisplayClass25_.type = type;
		return Array.Find(keys, _003C_003Ec__DisplayClass25_._003CcheckPressed_003Eb__0) != null;
	}

	private void Update()
	{
		action_pressed = controls.Gameplay.Action.triggered;
		pause_pressed = controls.Gameplay.Pause.triggered;
		restart_pressed = controls.Gameplay.Restart.triggered;
		back_pressed = controls.Gameplay.Back.triggered;
		mute_pressed = controls.Gameplay.Mute.triggered;
		fullscreen_pressed = controls.Gameplay.Fullscreen.triggered;
		action_held = controls.Gameplay.Action.ReadValue<float>() > minJoystickAmount;
		bool held = key_left.held;
		bool held2 = key_right.held;
		bool held3 = key_jump.held;
		bool held4 = key_down.held;
		Vector2 vector = controls.Gameplay.Move.ReadValue<Vector2>();
		Vector2 vector2 = controls.Gameplay.GamepadMove.ReadValue<Vector2>();
		if (vector2.x != 0f || vector2.y != 0f)
		{
			vector = vector2;
		}
		vector.y = 0f;
		key_left.held = vector.x < minJoystickAmount * -1f;
		key_left.down = key_left.held && !held;
		key_left.up = !key_left.held && held;
		key_right.held = vector.x > minJoystickAmount;
		key_right.down = key_right.held && !held2;
		key_right.up = !key_right.held && held2;
		bool flag = controls.Gameplay.Down.ReadValue<float>() > minJoystickAmount;
		key_down.held = flag;
		key_down.down = flag && !held4;
		key_down.up = !flag && held4;
		bool flag2 = controls.Gameplay.Jump.ReadValue<float>() > minJoystickAmount;
		key_jump.held = flag2;
		key_jump.down = flag2 && !held3;
		key_jump.up = !flag2 && held3;
		if (fullscreen_pressed)
		{
			if (Screen.fullScreenMode == FullScreenMode.Windowed)
			{
				Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
			}
			else
			{
				Screen.fullScreenMode = FullScreenMode.Windowed;
			}
		}
		if (mute_pressed)
		{
			GameObject.Find("Active MusicPlayer").GetComponent<MusicPlayer>().ToggleMute();
		}
	}
}
