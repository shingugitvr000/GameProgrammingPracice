using UnityEngine;

public class BasicSword : ISword
{
    public string GetName()
    {
        return "ö��";
    }

    public int GetAttackPower()
    {
        return 10;
    }

    public int GetCriticalChance()
    {
        return 5; // 5% ũ��Ƽ��
    }

    public string GetSpecialEffect()
    {
        return "";
    }

    public Color GetBladeColor()
    {
        return Color.gray; // ȸ�� ö��
    }

    public float GetGlowIntensity()
    {
        return 0f; // ������ ����
    }
}