// 4. ���� ���� ���� �÷��̾� (���� �ڵ�� ���� �и�)
using UnityEngine;

public class StrategyFighter : MonoBehaviour
{
    private IAttackStrategy currentStrategy;
    private PunchStrategy punchStrategy = new PunchStrategy();
    private KickStrategy kickStrategy = new KickStrategy();

    private string lastAttackMessage = ""; // ������ ���� �޽���

    void Start()
    {
        currentStrategy = punchStrategy; // �⺻�� ��ġ
    }

    void Update()
    {
        // ���� ����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentStrategy = punchStrategy;
            lastAttackMessage = ""; // ���� �ٲ�� �޽��� �ʱ�ȭ
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentStrategy = kickStrategy;
            lastAttackMessage = ""; // ���� �ٲ�� �޽��� �ʱ�ȭ
        }

        // ���� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentStrategy.Attack();
            lastAttackMessage = $"{currentStrategy.GetName()} ���� ����!";
        }

        Debug.Log($"���� ����: {currentStrategy.GetName()}");
    }

    // UI���� ����� �޼����
    public string GetCurrentStrategyName()
    {
        return currentStrategy.GetName();
    }

    public string GetLastAttackMessage()
    {
        return lastAttackMessage;
    }
}