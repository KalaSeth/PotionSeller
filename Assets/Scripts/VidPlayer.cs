using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    public static VidPlayer instance;
    public string IntroPlayer;
    public float Dt;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Destroy(gameObject, Dt);
    }

    public void PlayerVid()
    {
        VideoPlayer Intro = GetComponent<VideoPlayer>();

        if (Intro)
        {
            string Intropath = System.IO.Path.Combine(Application.streamingAssetsPath, IntroPlayer);
            Intro.url = Intropath;
            Intro.Play();
        }
    }
}
