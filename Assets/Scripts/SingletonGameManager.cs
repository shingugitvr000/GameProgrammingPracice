using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameManager : MonoBehaviour
{
    public static SingletonGameManager Instance { get; private set; }

    public int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Singleton Score : " + score);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
