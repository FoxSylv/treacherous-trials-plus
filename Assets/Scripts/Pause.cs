using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	public Canvas pauseMenu;

	public Canvas hud;

	public EventSystem eventSystem;

	[NonSerialized]
	public bool paused;

	public ButtonGroup buttonGroup;

	public Button continueButton;

	public Button retryButton;

	public Button quitButton;

	private Button selectedButton;

	private KeyManager km;

	private GlobalControls global;

	private AudioSource aud;

	private List<GameObject> disabledElements = new List<GameObject>();

	private void Start()
	{
		global = GetComponent<GlobalControls>();
		km = GetComponent<KeyManager>();
		aud = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (km.pause_pressed)
		{
			togglePause();
		}
		if (paused)
		{
			pauseMenu.gameObject.SetActive(!km.action_held);
			hud.gameObject.SetActive(!km.action_held);
		}
	}

	public void togglePause()
	{
		if (!paused && global.disablePause)
		{
			return;
		}
		paused = !paused;
		pauseMenu.gameObject.SetActive(paused);
		aud.enabled = !paused;
		Time.timeScale = (paused ? 0f : 1f);
		Player player = UnityEngine.Object.FindObjectOfType<Player>();
		if (paused)
		{
			buttonGroup.reset();
			GameObject[] array = GameObject.FindGameObjectsWithTag("HideOnPause");
			foreach (GameObject gameObject in array)
			{
				gameObject.SetActive(false);
				disabledElements.Add(gameObject);
			}
		}
		else
		{
			foreach (GameObject disabledElement in disabledElements)
			{
				disabledElement.SetActive(true);
			}
			disabledElements.Clear();
			hud.gameObject.SetActive(true);
			if (player != null)
			{
				player.unpaused = true;
			}
		}
		GameObject gameObject2 = GameObject.Find("Active MusicPlayer");
		if ((bool)gameObject2)
		{
			gameObject2.GetComponent<MusicPlayer>().SetQuiet(paused, 0f);
		}
	}

	public void retry()
	{
		Player player = UnityEngine.Object.FindObjectOfType<Player>();
		if ((bool)player && player.canRetry())
		{
			player.die();
		}
		else
		{
			togglePause();
		}
	}

	public void toMenu(Button pressed)
	{
		aud.enabled = true;
		GameObject gameObject = GameObject.Find("Active MusicPlayer");
		if ((bool)gameObject)
		{
			gameObject.GetComponent<MusicPlayer>().ClearLayers();
		}
		UnityEngine.Object.FindObjectOfType<SceneTransition>().FadeToScene(pressed.transform, "Title Screen");
	}
}
