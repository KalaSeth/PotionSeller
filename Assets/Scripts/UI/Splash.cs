using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public float SplashTimer;

    private void Start()
    {
        Invoke("LoadMenu", SplashTimer);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
