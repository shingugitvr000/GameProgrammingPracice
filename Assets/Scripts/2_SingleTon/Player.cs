using UnityEngine;

/// <summary>
/// �÷��̾� ĳ���Ϳ��� �̱��� �Ŵ������� ����ϴ� ����
/// </summary>
public class Player : MonoBehaviour
{
    [Header("�÷��̾� ����")]
    public float moveSpeed = 5f;
    public KeyCode pauseKey = KeyCode.P;

    private void Update()
    {
        HandleMovement();
        HandleInput();
    }

    private void HandleMovement()
    {
        // ������ �Ͻ����� ���¸� �̵����� ����
        if (GameManager.Instance.isGamePaused)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void HandleInput()
    {
        // �Ͻ����� ���
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

    // ������ ���� �� ȣ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // ���� �߰�
            GameManager.Instance.AddScore(10);

            // ���� ���� ���
            SoundManager.Instance.PlayCoinSound();

            // ������ ����
            Destroy(other.gameObject);
        }
    }

    // ���� ���� �� ������� ���
    private void Start()
    {
        SoundManager.Instance.PlayBackgroundMusic();
    }
}