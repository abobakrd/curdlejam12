using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
	public TMP_Text text;
	public float delay;
	private Coroutine routine;
	private const string name = "HACKERMAN>";

	public void AnimateText(string message) => routine = StartCoroutine(AnimateTextRoutine(message));

	private IEnumerator AnimateTextRoutine(string message)
	{
		TerminalController.queue.Add(routine);
		
		var wait = new WaitForSeconds(delay);
		while(routine == null || 0 != TerminalController.queue.IndexOf(routine))
			yield return wait;
		
		text.text = name;
		foreach (var c in message)
		{
			text.text += c;
			yield return wait;
		}
		TerminalController.queue.Remove(routine);
	}
}
