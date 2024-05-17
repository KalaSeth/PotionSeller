using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int GameProg;        // Days 0,1,2,3,4 [5 days]
    public int Rating;          // Total Rating
    public int TotalKustmar;    // Total Kustmar
    public int TotalCoins;      // Total Coins

    public void Awake()
    {
        instance = this;
    }

}
