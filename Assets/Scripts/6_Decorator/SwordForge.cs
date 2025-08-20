using UnityEngine;
using UnityEngine.UI;

public class SwordForge : MonoBehaviour
{
    [Header("UI")]
    public Text swordInfoText;
    public Text goldText;
    public Button sharpnessBtn;
    public Button fireBtn;
    public Button iceBtn;
    public Button resetBtn;
    public Button attackBtn;

    [Header("Visual")]
    public Renderer swordRenderer;
    public Light glowLight;

    public int gold = 1000;
    private ISword currentSword;

    void Start()
    {
        currentSword = new BasicSword();
        SetupButtons();
        UpdateAll();
    }

    private void SetupButtons()
    {
        sharpnessBtn.onClick.AddListener(() => TryEnhance<SharpnessEnhancement>(100));
        fireBtn.onClick.AddListener(() => TryEnhance<FireEnchantment>(200));
        iceBtn.onClick.AddListener(() => TryEnhance<IceEnchantment>(200));
        resetBtn.onClick.AddListener(ResetSword);
        attackBtn.onClick.AddListener(TestAttack);
    }

    private void TryEnhance<T>(int cost) where T : SwordDecorator
    {
        if (gold >= cost)
        {
            gold -= cost;
            currentSword = (T)System.Activator.CreateInstance(typeof(T), currentSword);
            UpdateAll();
            Debug.Log($"{typeof(T).Name} ����!");
        }
        else
        {
            Debug.Log("��� ����!");
        }
    }

    private void ResetSword()
    {
        currentSword = new BasicSword();
        UpdateAll();
    }

    public void TestAttack()
    {
        int damage = currentSword.GetAttackPower();
        bool isCritical = Random.Range(0, 100) < currentSword.GetCriticalChance();

        if (isCritical) damage *= 2;

        Debug.Log($"{(isCritical ? "ũ��Ƽ��!" : "����!")} ������: {damage}");

        if (!string.IsNullOrEmpty(currentSword.GetSpecialEffect()))
        {
            Debug.Log($"{currentSword.GetSpecialEffect()}");
        }
    }

    private void UpdateAll()
    {
        UpdateUI();
        UpdateVisual();
    }

    private void UpdateUI()
    {
        swordInfoText.text = $"{currentSword.GetName()}\n" +
                           $"���ݷ�: {currentSword.GetAttackPower()}\n" +
                           $"ũ��Ƽ��: {currentSword.GetCriticalChance()}%\n" +
                           $"ȿ��: {currentSword.GetSpecialEffect()}";

        goldText.text = $"���: {gold}";
    }

    private void UpdateVisual()
    {
        if (swordRenderer != null)
            swordRenderer.material.color = currentSword.GetBladeColor();

        if (glowLight != null)
        {
            glowLight.intensity = currentSword.GetGlowIntensity();
            glowLight.color = currentSword.GetBladeColor();
        }
    }
}
