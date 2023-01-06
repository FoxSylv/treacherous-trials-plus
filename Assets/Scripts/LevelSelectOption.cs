using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectOption : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
	public LevelSelect parent;

	[NonSerialized]
	public int levelNumber;

	[NonSerialized]
	public bool selected;

	[NonSerialized]
	public bool hovered;

	private void Start()
	{
		levelNumber = int.Parse(base.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text) - 1;
	}

	public void OnSelect(BaseEventData eventData)
	{
		selected = true;
		parent.updateSelected();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
		parent.updateSelected();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		hovered = true;
		parent.updateSelected();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hovered = false;
		parent.updateSelected();
	}
}
