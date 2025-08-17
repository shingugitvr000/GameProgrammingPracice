using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NoSingleton : MonoBehaviour
{
    public NoSingletonGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null)
        {
            gameManager.AddScore(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
