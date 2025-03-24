using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deleter : MonoBehaviour
{
    public float DTime;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Invoke("ToGame", DTime);
        }
        Destroy(gameObject, DTime);
    }
    public void ToGame()
    {
        SceneManager.LoadScene(3);
    }
}
