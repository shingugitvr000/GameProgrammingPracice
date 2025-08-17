using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadSceneB()
    {
        SceneManager.LoadScene("SceneB");
    }

    public void LoadSceneA()
    {
        SceneManager.LoadScene("SceneA");
    }
}
