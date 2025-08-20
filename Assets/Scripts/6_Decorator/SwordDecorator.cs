using UnityEngine;

public abstract class SwordDecorator : ISword
{
    protected ISword sword;

    public SwordDecorator(ISword sword)
    {
        this.sword = sword;
    }

    public virtual string GetName() => sword.GetName();
    public virtual int GetAttackPower() => sword.GetAttackPower();
    public virtual int GetCriticalChance() => sword.GetCriticalChance();
    public virtual string GetSpecialEffect() => sword.GetSpecialEffect();
    public virtual Color GetBladeColor() => sword.GetBladeColor();
    public virtual float GetGlowIntensity() => sword.GetGlowIntensity();
}