using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	[Serializable]
	public struct NCAnimation
	{
		public string name;

		public Sprite[] frames;

		public float speed;

		public string onFinish;

		public int loopStart;

		public NCAnimation(string name, Sprite[] frames, float speed, string onFinish, int loopStart)
		{
			this.name = name;
			this.frames = frames;
			this.speed = speed;
			this.onFinish = onFinish;
			this.loopStart = loopStart;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public string animName;

		internal bool _003CsetAnimation_003Eb__0(NCAnimation a)
		{
			return a.name == animName;
		}
	}

	private int frame;

	private int animID;

	public NCAnimation currentAnimation;

	public SpriteRenderer sprRenderer;

	public NCAnimation[] animationList;

	private void Start()
	{
		setAnimation("idle");
	}

	public void setAnimation(string animName, bool forceRestart = false)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.animName = animName;
		if (!forceRestart && _003C_003Ec__DisplayClass7_.animName == currentAnimation.name)
		{
			return;
		}
		NCAnimation nCAnimation = Array.Find(animationList, _003C_003Ec__DisplayClass7_._003CsetAnimation_003Eb__0);
		if (nCAnimation.name != null)
		{
			frame = 0;
			animID++;
			if (animID >= 999)
			{
				animID = -999;
			}
			currentAnimation = nCAnimation;
			StartCoroutine(animate());
		}
	}

	private IEnumerator animate()
	{
		int currentID = animID;
		sprRenderer.sprite = currentAnimation.frames[frame];
		yield return new WaitForSeconds(currentAnimation.speed);
		if (currentID != animID)
		{
			yield break;
		}
		frame++;
		if (frame >= currentAnimation.frames.Length)
		{
			if (currentAnimation.onFinish != null && currentAnimation.onFinish.Length >= 1)
			{
				if (!(currentAnimation.onFinish == "freeze"))
				{
					setAnimation(currentAnimation.onFinish);
					yield break;
				}
				frame--;
			}
			else
			{
				frame = currentAnimation.loopStart;
			}
		}
		StartCoroutine(animate());
	}
}
