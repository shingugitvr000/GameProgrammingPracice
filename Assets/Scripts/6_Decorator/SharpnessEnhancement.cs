using UnityEngine;

public class SharpnessEnhancement : SwordDecorator
{
    private int totalLevel = 0;
    private int myLevel;

    public SharpnessEnhancement(ISword sword) : base(sword)
    {
        totalLevel++;
        myLevel = totalLevel;
    }

    public override string GetName()
    {
        return base.GetName() + $" +{myLevel}";
    }

    public override int GetAttackPower()
    {
        return base.GetAttackPower() + 5;
    }

    public override Color GetBladeColor()
    {
        Color baseColor = base.GetBladeColor();
        return Color.Lerp(baseColor, Color.white, 0.3f);
    }

    public override float GetGlowIntensity()
    {
        return base.GetGlowIntensity() + 0.5f;
    }
}