// 1. ������ ������ �������̽�
using UnityEngine;

public interface IGameObserver
{
    void OnPlayerAction(string action);
}

// 2. UI ������
public class UIWatcher : IGameObserver
{
    public void OnPlayerAction(string action)
    {
        Debug.Log($"UI: {action} �߻�!");
    }
}

// 3. ���� ������  
public class SoundWatcher : IGameObserver
{
    public void OnPlayerAction(string action)
    {
        Debug.Log($"����: {action} ȿ���� ���!");
    }
}