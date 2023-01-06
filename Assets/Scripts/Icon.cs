using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class Icon : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public string iconStr;

		internal bool _003CsetSprite_003Eb__0(Sprite x)
		{
			return x.name == iconStr + "a";
		}

		internal bool _003CsetSprite_003Eb__1(Sprite x)
		{
			return x.name == iconStr + "b";
		}

		internal bool _003CsetSprite_003Eb__2(Sprite x)
		{
			return x.name == iconStr + "c";
		}

		internal bool _003CsetSprite_003Eb__3(Sprite x)
		{
			return x.name == iconStr + "g";
		}
	}

	private int iconID;

	private GlobalControls global;

	private TileShifter shifter;

	public float floatHeight;

	public float floatDuration;

	private bool floating;

	public GameObject deathParticles;

	public GameObject respawnParticles;

	public AudioClip deathSound;

	public AudioClip respawnSound;

	public float respawnTime;

	public Color[] allowedColors;

	public bool useCustomSprite;

	public bool useCustomColors;

	public bool alwaysGlow;

	public GameObject jetpack;

	public SpriteRenderer primaryLayer;

	public SpriteRenderer secondaryLayer;

	public SpriteRenderer whiteLayer;

	public SpriteRenderer glowLayer;

	public SpriteRenderer jetpackPrimary;

	public SpriteRenderer jetpackSecondary;

	public SpriteRenderer jetpackGlow;

	private AudioSource aud;

	private BoxCollider2D col;

	private Vector3 startPos;

	private Sequence sequence;

	private float lastSpawn;

	private void Start()
	{
		floating = floatHeight != 0f && floatDuration > 0f;
		jetpack.SetActive(floating);
		global = Object.FindObjectOfType<GlobalControls>();
		shifter = global.gameObject.GetComponent<TileShifter>();
		col = GetComponent<BoxCollider2D>();
		aud = global.gameObject.GetComponent<AudioSource>();
		startPos = base.transform.position;
		setSprite();
		smoothSpawn();
		if (floating)
		{
			sequence = DOTween.Sequence().Append(base.transform.DOMoveY(startPos.y + floatHeight, floatDuration).SetEase(Ease.InOutSine)).AppendInterval(0.1f)
				.Append(base.transform.DOMoveY(startPos.y, floatDuration).SetEase(Ease.InOutSine))
				.AppendInterval(0.1f)
				.SetLoops(-1, LoopType.Restart)
				.Pause();
		}
	}

	private void setSprite()
	{
		if (!useCustomSprite)
		{
			_003C_003Ec__DisplayClass29_0 _003C_003Ec__DisplayClass29_ = new _003C_003Ec__DisplayClass29_0();
			iconID = global.iconIDs[Random.Range(0, global.iconIDs.Count - 1)];
			_003C_003Ec__DisplayClass29_.iconStr = "icon_" + iconID;
			primaryLayer.sprite = global.iconSprites.Find(_003C_003Ec__DisplayClass29_._003CsetSprite_003Eb__0);
			secondaryLayer.sprite = global.iconSprites.Find(_003C_003Ec__DisplayClass29_._003CsetSprite_003Eb__1);
			whiteLayer.sprite = global.iconSprites.Find(_003C_003Ec__DisplayClass29_._003CsetSprite_003Eb__2);
			glowLayer.sprite = global.iconSprites.Find(_003C_003Ec__DisplayClass29_._003CsetSprite_003Eb__3);
		}
		if (!useCustomColors)
		{
			primaryLayer.color = allowedColors[Random.Range(0, allowedColors.Length - 1)];
			do
			{
				secondaryLayer.color = allowedColors[Random.Range(0, allowedColors.Length - 1)];
			}
			while (primaryLayer.color == secondaryLayer.color || secondaryLayer.color == Color.black);
			glowLayer.color = secondaryLayer.color;
		}
		if (floating)
		{
			jetpackPrimary.color = primaryLayer.color;
			jetpackSecondary.color = secondaryLayer.color;
			jetpackGlow.color = secondaryLayer.color;
			ParticleSystem.MainModule main = jetpack.GetComponent<ParticleSystem>().main;
			main.startColor = nonBlackColor();
		}
		setGlow(shifter.shifted);
	}

	public Color nonBlackColor()
	{
		if (!(primaryLayer.color == Color.black))
		{
			return primaryLayer.color;
		}
		return secondaryLayer.color;
	}

	public void die()
	{
		spawnParticles(deathParticles);
		setActive(false);
		StartCoroutine(beginRespawn());
		aud.PlayOneShot(deathSound, 0.5f);
	}

	private IEnumerator beginRespawn()
	{
		setSprite();
		float spawnCheck = lastSpawn;
		yield return new WaitForSeconds(respawnTime);
		if (!col.enabled && spawnCheck == lastSpawn)
		{
			base.transform.position = startPos;
			ParticleSystem.MainModule mainModule = spawnParticles(respawnParticles);
			GameObject gameObject = GameObject.FindWithTag("Player");
			if ((bool)gameObject && !gameObject.GetComponent<Player>().win)
			{
				float num = Vector2.Distance(base.transform.position, gameObject.transform.position);
				float value = 2.2f - 0.18f * num;
				aud.PlayOneShot(respawnSound, Mathf.Clamp(value, 0f, 0.8f));
				yield return new WaitForSeconds(mainModule.startLifetime.Evaluate(1f) * 0.8f);
				respawn();
				smoothSpawn();
			}
		}
	}

	private ParticleSystem.MainModule spawnParticles(GameObject particleType)
	{
		ParticleSystem.MainModule main = Object.Instantiate(particleType, base.transform.position, base.transform.rotation).GetComponent<ParticleSystem>().main;
		main.startColor = nonBlackColor();
		return main;
	}

	private void respawn()
	{
		if (floating)
		{
			sequence.Pause();
		}
		base.transform.position = startPos;
		setActive(true);
	}

	public void setActive(bool enabled)
	{
		col.enabled = enabled;
		primaryLayer.enabled = enabled;
		secondaryLayer.enabled = enabled;
		whiteLayer.enabled = enabled;
		glowLayer.enabled = enabled;
		jetpack.SetActive(floating && enabled);
		if (enabled)
		{
			setGlow(shifter.shifted);
		}
	}

	private void smoothSpawn()
	{
		base.transform.localScale = new Vector2(0f, 0f);
		base.transform.position = startPos;
		base.transform.DOScale(new Vector2(1f, 1f), 0.75f).SetEase(Ease.OutExpo).OnComplete(_003CsmoothSpawn_003Eb__36_0);
		setGlow(shifter.shifted);
		lastSpawn = Time.fixedTime;
	}

	public void setGlow(bool enabled)
	{
		if (!(col == null) && col.enabled)
		{
			bool flag = enabled || alwaysGlow || primaryLayer.color == Color.black;
			glowLayer.enabled = flag;
			jetpackGlow.enabled = flag;
		}
	}

	public void OnPlayerRespawn()
	{
		setSprite();
		respawn();
		smoothSpawn();
	}

	[CompilerGenerated]
	private void _003CsmoothSpawn_003Eb__36_0()
	{
		if (floating)
		{
			sequence.Restart();
		}
	}
}
