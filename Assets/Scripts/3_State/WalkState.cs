// ===== Walk ป๓ลย =====
using UnityEngine;

public class WalkState : IPlayerState
{
    public void HandleInput(SimplePlayer player)
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            player.transform.Translate(Vector3.right * horizontal * 3f * Time.deltaTime);
        }
        else
        {
            player.ChangeState(player.GetIdleState());
        }
    }
}