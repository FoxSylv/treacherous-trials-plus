using UnityEngine;

public class Orb : MonoBehaviour
{
	[HideInInspector]
	public bool activated;

	public string type;

	public bool final;

	public void OnHit()
	{
		activated = true;
	}
}
