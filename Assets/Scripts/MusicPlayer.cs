using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public AudioSource aud;

		public MusicPlayer _003C_003E4__this;

		internal void _003CFadeToStop_003Eb__0()
		{
			aud.Stop();
			aud.volume = _003C_003E4__this.volume;
		}
	}

	private List<int> iconIDs = new List<int>();

	public float mainVolume = 0.666f;

	public float webVolume = 0.7f;

	public float quietVolume = 0.25f;

	private bool muted;

	private float volume;

	private string activeName = "Active MusicPlayer";

	public static MusicPlayer instance;

	private void Awake()
	{
		if ((bool)GameObject.Find(activeName))
		{
			Object.Destroy(base.gameObject);
			return;
		}
		base.gameObject.name = activeName;
		base.transform.parent = null;
		Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
		volume = mainVolume;
	}

	private void Start()
	{
		PlayMain();
	}

	public void SetPiano(bool dark = false, float time = 0.5f)
	{
		AudioSource piano = getPiano();
		FadeToVolume(piano, dark ? volume : 0f, time);
		if (dark)
		{
			StartCoroutine(DesyncFix());
		}
	}

	public void SetIntense(bool hype = false, float time = 0.5f)
	{
		AudioSource intense = getIntense();
		FadeToVolume(intense, hype ? volume : 0f, time);
		if (hype)
		{
			StartCoroutine(DesyncFix());
		}
	}

	public void SetQuiet(bool quiet = false, float time = 0.33f)
	{
		AudioSource[] all = getAll();
		foreach (AudioSource audioSource in all)
		{
			if (audioSource.volume > 0f)
			{
				FadeToVolume(audioSource, quiet ? quietVolume : volume, time);
			}
		}
	}

	public void FadeToVolume(AudioSource sauce, float volume, float time)
	{
		if (time <= 0f)
		{
			sauce.volume = volume;
			return;
		}
		DOTween.Kill("aud_" + sauce.name);
		sauce.DOFade(volume, time).SetId("aud_" + sauce.name).SetUpdate(true);
	}

	public void FadeToStop(float time)
	{
		AudioSource[] all = getAll();
		for (int i = 0; i < all.Length; i++)
		{
			_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_0();
			_003C_003Ec__DisplayClass14_._003C_003E4__this = this;
			_003C_003Ec__DisplayClass14_.aud = all[i];
			DOTween.Kill("aud_" + _003C_003Ec__DisplayClass14_.aud.name);
			_003C_003Ec__DisplayClass14_.aud.DOFade(0f, time).SetId("aud_" + _003C_003Ec__DisplayClass14_.aud.name).SetUpdate(true)
				.OnComplete(_003C_003Ec__DisplayClass14_._003CFadeToStop_003Eb__0);
		}
	}

	public void ClearLayers(float time = 0f)
	{
		SetPiano(false, time);
		SetIntense(false, time);
	}

	public void Stop()
	{
		AudioSource[] all = getAll();
		foreach (AudioSource obj in all)
		{
			obj.time = 0f;
			obj.Stop();
		}
	}

	public void Play()
	{
		AudioSource[] all = getAll();
		for (int i = 0; i < all.Length; i++)
		{
			all[i].Play();
		}
	}

	private IEnumerator DesyncFix()
	{
		float tempTime = getMusic().time;
		if (false)
		{
			yield return new WaitForSeconds(0.0125f);
		}
		AudioSource[] all = getAll();
		foreach (AudioSource obj in all)
		{
			obj.mute = muted;
			obj.time = tempTime;
		}
	}

	public void PlayMain()
	{
		if (!getMusic().isPlaying)
		{
			Play();
		}
		ClearLayers();
	}

	public void ResetAll()
	{
		AudioSource[] all = getAll();
		for (int i = 0; i < all.Length; i++)
		{
			all[i].time = 0f;
		}
	}

	public void ToggleMute()
	{
		muted = !muted;
		AudioSource[] all = getAll();
		for (int i = 0; i < all.Length; i++)
		{
			all[i].mute = muted;
		}
		StartCoroutine(DesyncFix());
	}

	public AudioSource getMusic()
	{
		return GetComponent<AudioSource>();
	}

	public AudioSource getPiano()
	{
		return base.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
	}

	public AudioSource getIntense()
	{
		return base.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
	}

	public AudioSource[] getAll()
	{
		return new AudioSource[3]
		{
			getMusic(),
			getPiano(),
			getIntense()
		};
	}
}
