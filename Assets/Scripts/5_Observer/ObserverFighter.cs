// 4. ���� StrategyFighter�� ������ ��ɸ� �߰�
using UnityEngine;
using System.Collections.Generic;

public class ObserverFighter : MonoBehaviour
{
    // ���� ���� ���� �ڵ� �״��
    private IAttackStrategy currentStrategy;
    private PunchStrategy punchStrategy = new PunchStrategy();
    private KickStrategy kickStrategy = new KickStrategy();

    // ������ ��ɸ� �߰�
    private List<IGameObserver> watchers = new List<IGameObserver>();
    private string lastAction = "";

    void Start()
    {
        // ���� �ʱ�ȭ
        currentStrategy = punchStrategy;

        // �����ڵ� �߰�
        watchers.Add(new UIWatcher());
        watchers.Add(new SoundWatcher());
    }

    void Update()
    {
        // ���� ���� ���� �ڵ� + �˸� �߰�
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentStrategy = punchStrategy;
            NotifyWatchers("��ġ ����");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentStrategy = kickStrategy;
            NotifyWatchers("ű ����");
        }

        // ���� ���� �ڵ� + �˸� �߰�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentStrategy.Attack();
            NotifyWatchers($"{currentStrategy.GetName()} ����");
        }
    }

    // �����ڵ鿡�� �˸� (���� �߰�)
    private void NotifyWatchers(string action)
    {
        lastAction = action;
        foreach (IGameObserver watcher in watchers)
        {
            watcher.OnPlayerAction(action);
        }
    }

    // ���� �޼����
    public string GetCurrentStrategyName()
    {
        return currentStrategy.GetName();
    }

    public string GetLastAction()
    {
        return lastAction;
    }
}