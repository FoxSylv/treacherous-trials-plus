using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[Serializable]
	public struct LevelData
	{
		public string name;

		public string scene;

		public LevelData(string name, string scene)
		{
			this.name = name;
			this.scene = scene;
		}
	}

	public LevelData[] levels;
}
