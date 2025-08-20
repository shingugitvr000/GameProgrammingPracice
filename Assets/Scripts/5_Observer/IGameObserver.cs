using UnityEngine;

public interface IGameObserver
{
    void OnPlayerLevelUp(int level);
    void OnPlayerScoreChanged(int score);
    void OnPlayerHealthChanged(int health);
    void OnItemCollected(string itemName);
}