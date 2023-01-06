using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Button btn;

		public string levelSceneName;

		public LevelSelect _003C_003E4__this;

		internal void _003CStart_003Eb__0()
		{
			_003C_003E4__this.title.MenuToScene(btn, levelSceneName);
		}
	}

	public TitleScreen title;

	public TextMeshProUGUI levelNameDisplay;

	public Button cancelButton;

	public LevelManager levelList;

	private ButtonGroup group;

	private GameObject levelBox;

	private List<Button> levels = new List<Button>();

	private int gridColumns;

	private void Start()
	{
		group = GetComponent<ButtonGroup>();
		group.buttons.Add(cancelButton);
		levelBox = base.transform.GetChild(0).gameObject;
		gridColumns = GetComponent<GridLayoutGroup>().constraintCount;
		for (int i = 0; i < levelList.levels.Length; i++)
		{
			_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
			_003C_003Ec__DisplayClass8_._003C_003E4__this = this;
			GameObject gameObject = Object.Instantiate(levelBox, base.transform.position, base.transform.rotation);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			_003C_003Ec__DisplayClass8_.btn = gameObject.GetComponent<Button>();
			gameObject.SetActive(true);
			gameObject.name = "Level Box (" + (i + 1) + ")";
			component.SetParent(base.transform);
			component.localScale = new Vector3(1f, 1f, 1f);
			component.anchoredPosition = new Vector3(component.anchoredPosition.x, component.anchoredPosition.y, 0f);
			component.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 11).ToString();
			levels.Add(_003C_003Ec__DisplayClass8_.btn);
			_003C_003Ec__DisplayClass8_.levelSceneName = levelList.levels[i].scene;
			_003C_003Ec__DisplayClass8_.btn.onClick.AddListener(_003C_003Ec__DisplayClass8_._003CStart_003Eb__0);
		}
		Button button = levels[levels.Count - 1];
		for (int j = 0; j < levels.Count; j++)
		{
			int num = rowNumber(j);
			int num2 = j % gridColumns;
			Button button2 = levels[j];
			Navigation navigation = button2.navigation;
			navigation.selectOnLeft = ((j == 0) ? cancelButton : levels[j - 1]);
			navigation.selectOnRight = ((j == levels.Count - 1) ? cancelButton : levels[j + 1]);
			if (j + gridColumns >= levels.Count)
			{
				navigation.selectOnDown = ((num >= rowNumber(levels.Count - 1)) ? cancelButton : button);
			}
			else
			{
				navigation.selectOnDown = levels[j + gridColumns];
			}
			navigation.selectOnUp = ((j < gridColumns) ? cancelButton : levels[j - gridColumns]);
			button2.navigation = navigation;
		}
		Navigation navigation2 = cancelButton.navigation;
		navigation2.selectOnLeft = button;
		navigation2.selectOnUp = button;
		navigation2.selectOnRight = levels[0];
		navigation2.selectOnDown = levels[0];
		cancelButton.navigation = navigation2;
		group.selectedButton = levels[0];
	}

	private int rowNumber(int index)
	{
		return (int)Mathf.Floor(index / gridColumns);
	}

	public void updateSelected()
	{
		int num = -1;
		int num2 = -1;
		foreach (Button level in levels)
		{
			LevelSelectOption component = level.gameObject.GetComponent<LevelSelectOption>();
			if (component.selected)
			{
				num = component.levelNumber - 10;
			}
			if (component.hovered)
			{
				num2 = component.levelNumber - 10;
			}
		}
		if (num2 >= 0)
		{
			levelNameDisplay.text = num2 + 11 + " - " + levelList.levels[num2].name;
		}
		else if (num >= 0)
		{
			levelNameDisplay.text = num + 11 + " - " + levelList.levels[num].name;
		}
		else
		{
			levelNameDisplay.text = "";
		}
	}
}
