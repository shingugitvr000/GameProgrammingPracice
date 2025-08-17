// 4. 전략 패턴 전용 플레이어 (기존 코드와 완전 분리)
using UnityEngine;

public class StrategyFighter : MonoBehaviour
{
    private IAttackStrategy currentStrategy;
    private PunchStrategy punchStrategy = new PunchStrategy();
    private KickStrategy kickStrategy = new KickStrategy();

    private string lastAttackMessage = ""; // 마지막 공격 메시지

    void Start()
    {
        currentStrategy = punchStrategy; // 기본은 펀치
    }

    void Update()
    {
        // 전략 변경
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentStrategy = punchStrategy;
            lastAttackMessage = ""; // 전략 바뀌면 메시지 초기화
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentStrategy = kickStrategy;
            lastAttackMessage = ""; // 전략 바뀌면 메시지 초기화
        }

        // 공격 실행
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentStrategy.Attack();
            lastAttackMessage = $"{currentStrategy.GetName()} 공격 실행!";
        }

        Debug.Log($"현재 전략: {currentStrategy.GetName()}");
    }

    // UI에서 사용할 메서드들
    public string GetCurrentStrategyName()
    {
        return currentStrategy.GetName();
    }

    public string GetLastAttackMessage()
    {
        return lastAttackMessage;
    }
}