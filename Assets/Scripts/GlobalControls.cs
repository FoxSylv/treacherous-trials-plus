using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControls : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public string sceneName;

		internal bool _003CAwake_003Eb__0(LevelManager.LevelData lvl)
		{
			return lvl.scene != sceneName;
		}
	}

	public bool dashDisabled;

	public bool shiftDisabled;

	public bool playStartCutscene;

	public bool disablePause;

	public CinemachineVirtualCamera vCam;

	public Transform spawnPoint;

	public GameObject player;

	public LevelManager levelList;

	public Canvas uiCanvas;

	public float camZoom;

	private Player activePlayer;

	private TextMeshProUGUI levelName;

	private TextMeshProUGUI speedrunTimer;

	public List<Sprite> iconSprites = new List<Sprite>();

	public List<int> iconIDs = new List<int>();

	[NonSerialized]
	public bool speedrunTimerActive;

	[NonSerialized]
	public int levelNumber;

	[NonSerialized]
	public string nextLevel;

	[NonSerialized]
	public SceneTransition transition;

	[NonSerialized]
	private TileShifter shifter;

	[NonSerialized]
	public Pause pause;

	public TextMeshProUGUI songTime1;

	public TextMeshProUGUI songTime2;

	public TextMeshProUGUI songTime3;

	private float speedrunTime;

	private bool firstSpawn = true;

	private void Awake()
	{
		_003C_003Ec__DisplayClass26_0 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_0();
		UnityEngine.Object[] array = Resources.LoadAll("Icons", typeof(Sprite));
		foreach (UnityEngine.Object @object in array)
		{
			iconSprites.Add((Sprite)@object);
			if (@object.name.EndsWith("a"))
			{
				string text = @object.name.Substring(0, @object.name.Length - 1);
				text = text.Substring(5);
				iconIDs.Add(int.Parse(text));
			}
		}
		array = Resources.LoadAll("Icons/Glow", typeof(Sprite));
		foreach (UnityEngine.Object object2 in array)
		{
			iconSprites.Add((Sprite)object2);
		}
		uiCanvas.gameObject.SetActive(true);
		levelName = uiCanvas.transform.Find("Corner").Find("Level Name").GetComponent<TextMeshProUGUI>();
		speedrunTimer = uiCanvas.transform.Find("Corner").Find("Speedrun Timer").GetComponent<TextMeshProUGUI>();
		_003C_003Ec__DisplayClass26_.sceneName = SceneManager.GetActiveScene().name;
		levelNumber = levelList.levels.TakeWhile(_003C_003Ec__DisplayClass26_._003CAwake_003Eb__0).Count();
		if (levelNumber >= 0 && levelNumber < levelList.levels.Length)
		{
			levelName.text = levelNumber + 11 + " - " + ((levelList.levels[levelNumber].name.Length > 0) ? levelList.levels[levelNumber].name : _003C_003Ec__DisplayClass26_.sceneName);
			if (levelNumber < levelList.levels.Length - 1)
			{
				nextLevel = levelList.levels[levelNumber + 1].scene;
			}
		}
		else
		{
			levelName.text = "* " + _003C_003Ec__DisplayClass26_.sceneName;
		}
		if (nextLevel == null || nextLevel.Length <= 0)
		{
			GameObject[] array2 = GameObject.FindGameObjectsWithTag("Goal");
			foreach (GameObject obj in array2)
			{
				obj.GetComponent<ParticleSystem>().Stop();
				obj.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, 0.5f);
			}
		}
	}

	private void Start()
	{
		Physics2D.IgnoreLayerCollision(0, 6);
		shifter = GetComponent<TileShifter>();
		pause = GetComponent<Pause>();
		camZoom = vCam.m_Lens.OrthographicSize;
		transition = UnityEngine.Object.FindObjectOfType<SceneTransition>();
		spawnPlayer();
		transition.FadeIn();
		GameObject.Find("Active GameManager").GetComponent<GameManager>().lastLevel = levelNumber;
	}

	private void spawnPlayer()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(player, spawnPoint.position, spawnPoint.rotation);
		activePlayer = gameObject.GetComponent<Player>();
		activePlayer.globalControls = this;
		activePlayer.name = "Player";
		if (dashDisabled)
		{
			activePlayer.dashDisabled = true;
		}
		if (shiftDisabled)
		{
			activePlayer.shiftDisabled = true;
		}
		if (playStartCutscene)
		{
			uiCanvas.GetComponent<CanvasGroup>().alpha = 0f;
			vCam.Follow = spawnPoint;
			activePlayer.StartCoroutine(activePlayer.playStartCutscene());
			playStartCutscene = false;
			firstSpawn = false;
			return;
		}
		vCam.Follow = gameObject.transform;
		if (firstSpawn)
		{
			firstSpawn = false;
			activePlayer.gameObject.GetComponent<PlayerAnimation>().setAnimation("idle");
			activePlayer.firstSpawn = true;
			Invoke("onFirstSpawn", 0.333f);
		}
		else
		{
			startSpeedrunTimer();
		}
	}

	public void onFirstSpawn()
	{
		startSpeedrunTimer();
		activePlayer.firstSpawn = false;
	}

	public void startSpeedrunTimer()
	{
		speedrunTime = Time.fixedTime;
		speedrunTimerActive = true;
	}

	public void fadeInHUD()
	{
		uiCanvas.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).SetUpdate(true);
	}

	public void fadeOutHUD()
	{
		uiCanvas.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetUpdate(true);
	}

	private void Update()
	{
		if (speedrunTimerActive)
		{
			speedrunTimer.text = Timestamp(Time.fixedTime - speedrunTime);
		}
	}

	public void zoomCamera(float zoom, float time, Ease ease)
	{
		DOTween.To(_003CzoomCamera_003Eb__34_0, _003CzoomCamera_003Eb__34_1, zoom, time).SetEase(ease);
	}

	public void OnDeath()
	{
		speedrunTimerActive = false;
		if (vCam.Follow != null)
		{
			zoomCamera(camZoom - 0.75f, 0.5f, Ease.OutSine);
		}
		StartCoroutine(respawnPlayer());
		GameObject.Find("Active MusicPlayer").GetComponent<MusicPlayer>().SetIntense();
	}

	private IEnumerator respawnPlayer()
	{
		yield return new WaitForSeconds(0.5f);
		spawnPlayer();
		zoomCamera(camZoom, 0.25f, Ease.InOutSine);
		if (shifter.shifted)
		{
			shifter.switchTiles(true);
		}
		base.gameObject.BroadcastMessage("OnPlayerRespawn", null, SendMessageOptions.DontRequireReceiver);
		TutorialMessage tutorialMessage = UnityEngine.Object.FindObjectOfType<TutorialMessage>();
		if ((bool)tutorialMessage)
		{
			tutorialMessage.OnPlayerRespawn();
		}
		Icon[] array = UnityEngine.Object.FindObjectsOfType<Icon>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].OnPlayerRespawn();
		}
	}

	public void loadNextLevel()
	{
		if (nextLevel != null && nextLevel.Length > 0)
		{
			SceneManager.LoadScene(nextLevel);
		}
	}

	public void loadNextLevelAfter(float time)
	{
		Invoke("loadNextLevel", time);
	}

	public string Timestamp(float secs)
	{
		float num = secs * 1000f;
		int num2 = (int)num / 60000;
		int num3 = (int)num / 1000 - 60 * num2;
		int num4 = (int)num - num2 * 60000 - 1000 * num3;
		return string.Format("{0:00}:{1:00}.<size=-4>{2:000}</size>", num2, num3, num4);
	}

	[CompilerGenerated]
	private float _003CzoomCamera_003Eb__34_0()
	{
		return vCam.m_Lens.OrthographicSize;
	}

	[CompilerGenerated]
	private void _003CzoomCamera_003Eb__34_1(float x)
	{
		vCam.m_Lens.OrthographicSize = x;
	}
}
