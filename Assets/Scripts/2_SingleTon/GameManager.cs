using UnityEngine;

/// <summary>
/// 게임 전반적인 관리를 담당하는 싱글턴 클래스
/// </summary>
public class GameManager : MonoBehaviour
{
    // 싱글턴 인스턴스
    private static GameManager _instance;

    // 게임 상태 관리
    public int playerScore = 0;
    public int playerLives = 3;
    public bool isGamePaused = false;

    // 싱글턴 프로퍼티
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없으면 찾아서 생성
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                // 씬에 GameManager가 없으면 새로 생성
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
        // 이미 인스턴스가 있는지 확인
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않음
        }
        else if (_instance != this)
        {
            // 중복 생성 방지
            Destroy(gameObject);
        }
    }

    // 게임 점수 관리
    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log($"현재 점수: {playerScore}");
    }

    // 생명 관리
    public void LoseLife()
    {
        playerLives--;
        Debug.Log($"남은 생명: {playerLives}");

        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    // 게임 일시정지
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        Debug.Log("게임 일시정지");
    }

    // 게임 재개
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("게임 재개");
    }

    // 게임 오버
    private void GameOver()
    {
        Debug.Log("게임 오버!");
        Time.timeScale = 0f;
    }

    // 게임 초기화
    public void ResetGame()
    {
        playerScore = 0;
        playerLives = 3;
        isGamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("게임 초기화 완료");
    }
}