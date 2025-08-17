// ===== UI ǥ�ÿ� =====
using UnityEngine;
using UnityEngine.UI;

public class StateDisplay : MonoBehaviour
{
    public Text stateText;
    private SimplePlayer player;

    void Start()
    {
        player = FindObjectOfType<SimplePlayer>();
    }

    void Update()
    {
        if (player != null)
        {
            string stateName = player.GetType()
                .GetField("currentState", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(player)?.GetType().Name ?? "�� �� ����";

            stateText.text = $"����: {stateName}\n �̵� Ű�� �̵�";
        }
    }
}