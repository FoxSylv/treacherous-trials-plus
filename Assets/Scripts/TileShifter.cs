using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileShifter : MonoBehaviour
{
	private struct TileData
	{
		public int layer;

		public int colChannel;

		public Vector3Int position;

		public Tilemap tilemap;

		public Tile.ColliderType colType;

		public TileData(int layer, int colChannel, Vector3Int position, Tilemap tilemap, Tile.ColliderType colType)
		{
			this.layer = layer;
			this.colChannel = colChannel;
			this.position = position;
			this.tilemap = tilemap;
			this.colType = colType;
		}
	}

	public bool shifted;

	public float shiftSoundVolume = 1f;

	public AudioClip shiftSound;

	public AudioClip webShiftSound;

	public GameObject background;

	public GameObject tileGrid;

	private AudioClip snd;

	public Color deactivatedColor = new Color(0f, 0f, 0f, 0.5f);

	public Color primaryColor;

	public Color secondaryColor;

	private List<TileData> tileList = new List<TileData>();

	private void Start()
	{
		Tilemap[] componentsInChildren = tileGrid.transform.GetComponentsInChildren<Tilemap>();
		foreach (Tilemap tilemap in componentsInChildren)
		{
			foreach (Vector3Int item in tilemap.cellBounds.allPositionsWithin)
			{
				Vector3Int position = new Vector3Int(item.x, item.y, item.z);
				Color color = tilemap.GetColor(position);
				Tile.ColliderType colliderType = tilemap.GetColliderType(position);
				if (color.a < 1f)
				{
					int num = (int)(color.a * 255f);
					int num2 = (int)(color.b * 255f);
					if (num == 251 || num == 252)
					{
                        tilemap.SetTileFlags(position, TileFlags.None);
						tileList.Add(new TileData((num == 251) ? 1 : 2, (num2 != 69) ? 1 : 2, position, tilemap, colliderType));
					}
				}
			}
		}
		updateShift();
		snd = shiftSound;
	}

	public void switchTiles(bool silent = false)
	{
		if (!silent)
		{
			GetComponent<AudioSource>().PlayOneShot(snd, shiftSoundVolume);
		}
		shifted = !shifted;
		updateShift();
	}

	private void updateShift()
	{
		GameObject gameObject = GameObject.Find("Active MusicPlayer");
		if ((bool)gameObject)
		{
			gameObject.GetComponent<MusicPlayer>().SetPiano(shifted, shifted ? 0.25f : 0.75f);
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Background");
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<Background>().shiftColor(shifted);
		}
		foreach (TileData tile in tileList)
		{
			bool flag = (shifted && tile.layer == 2) || (!shifted && tile.layer == 1);
			tile.tilemap.SetColor(tile.position, (!flag) ? deactivatedColor : ((tile.colChannel == 1) ? primaryColor : secondaryColor));
			if (tile.colType == Tile.ColliderType.Sprite)
			{
				tile.tilemap.SetColliderType(tile.position, flag ? Tile.ColliderType.Sprite : Tile.ColliderType.None);
			}
		}
		Object[] array2 = Object.FindObjectsOfType(typeof(Icon));
		for (int i = 0; i < array2.Length; i++)
		{
			((Icon)array2[i]).setGlow(shifted);
		}
	}
}
