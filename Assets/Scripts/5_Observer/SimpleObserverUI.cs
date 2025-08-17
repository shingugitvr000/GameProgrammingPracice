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
            string actionDisplay = string.IsNullOrEmpty(action) ? "" : $"\n\n������ �׼�: {action}";

            infoText.text = $"���� + ������ ����\n\n" +
                           $"���� ����: {fighter.GetCurrentStrategyName()}\n\n" +
                           "Q: ��ġ\n" +
                           "E: ű\n" +
                           "Space: ����" +
                           actionDisplay;
        }
    }
}