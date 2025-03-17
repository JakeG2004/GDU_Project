using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if(Time.timeScale == 0.0f){
            Time.timeScale = 1.0f;
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
