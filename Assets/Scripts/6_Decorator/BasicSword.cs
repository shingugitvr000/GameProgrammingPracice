using UnityEngine;

public class BasicSword : ISword
{
    public string GetName()
    {
        return "철검";
    }

    public int GetAttackPower()
    {
        return 10;
    }

    public int GetCriticalChance()
    {
        return 5; // 5% 크리티컬
    }

    public string GetSpecialEffect()
    {
        return "";
    }

    public Color GetBladeColor()
    {
        return Color.gray; // 회색 철검
    }

    public float GetGlowIntensity()
    {
        return 0f; // 빛나지 않음
    }
}