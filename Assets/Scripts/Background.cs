using UnityEngine;

public class Background : MonoBehaviour
{
	private Color col;

	private SpriteRenderer rend;

	private float yOffset;

	public float parallax;

	private void Awake()
	{
		rend = GetComponent<SpriteRenderer>();
		col = rend.color;
		yOffset = base.transform.position.y;
	}

	private void Update()
	{
		base.transform.position = new Vector2(Camera.main.transform.position.x * parallax, Camera.main.transform.position.y * 0.925f + 3f + yOffset);
	}

	public void shiftColor(bool shifted)
	{
		rend.color = (shifted ? Color.black : col);
	}
}
