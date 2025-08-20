using UnityEngine;

public class FireEnchantment : SwordDecorator
{
    public FireEnchantment(ISword sword) : base(sword) { }

    public override string GetName()
    {
        return base.GetName() + " (화염)";
    }

    public override int GetAttackPower()
    {
        return base.GetAttackPower() + 8;
    }

    public override string GetSpecialEffect()
    {
        string baseEffect = base.GetSpecialEffect();
        string fireEffect = "화상 데미지";

        return string.IsNullOrEmpty(baseEffect) ? fireEffect : baseEffect + ", " + fireEffect;
    }

    public override Color GetBladeColor()
    {
        return Color.red;
    }

    public override float GetGlowIntensity()
    {
        return base.GetGlowIntensity() + 1.5f;
    }
}