using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsLink : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	private TextMeshProUGUI text;

	private Color col;

	[TextArea(2, 10)]
	public string link;

	private void Awake()
	{
		text = GetComponent<TextMeshProUGUI>();
		col = text.color;
	}

	public void OnPointerEnter(PointerEventData data)
	{
		text.color = new Color(1f, 0.5f, 0f, 1f);
	}

	public void OnPointerExit(PointerEventData data)
	{
		text.color = col;
	}

	public void OnPointerClick(PointerEventData data)
	{
		Application.OpenURL(link);
	}
}
