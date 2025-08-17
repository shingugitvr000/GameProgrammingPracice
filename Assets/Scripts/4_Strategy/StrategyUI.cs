// 5. UI ǥ��
using UnityEngine;
using UnityEngine.UI;

public class StrategyUI : MonoBehaviour
{
    public Text infoText;
    private StrategyFighter fighter;

    void Start()
    {
        fighter = FindObjectOfType<StrategyFighter>();
        infoText.text = "���� ����\n\n" +
                       "Q: ��ġ\n" +
                       "E: ű\n" +
                       "Space: ����";
    }

    void Update()
    {
        if (fighter != null)
        {
            string attackMessage = fighter.GetLastAttackMessage();
            string attackDisplay = string.IsNullOrEmpty(attackMessage) ? "" : $"\n{attackMessage}";

            infoText.text = $"���� ����\n\n" +
                           $"���� ����: {fighter.GetCurrentStrategyName()}\n\n" +
                           "Q: ��ġ\n" +
                           "E: ű\n" +
                           "Space: ����" +
                           attackDisplay;
        }
    }
}