using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Button b;

		public ButtonGroup _003C_003E4__this;

		internal void _003CStart_003Eb__1(BaseEventData data)
		{
			_003C_003E4__this.tickSound();
			b.Select();
		}
	}

	public List<Button> buttons = new List<Button>();

	public Button selectedButton;

	public AudioClip tick;

	public bool manual;

	private bool ignoreNextClick;

	private EventSystem eventSystem;

	private void Start()
	{
		eventSystem = Object.FindObjectOfType<EventSystem>();
		if (!manual)
		{
			buttons.AddRange(new List<Button>(base.transform.GetComponentsInChildren<Button>()));
		}
		using (List<Button>.Enumerator enumerator = buttons.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_0();
				_003C_003Ec__DisplayClass6_._003C_003E4__this = this;
				_003C_003Ec__DisplayClass6_.b = enumerator.Current;
				EventTrigger eventTrigger = _003C_003Ec__DisplayClass6_.b.gameObject.AddComponent<EventTrigger>();
				EventTrigger.Entry entry = new EventTrigger.Entry();
				entry.eventID = EventTriggerType.Select;
				entry.callback.AddListener(_003CStart_003Eb__6_0);
				eventTrigger.triggers.Add(entry);
				EventTrigger.Entry entry2 = new EventTrigger.Entry();
				entry2.eventID = EventTriggerType.PointerEnter;
				entry2.callback.AddListener(_003C_003Ec__DisplayClass6_._003CStart_003Eb__1);
				eventTrigger.triggers.Add(entry2);
			}
		}
	}

	private void Update()
	{
		if (buttons == null)
		{
			return;
		}
		bool flag = false;
		foreach (Button button in buttons)
		{
			button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = button.targetGraphic.canvasRenderer.GetColor();
			if (button.gameObject == eventSystem.currentSelectedGameObject)
			{
				flag = true;
				selectedButton = button;
			}
		}
		if (!flag)
		{
			if (selectedButton != null)
			{
				silentSelect(selectedButton);
			}
			else
			{
				reset();
			}
		}
	}

	public void reset()
	{
		if (buttons != null && buttons.Count != 0)
		{
			selectedButton = buttons[0];
			silentSelect(selectedButton);
		}
	}

	public void silentSelect(Button button)
	{
		if (!(eventSystem != null) || !(eventSystem.currentSelectedGameObject == button.gameObject))
		{
			ignoreNextClick = true;
			button.Select();
		}
	}

	public void tickSound()
	{
		if (ignoreNextClick)
		{
			ignoreNextClick = false;
		}
		else
		{
			Camera.main.GetComponent<AudioSource>().PlayOneShot(tick);
		}
	}

	[CompilerGenerated]
	private void _003CStart_003Eb__6_0(BaseEventData data)
	{
		tickSound();
	}
}
