using UnityEngine;

public class IceEnchantment : SwordDecorator
{
    public IceEnchantment(ISword sword) : base(sword) { }

    public override string GetName()
    {
        return base.GetName() + " (����)";
    }

    public override int GetAttackPower()
    {
        return base.GetAttackPower() + 6;
    }

    public override string GetSpecialEffect()
    {
        string baseEffect = base.GetSpecialEffect();
        string iceEffect = "��ȭ ȿ��";

        return string.IsNullOrEmpty(baseEffect) ? iceEffect : baseEffect + ", " + iceEffect;
    }

    public override Color GetBladeColor()
    {
        return Color.cyan;
    }

    public override float GetGlowIntensity()
    {
        return base.GetGlowIntensity() + 1.2f;
    }
}