// 1. 간단한 관찰자 인터페이스
using UnityEngine;

public interface IGameObserver
{
    void OnPlayerAction(string action);
}

// 2. UI 관찰자
public class UIWatcher : IGameObserver
{
    public void OnPlayerAction(string action)
    {
        Debug.Log($"UI: {action} 발생!");
    }
}

// 3. 사운드 관찰자  
public class SoundWatcher : IGameObserver
{
    public void OnPlayerAction(string action)
    {
        Debug.Log($"사운드: {action} 효과음 재생!");
    }
}