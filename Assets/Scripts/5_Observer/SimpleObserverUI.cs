using UnityEngine;
using UnityEngine.UI;

public class SimpleObserverUI : MonoBehaviour
{
    public Text infoText;
    private ObserverFighter fighter;

    void Start()
    {
        fighter = FindObjectOfType<ObserverFighter>();
    }

    void Update()
    {
        if (fighter != null)
        {
            string action = fighter.GetLastAction();
            string actionDisplay = string.IsNullOrEmpty(action) ? "" : $"\n\n마지막 액션: {action}";

            infoText.text = $"전략 + 옵저버 패턴\n\n" +
                           $"현재 전략: {fighter.GetCurrentStrategyName()}\n\n" +
                           "Q: 펀치\n" +
                           "E: 킥\n" +
                           "Space: 공격" +
                           actionDisplay;
        }
    }
}