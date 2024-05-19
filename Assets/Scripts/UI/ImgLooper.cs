using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgLooper : MonoBehaviour
{
    public Sprite[] img1;
    public Sprite[] img2;
    public float FPS;

    public Text LoadText;
    public string[] randomtext;
    public Image image;   
    Sprite[] Img;
    float Index = 0;

    void Start()
    {
      //  randomtext[0] = ".lOaDiNg.";
      //  randomtext[1] = "..loading..";
      //  randomtext[2] = "...Loading...";

        StartLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (FPS >= 0)
        {
            FPS -= Time.deltaTime;
            if (FPS <= 0)
            {
                FPS = 0.2f;
                ShowLoading();
            }
        }

        LoadText.text = randomtext[(int)Index];
        image.sprite = Img[(int)Index];
    }

    public void StartLoad()
    {
        if (Random.value >= 0.5f)
        {
            Img = img1;
        }
        else if (Random.value < 0.5f)
        {
            Img = img2;
        }
        Invoke("HideinTime", Random.Range(1.2f, 2.4f));
    }

    public void ShowLoading()
    {
        Index++;
        if (Index >= 3)
        {
            
            Index = 0;
        }
        
    }

    void HideinTime()
    {
        gameObject.SetActive(false);
    }
}
