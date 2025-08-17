using UnityEngine;

/// <summary>
/// 플레이어 캐릭터에서 싱글턴 매니저들을 사용하는 예제
/// </summary>
public class Player : MonoBehaviour
{
    [Header("플레이어 설정")]
    public float moveSpeed = 5f;
    public KeyCode pauseKey = KeyCode.P;

    private void Update()
    {
        HandleMovement();
        HandleInput();
    }

    private void HandleMovement()
    {
        // 게임이 일시정지 상태면 이동하지 않음
        if (GameManager.Instance.isGamePaused)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void HandleInput()
    {
        // 일시정지 토글
        if (Input.GetKeyDown(pauseKey))
        {
            if (GameManager.Instance.isGamePaused)
            {
                GameManager.Instance.ResumeGame();
            }
            else
            {
                GameManager.Instance.PauseGame();
            }
        }
    }

    // 아이템 수집 시 호출
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // 점수 추가
            GameManager.Instance.AddScore(10);

            // 수집 사운드 재생
            SoundManager.Instance.PlayCoinSound();

            // 아이템 제거
            Destroy(other.gameObject);
        }
    }

    // 게임 시작 시 배경음악 재생
    private void Start()
    {
        SoundManager.Instance.PlayBackgroundMusic();
    }
}