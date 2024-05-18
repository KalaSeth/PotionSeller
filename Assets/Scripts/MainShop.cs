using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainShop : MonoBehaviour
{
    /// <summary>
    /// Main Level Manager for the game play scene,
    /// This will manage the Day-night cycle,
    /// NPC spawn,
    /// Saves for level,
    /// </summary>

    public static MainShop instance;


    [SerializeField] private int DaynightTimer; // Main timer to track npc
    private int DayNightIndex;                  // Index to prog upon

    public int Rating;

    // NPC
    public GameObject NPC_Prefab;
    public GameObject NPCMouth_Prefab;
    public GameObject NPCSpawner;
    public GameObject SpawnTarget;
    public GameObject CounterTarget;

    // Potion
    public int PotionCount;
    int PotionSortCount;
    public int SelectedPotion;
    public GameObject PotionPrefab;
    public Slider[] ItemSlider;
    int ItemSliderIndex;
    public Transform PotionParent;
    public Transform[] PotionSelfTransform;
    int potionSelfTransformIndex;
    public GameObject[] PotionSelf;
    public GameObject[] tempPotionSelf;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OncClickCreatePotion()
    {
        potionSelfTransformIndex = PotionCount;

        if (PotionCount < 9)
        {
            GameObject newPotion = Instantiate(PotionPrefab, PotionSelfTransform[potionSelfTransformIndex].localPosition, PotionSelfTransform[potionSelfTransformIndex].localRotation, PotionParent).gameObject;

            PotionSelf[potionSelfTransformIndex] = newPotion;

            newPotion.GetComponent<PotionComponent>().CreatePotion();

            PotionCount++;
        }

       // for (ItemSliderIndex = 0; ItemSliderIndex < 7; ItemSliderIndex++)
       // {
       //     ItemSlider[ItemSliderIndex].value = 0;
       // }
    }

    public void DeletePotion(int potionID)
    {
        GameObject gameObject = PotionSelf[potionID];
        PotionSelf[potionID] = null;
        Destroy(gameObject);
        PotionCount--;

        PotionSortCount = 0;
        // SortPotionSelf();
        PotionSelf = null;
        CleartempSelf();
    }

    void SortPotionSelf()
    {
        for (int i = 0; i < 9; i++)
        {
            if (PotionSelf[i] != null)
            {
                tempPotionSelf[PotionSortCount] = PotionSelf[i];
                PotionSortCount++;
            }
        }

        PotionSelf = tempPotionSelf;
    }

    void CleartempSelf()
    {
        for (int j = 1; j < PotionParent.childCount; j++)
        {
            if (PotionParent.GetChild(j) != null)
            {
                PotionSelf[j] = PotionParent.GetChild(j).gameObject;
            }
        }
    }

}
