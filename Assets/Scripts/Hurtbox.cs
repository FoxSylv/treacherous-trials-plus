using UnityEngine;

public class Hurtbox : MonoBehaviour
{
	public Player player;

	private void OnTriggerEnter2D(Collider2D col)
	{
		player.OnHurtboxEnter(col);
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		player.OnHurtboxExit(col);
	}
}
