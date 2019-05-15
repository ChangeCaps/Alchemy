using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string s)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
    }

    public void NewCampain()
    {
        Manager.new_campain = true;
        Manager.instance = null;

        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
