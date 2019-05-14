using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string s)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }
}
