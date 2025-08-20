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
        Debug.Log($"[Notification] ������ {levelUpCount}ȸ �޼�!");

        if (level == 5)
        {
            Debug.Log("[Notification] ù ��° ���Ͻ��� �޼�!");
        }
    }

    public void OnPlayerScoreChanged(int score)
    {
        if (score >= 1000 && score % 1000 == 0)
        {
            Debug.Log($"[Notification] {score}�� �޼�!");
        }
    }

    public void OnPlayerHealthChanged(int health)
    {
        if (health <= 20)
        {
            Debug.Log("[Notification] ����! ü���� �ſ� �����մϴ�!");
        }
    }

    public void OnItemCollected(string itemName)
    {
        itemCount++;
        Debug.Log($"[Notification] �� {itemCount}�� ������ ����!");

        if (itemCount >= 10)
        {
            Debug.Log("[Notification] ������ ������ ���� �޼�!");
        }
    }
}
