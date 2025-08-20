using UnityEngine;

public class ObserverPlayer : MonoBehaviour
{
    [Header("Player Stats")]
    public int level = 1;
    public int score = 0;
    public int health = 100;

    [Header("Test Controls")]
    public KeyCode levelUpKey = KeyCode.L;
    public KeyCode addScoreKey = KeyCode.P;
    public KeyCode takeDamageKey = KeyCode.H;
    public KeyCode collectItemKey = KeyCode.I;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(levelUpKey))
        {
            LevelUp();
        }

        if (Input.GetKeyDown(addScoreKey))
        {
            AddScore(100);
        }

        if (Input.GetKeyDown(takeDamageKey))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(collectItemKey))
        {
            CollectItem();
        }
    }

    public void LevelUp()
    {
        level++;
        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.NotifyPlayerLevelUp(level);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.NotifyPlayerScoreChanged(score);
        }
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);
        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.NotifyPlayerHealthChanged(health);
        }
    }

    public void CollectItem()
    {
        string[] items = { "器记", "内牢", "联", "八", "规菩" };
        string randomItem = items[Random.Range(0, items.Length)];

        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.NotifyItemCollected(randomItem);
        }
    }
}