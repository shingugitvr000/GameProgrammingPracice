using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; private set; }

    private List<IGameObserver> observers = new List<IGameObserver>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddObserver(IGameObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
            Debug.Log($"Observer {observer.GetType().Name} added");
        }
    }

    public void RemoveObserver(IGameObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
            Debug.Log($"Observer {observer.GetType().Name} removed");
        }
    }

    public void NotifyPlayerLevelUp(int level)
    {
        Debug.Log($"[Event] Player leveled up to {level}");
        foreach (var observer in observers)
        {
            observer.OnPlayerLevelUp(level);
        }
    }

    public void NotifyPlayerScoreChanged(int score)
    {
        Debug.Log($"[Event] Player score: {score}");
        foreach (var observer in observers)
        {
            observer.OnPlayerScoreChanged(score);
        }
    }

    public void NotifyPlayerHealthChanged(int health)
    {
        Debug.Log($"[Event] Player health: {health}");
        foreach (var observer in observers)
        {
            observer.OnPlayerHealthChanged(health);
        }
    }

    public void NotifyItemCollected(string itemName)
    {
        Debug.Log($"[Event] Item collected: {itemName}");
        foreach (var observer in observers)
        {
            observer.OnItemCollected(itemName);
        }
    }
}