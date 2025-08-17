// 4. 기존 StrategyFighter에 옵저버 기능만 추가
using UnityEngine;
using System.Collections.Generic;

public class ObserverFighter : MonoBehaviour
{
    // 기존 전략 패턴 코드 그대로
    private IAttackStrategy currentStrategy;
    private PunchStrategy punchStrategy = new PunchStrategy();
    private KickStrategy kickStrategy = new KickStrategy();

    // 옵저버 기능만 추가
    private List<IGameObserver> watchers = new List<IGameObserver>();
    private string lastAction = "";

    void Start()
    {
        // 기존 초기화
        currentStrategy = punchStrategy;

        // 관찰자들 추가
        watchers.Add(new UIWatcher());
        watchers.Add(new SoundWatcher());
    }

    void Update()
    {
        // 기존 전략 변경 코드 + 알림 추가
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentStrategy = punchStrategy;
            NotifyWatchers("펀치 선택");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentStrategy = kickStrategy;
            NotifyWatchers("킥 선택");
        }

        // 기존 공격 코드 + 알림 추가
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentStrategy.Attack();
            NotifyWatchers($"{currentStrategy.GetName()} 공격");
        }
    }

    // 관찰자들에게 알림 (새로 추가)
    private void NotifyWatchers(string action)
    {
        lastAction = action;
        foreach (IGameObserver watcher in watchers)
        {
            watcher.OnPlayerAction(action);
        }
    }

    // 기존 메서드들
    public string GetCurrentStrategyName()
    {
        return currentStrategy.GetName();
    }

    public string GetLastAction()
    {
        return lastAction;
    }
}