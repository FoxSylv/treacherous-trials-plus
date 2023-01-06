using System.Runtime.CompilerServices;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
	[TextArea(3, 10)]
	public string message;

	public bool enableDash;

	public bool enableShift;

	public GameObject[] enableOnAppear;

	private bool firstTriggered;

	private bool triggered;

	private RectTransform tutorialTextbox;

	private TextMeshProUGUI messageText;

	private void Start()
	{
		tutorialTextbox = GameObject.Find("Tutorial Textbox").GetComponent<RectTransform>();
		tutorialTextbox.parent.gameObject.SetActive(true);
		messageText = GameObject.Find("Tutorial Message").GetComponent<TextMeshProUGUI>();
		messageText.text = "";
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (!(col.gameObject.tag == "Player"))
		{
			return;
		}
		if (!triggered)
		{
			Player component = col.gameObject.GetComponent<Player>();
			if (enableDash)
			{
				component.dashDisabled = false;
				component.globalControls.dashDisabled = false;
			}
			if (enableShift)
			{
				component.shiftDisabled = false;
				component.globalControls.shiftDisabled = false;
			}
		}
		if (!firstTriggered && enableOnAppear.Length != 0)
		{
			GameObject[] array = enableOnAppear;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(true);
			}
		}
		if ((bool)tutorialTextbox)
		{
			if (message.Length > 0 && messageText.text.Length == 0)
			{
				ShowMessage();
			}
			else if (message.Length == 0 && messageText.text.Length > 0)
			{
				HideMessage();
			}
			triggered = true;
			firstTriggered = true;
		}
	}

	private void ShowMessage()
	{
		messageText.text = message;
		tutorialTextbox.DOAnchorPosY(tutorialTextbox.rect.height + 33f, 0.5f).SetEase(Ease.OutCubic);
	}

	private void HideMessage()
	{
		tutorialTextbox.DOAnchorPosY(-20f, 0.5f).SetEase(Ease.InCubic).OnComplete(_003CHideMessage_003Eb__11_0);
	}

	public void OnPlayerRespawn()
	{
		triggered = false;
		HideMessage();
	}

	[CompilerGenerated]
	private void _003CHideMessage_003Eb__11_0()
	{
		messageText.text = "";
	}
}
