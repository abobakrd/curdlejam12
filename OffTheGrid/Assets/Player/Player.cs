using DG.Tweening;
using UnityEngine;
public class Player : MonoBehaviour
{
	public static int X;
	public static int Y;

	private static Transform tr;
	
	private void Awake()
	{
		tr = transform;
		var pos = tr.position;
		X = (int)pos.x;
		Y = (int)pos.y;
	}

	public static void MoveTo(Vector3 newPos)
	{
		tr.DOMove(newPos, 1.0f);
		X = (int)newPos.x;
		Y = (int)newPos.y;
	}
}
