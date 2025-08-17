using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSingletonGameManager : MonoBehaviour
{
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Nosingleton Score : " + score);
    }
}
