using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
	public RectTransform parent;
	public GameObject linePrefab;
	private List<TextAnimator> lines = new List<TextAnimator>();

	public static List<Coroutine> queue = new List<Coroutine>();
	
	private void Start()
	{
		WriteLine("Testing");
		WriteLine("Testing");
		WriteLine("Testing");
		WriteLine("Testing");
		WriteLine("Testing");
		WriteLine("Testing");
	}

	void WriteLine(string message)
	{
		var go = Instantiate(linePrefab, parent);
		if(!go.TryGetComponent(out TextAnimator text)) return;
		text.AnimateText(message);
	}
	
}
