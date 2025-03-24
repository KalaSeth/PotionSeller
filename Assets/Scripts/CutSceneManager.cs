using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject IntroScene;
    [SerializeField] private GameObject OutroSceneBad;
    [SerializeField] private GameObject OutroSceneGood;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.GameDone == 0)
        {
            ShowIntro();
        }
        else if (GameManager.instance.GameDone == 1)
        {
            ShowBadOutro();
        }
        else if (GameManager.instance.GameDone == 2)
        {
            ShowGoodOutro();
        }
    }

    void ShowIntro()
    {
        IntroScene.SetActive(true);
                                        // Save the GameDone here using playerprefs;
        SceneManager.LoadScene(3);
    }

    void ShowBadOutro()
    {
        OutroSceneBad.SetActive(true);
        PlayerPrefs.DeleteAll();
        Invoke("Something", 8);
    }

    public void Something()
    {
        SceneManager.LoadScene(0);
    }
    void ShowGoodOutro()
    {
        OutroSceneGood.SetActive(true);
        PlayerPrefs.DeleteAll();
        Invoke("Something", 3);
    }
}
