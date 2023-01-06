using UnityEngine;

public class Autoscroll : MonoBehaviour
{
	public float speed = 1f;

	public float width = 25f;

	private void Update()
	{
		float num = base.transform.position.x + speed * Time.deltaTime;
		if (num >= width)
		{
			num -= width;
		}
		else if (num <= 0f - width)
		{
			num += width;
		}
		base.transform.position = new Vector2(num, base.transform.position.y);
	}
}
