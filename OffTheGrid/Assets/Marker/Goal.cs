using UnityEngine;
public class Goal : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		if (!other.transform.TryGetComponent(out Player player)) return;

		if (player.Intersects(transform.position))
		{
			Debug.Log(LevelManager.Complete(), this);
		}
	}
}
