// ===== ������ �÷��̾� ��Ʈ�ѷ� =====
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
        Debug.Log($"���� ����: {currentState.GetType().Name}");
    }

    public void ChangeState(IPlayerState newState)
    {
        currentState = newState;
        Debug.Log($"���� ����: {newState.GetType().Name}");
    }

    public IdleState GetIdleState() => idleState;
    public WalkState GetWalkState() => walkState;
}
