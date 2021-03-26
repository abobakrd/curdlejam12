using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Marker : MonoBehaviour
{
	public Canvas canvas;
	public TMP_Text distanceLabel;
	private float distance;

	public static float Scale;
	private void Awake()
	{
		canvas.worldCamera = Camera.main;
	}
	public void SetDistance(int dist)
	{
		distanceLabel.SetText(dist.ToString());
		distance = dist * Scale;
	}

	public bool TryPassThrough(float playerX, float playerY, out Vector3 newPos)
	{
		// var pos = transform.position;
		// var xPos = pos.x * Scale;
		// var yPos = pos.y * Scale;
		//
		// if (playerX == xPos - Scale && playerY == yPos)
		// {
		// 	newPos = new Vector3(playerX + distance, playerY);
		// 	return true;
		// }
		// if (playerX == xPos + Scale && playerY == yPos)
		// {
		// 	newPos = new Vector3(playerX - distance, playerY);
		// 	return true;
		// }
		// if (playerY == yPos - Scale && playerX == xPos)
		// {
		// 	newPos = new Vector3(playerX, distance + playerY);
		// 	return true;
		// }
		// if (playerY == yPos + Scale && playerX == xPos)
		// {
		// 	newPos = new Vector3(playerX, playerY - distance);
		// 	return true;
		// }
		newPos = default;
		return false;
	}

	public void OnMouseDown()
	{
		if (TryPassThrough(Player.X * Scale, Player.Y * Scale, out var newPos))
			Player.MoveTo(newPos);
	}
}
