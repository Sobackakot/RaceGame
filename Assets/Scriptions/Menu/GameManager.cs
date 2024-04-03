using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float second = 3f;
    public void Update()
    {
        MenuScene();
    }
    public void MenuScene()
    {
        if(Time.timeScale <= 0)
        {
            second -= 0.01f;
            if(second <= 0)
            {
                SceneManager.LoadScene(0);
            } 
        }
    }
}
