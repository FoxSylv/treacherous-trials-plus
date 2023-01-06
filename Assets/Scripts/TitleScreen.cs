using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
	public Canvas canvas;

	public EventSystem eventSystem;

	public SceneTransition transition;

	public Transform diamond;

	public LevelManager levelList;

	private KeyManager km;

    private TextMeshProUGUI plusText;

	private void Start()
	{
		km = GetComponent<KeyManager>();
		base.transform.position = new Vector3(0f, 0f, -99f);
		transition.FadeIn();
		GameObject gameObject = GameObject.Find("Start Message");
		if ((bool)gameObject && getLastLevel() > 0)
		{
			gameObject.GetComponent<TextMeshProUGUI>().text = "Continue (" + (getLastLevel() + 11) + ")";
		}
		GameObject gameObject2 = GameObject.Find("Active MusicPlayer");
		if ((bool)gameObject2)
		{
			gameObject2.GetComponent<MusicPlayer>().SetQuiet();
			gameObject2.GetComponent<MusicPlayer>().PlayMain();
		}

        GameObject gameObject3 = GameObject.Find("Mod Message");
        if ((bool)gameObject3) {
            plusText = gameObject3.GetComponent<TextMeshProUGUI>();
        }
	}

	public void MenuToScene(Button pressed, string sceneName)
	{
		transition.FadeToScene(pressed ? pressed.transform : null, sceneName);
	}

	public void StartGame(Button pressed = null)
	{
		MenuToScene(pressed, levelList.levels[getLastLevel()].scene);
	}

	public void BackToTitle(Button pressed = null)
	{
		MenuToScene(pressed, "Title Screen");
	}

	public void ToLevelSelect(Button pressed = null)
	{
		MenuToScene(pressed, "Level Select");
	}

	public void ToCredits(Button pressed = null)
	{
		MenuToScene(pressed, "Credits");
	}

	public void BackToTitleNoButton()
	{
		MenuToScene(null, "Title Screen");
	}

	public void QuitButton(Button pressed)
	{
		Application.Quit();
	}

	private void Update()
	{
        if (SceneManager.GetActiveScene().name == "Title Screen") {
            plusText.fontSize = 25 + 5 * Mathf.PingPong(Time.time, 1.0f);
        }

		if (km.back_pressed && SceneManager.GetActiveScene().name != "Title Screen")
		{
			BackToTitle();
		}
	}

	private int getLastLevel()
	{
		return GameObject.Find("Active GameManager").GetComponent<GameManager>().lastLevel;
	}
}
