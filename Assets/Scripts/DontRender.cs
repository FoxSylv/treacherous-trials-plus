using UnityEngine;

public class DontRender : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<SpriteRenderer>().enabled = false;
	}
}
