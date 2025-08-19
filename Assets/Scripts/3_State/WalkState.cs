// ===== Walk ���� =====
using UnityEngine;

public class WalkState : IPlayerState
{
    public void HandleInput(SimplePlayer player)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            // ���� �̵�
            player.transform.Translate(Vector3.right * horizontal * 3f * Time.deltaTime);
            // ���� �̵�
            player.transform.Translate(Vector3.up * vertical * 3f * Time.deltaTime);
        }
        else
        {
            player.ChangeState(player.GetIdleState());
        }
    }
}