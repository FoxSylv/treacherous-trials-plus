using System;
using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public Action callback;

		internal void _003CFadeOut_003Eb__0()
		{
			if (callback != null)
			{
				callback();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public SceneTransition _003C_003E4__this;

		public StandaloneInputModule sm;

		public Action callback;

		internal void _003CActuallyFadeIn_003Eb__0()
		{
			_003C_003E4__this.bgRenderer.enabled = false;
			if ((bool)sm)
			{
				sm.enabled = true;
			}
			if (callback != null)
			{
				callback();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public string sceneName;

		internal void _003CFadeToScene_003Eb__0()
		{
			Time.timeScale = 1f;
			DOTween.KillAll();
			SceneManager.LoadScene(sceneName);
		}
	}

	public AudioClip fadeOut;

	public AudioClip fadeIn;

	public AudioSource fadeSound;

	private Transform mask;

	private SpriteRenderer bgRenderer;

	public float duration = 0.66f;

	public float scale = 1f;

	private void Awake()
	{
		bgRenderer = GetComponent<SpriteRenderer>();
		mask = base.transform.GetChild(0);
	}

	public void FadeOut(Action callback = null, bool sound = true)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.callback = callback;
		if (!isFirstLoad())
		{
			if (sound && (bool)fadeSound && (bool)fadeOut)
			{
				fadeSound.PlayOneShot(fadeOut, 0.5f);
			}
			bgRenderer.enabled = true;
			mask.localScale = new Vector2(scale, scale);
			mask.DOScale(new Vector2(0f, 0f), duration).SetEase(Ease.OutCubic).SetUpdate(true)
				.OnComplete(_003C_003Ec__DisplayClass8_._003CFadeOut_003Eb__0);
		}
	}

	public void FadeIn(Action callback = null, bool sound = true)
	{
		if (!isFirstLoad())
		{
			bgRenderer.enabled = true;
			mask.localScale = new Vector2(0f, 0f);
			StartCoroutine(ActuallyFadeIn(callback, sound));
		}
	}

	private IEnumerator ActuallyFadeIn(Action callback = null, bool sound = true)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_0();
		_003C_003Ec__DisplayClass10_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass10_.callback = callback;
		_003C_003Ec__DisplayClass10_.sm = UnityEngine.Object.FindObjectOfType<StandaloneInputModule>();
		if ((bool)_003C_003Ec__DisplayClass10_.sm)
		{
			_003C_003Ec__DisplayClass10_.sm.enabled = false;
		}
		yield return new WaitForSeconds(0.2f);
		if (sound && (bool)fadeSound && (bool)fadeIn)
		{
			fadeSound.PlayOneShot(fadeIn, 0.5f);
		}
		mask.DOScale(new Vector2(scale, scale), duration).SetEase(Ease.InCubic).SetUpdate(true)
			.OnComplete(_003C_003Ec__DisplayClass10_._003CActuallyFadeIn_003Eb__0);
	}

	public void FadeToScene(Transform btn, string sceneName)
	{
		_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_0();
		_003C_003Ec__DisplayClass11_.sceneName = sceneName;
		EventSystem eventSystem = UnityEngine.Object.FindObjectOfType<EventSystem>();
		if ((bool)eventSystem)
		{
			eventSystem.enabled = false;
		}
		if ((bool)btn)
		{
			Vector2 vector = btn.position;
			vector.y -= 0.31f;
			mask.position = vector;
		}
		FadeOut(_003C_003Ec__DisplayClass11_._003CFadeToScene_003Eb__0);
	}

	private bool isFirstLoad()
	{
		GameObject.Find("Active GameManager");
		GameManager component = GameObject.Find("Active GameManager").GetComponent<GameManager>();
		if (component.firstLoad)
		{
			component.firstLoad = false;
			return true;
		}
		return false;
	}
}
