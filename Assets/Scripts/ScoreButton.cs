using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreButton : MonoBehaviour
{
    public void OnAddScoreClick()
    {
        SingletonGameManager.Instance.AddScore(1);
    }
}
