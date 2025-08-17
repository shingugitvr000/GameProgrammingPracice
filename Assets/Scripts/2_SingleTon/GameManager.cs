using UnityEngine;

/// <summary>
/// ���� �������� ������ ����ϴ� �̱��� Ŭ����
/// </summary>
public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    private static GameManager _instance;

    // ���� ���� ����
    public int playerScore = 0;
    public int playerLives = 3;
    public bool isGamePaused = false;

    // �̱��� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ������ ã�Ƽ� ����
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                // ���� GameManager�� ������ ���� ����
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    _instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // �̹� �ν��Ͻ��� �ִ��� Ȯ��
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �ı����� ����
        }
        else if (_instance != this)
        {
            // �ߺ� ���� ����
            Destroy(gameObject);
        }
    }

    // ���� ���� ����
    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log($"���� ����: {playerScore}");
    }

    // ���� ����
    public void LoseLife()
    {
        playerLives--;
        Debug.Log($"���� ����: {playerLives}");

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    // ���� �Ͻ�����
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        Debug.Log("���� �Ͻ�����");
    }

    // ���� �簳
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("���� �簳");
    }

    // ���� ����
    private void GameOver()
    {
        Debug.Log("���� ����!");
        Time.timeScale = 0f;
    }

    // ���� �ʱ�ȭ
    public void ResetGame()
    {
        playerScore = 0;
        playerLives = 3;
        isGamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("���� �ʱ�ȭ �Ϸ�");
    }
}