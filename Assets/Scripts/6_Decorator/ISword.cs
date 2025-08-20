using UnityEngine;

public interface ISword
{
    string GetName();
    int GetAttackPower();
    int GetCriticalChance();
    string GetSpecialEffect();
    Color GetBladeColor();
    float GetGlowIntensity();
}