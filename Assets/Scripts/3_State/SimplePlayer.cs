// ===== 간단한 플레이어 컨트롤러 =====
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    private IPlayerState currentState;
    private IdleState idleState = new IdleState();
    private WalkState walkState = new WalkState();

    void Start()
    {
        currentState = idleState;
    }

    void Update()
    {
        currentState.HandleInput(this);
        Debug.Log($"현재 상태: {currentState.GetType().Name}");
    }

    public void ChangeState(IPlayerState newState)
    {
        currentState = newState;
        Debug.Log($"상태 변경: {newState.GetType().Name}");
    }

    public IdleState GetIdleState() => idleState;
    public WalkState GetWalkState() => walkState;
}
