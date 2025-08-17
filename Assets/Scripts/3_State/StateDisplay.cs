// ===== UI 표시용 =====
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
                ?.GetValue(player)?.GetType().Name ?? "알 수 없음";

            stateText.text = $"상태: {stateName}\n 이동 키로 이동";
        }
    }
}