// ===== Idle ป๓ลย =====
using UnityEngine;

public class IdleState : IPlayerState
{
    public void HandleInput(SimplePlayer player)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            player.ChangeState(player.GetWalkState());
        }
    }
}