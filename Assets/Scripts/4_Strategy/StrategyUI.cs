// 5. UI 표시
using UnityEngine;
using UnityEngine.UI;

public class StrategyUI : MonoBehaviour
{
    public Text infoText;
    private StrategyFighter fighter;

    void Start()
    {
        fighter = FindObjectOfType<StrategyFighter>();
        infoText.text = "전략 패턴\n\n" +
                       "Q: 펀치\n" +
                       "E: 킥\n" +
                       "Space: 공격";
    }

    void Update()
    {
        if (fighter != null)
        {
            string attackMessage = fighter.GetLastAttackMessage();
            string attackDisplay = string.IsNullOrEmpty(attackMessage) ? "" : $"\n{attackMessage}";

            infoText.text = $"전략 패턴\n\n" +
                           $"현재 전략: {fighter.GetCurrentStrategyName()}\n\n" +
                           "Q: 펀치\n" +
                           "E: 킥\n" +
                           "Space: 공격" +
                           attackDisplay;
        }
    }
}