using System;
using UnityEngine;
using Action = System.Action;
using Time =  UnityEngine.Time;

[Serializable]
public class Level
{
    [SerializeField]
    private string name;
    public string Name
    {
        get => name;
        private set => name = value;
    }

    public readonly float StartTime;
    public bool Completed { get; private set; }
    
    public Action OnLevelCompleted;
    public Level(string displayName, Action levelCompleteCallback = null)
    {
        Name = displayName;
        OnLevelCompleted = levelCompleteCallback;
        StartTime = Time.time;
    }
    
    public float Complete()
    {
        Completed = true;
        OnLevelCompleted?.Invoke();
        // Returns time at level completion
        return Time.time;
    }
}