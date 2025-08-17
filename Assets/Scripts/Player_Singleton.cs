using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Singleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingletonGameManager.Instance.AddScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
