// ===== Walk 상태 =====
using UnityEngine;

public class WalkState : IPlayerState
{
    public void HandleInput(SimplePlayer player)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            // 수평 이동
            player.transform.Translate(Vector3.right * horizontal * 3f * Time.deltaTime);
            // 수직 이동
            player.transform.Translate(Vector3.up * vertical * 3f * Time.deltaTime);
        }
        else
        {
            player.ChangeState(player.GetIdleState());
        }
    }
}