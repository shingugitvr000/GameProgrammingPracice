using UnityEngine;

public class NotificationManager : MonoBehaviour, IGameObserver
{
    private int levelUpCount = 0;
    private int itemCount = 0;

    private void Start()
    {
        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.AddObserver(this);
        }
    }

    private void OnDestroy()
    {
        if (GameEventManager.Instance != null)
        {
            GameEventManager.Instance.RemoveObserver(this);
        }
    }

    public void OnPlayerLevelUp(int level)
    {
        levelUpCount++;
        Debug.Log($"[Notification] 레벨업 {levelUpCount}회 달성!");

        if (level == 5)
        {
            Debug.Log("[Notification] 첫 번째 마일스톤 달성!");
        }
    }

    public void OnPlayerScoreChanged(int score)
    {
        if (score >= 1000 && score % 1000 == 0)
        {
            Debug.Log($"[Notification] {score}점 달성!");
        }
    }

    public void OnPlayerHealthChanged(int health)
    {
        if (health <= 20)
        {
            Debug.Log("[Notification] 위험! 체력이 매우 부족합니다!");
        }
    }

    public void OnItemCollected(string itemName)
    {
        itemCount++;
        Debug.Log($"[Notification] 총 {itemCount}개 아이템 수집!");

        if (itemCount >= 10)
        {
            Debug.Log("[Notification] 아이템 수집가 업적 달성!");
        }
    }
}
