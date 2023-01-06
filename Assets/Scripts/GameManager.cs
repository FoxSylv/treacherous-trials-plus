using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[NonSerialized]
	public bool firstLoad = true;

	[NonSerialized]
	public int lastLevel;

	private string activeName = "Active GameManager";

	private void Awake()
	{
		if ((bool)GameObject.Find(activeName))
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		base.gameObject.name = activeName;
		base.transform.parent = null;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}
}
