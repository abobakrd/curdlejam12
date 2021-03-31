using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static Level CurrentLevel{ get; private set; }
	public List<Level> Levels = new List<Level>();
	
	private int levelIndex;
	private void Start()
	{
		if (Levels.Count <= 0)
			CurrentLevel = new Level("Level 0");
		else
			CurrentLevel = Levels[0];
	}

	public static float Complete() => CurrentLevel.Complete();
	private void StartNextLevel()
	{
		levelIndex++;

		if (levelIndex < Levels.Count)
			CurrentLevel = Levels[levelIndex];
		else
			CurrentLevel = new Level("New Level", StartNextLevel);
	}
}
