// ===== 4강: 전략 패턴 - 완전히 새로운 예제 =====

// 1. 공격 전략 인터페이스
using UnityEngine;

public interface IAttackStrategy
{
    void Attack();
    string GetName();
}

// 2. 펀치 전략
public class PunchStrategy : IAttackStrategy
{
    public void Attack()
    {
        Debug.Log("주먹으로 펀치!");
    }

    public string GetName()
    {
        return "펀치";
    }
}

// 3. 킥 전략
public class KickStrategy : IAttackStrategy
{
    public void Attack()
    {
        Debug.Log("발로 킥!");
    }

    public string GetName()
    {
        return "킥";
    }
}