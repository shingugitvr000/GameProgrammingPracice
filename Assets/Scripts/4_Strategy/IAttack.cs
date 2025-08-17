// ===== 4��: ���� ���� - ������ ���ο� ���� =====

// 1. ���� ���� �������̽�
using UnityEngine;

public interface IAttackStrategy
{
    void Attack();
    string GetName();
}

// 2. ��ġ ����
public class PunchStrategy : IAttackStrategy
{
    public void Attack()
    {
        Debug.Log("�ָ����� ��ġ!");
    }

    public string GetName()
    {
        return "��ġ";
    }
}

// 3. ű ����
public class KickStrategy : IAttackStrategy
{
    public void Attack()
    {
        Debug.Log("�߷� ű!");
    }

    public string GetName()
    {
        return "ű";
    }
}