using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public float SpawnDelayTimer;
    public bool NPConCounter;
    public GameObject CurrentNPC;
    public GameObject NPC_Prefab;
    public GameObject NPCMouth_Prefab;
    public GameObject NPCSpawner;
    public GameObject SpawnTarget;
    public GameObject CounterTarget;

    // NPC Mouth

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
    public InputField PotionNameInputField;



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
        if (DaynightTimer >= 0)
        {
           
            if (NPConCounter == false)
            {
                SpawnDelayTimer -= Time.deltaTime;
                
                if (SpawnDelayTimer <= 0)
                {
                    NPCChainer();
                    SpawnDelayTimer = Random.Range(3, 7);
                }
            }
        }
    }

    public void NPCChainer()
    {
        GameObject gameObject = Instantiate(NPCMouth_Prefab, SpawnTarget.transform.position, SpawnTarget.transform.rotation, SpawnTarget.transform);
        CurrentNPC = gameObject;
        NPConCounter = true;

    }


    public void OncClickCreatePotion()
    {
        potionSelfTransformIndex = PotionCount;

        if (PotionCount < 10)
        {
            GameObject newPotion = Instantiate(PotionPrefab, PotionSelfTransform[potionSelfTransformIndex].localPosition, PotionSelfTransform[potionSelfTransformIndex].localRotation, PotionParent).gameObject;

            PotionSelf[potionSelfTransformIndex] = newPotion;
            newPotion.name = PotionNameInputField.text;
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
        if (PotionCount > 0)
        {
            GameObject gameObject = PotionSelf[potionID];
            PotionSelf[potionID] = null;
            Destroy(gameObject);
            PotionCount--;

            tempPotionSelf = RemoveElementAndSort(PotionSelf, PotionSelf[potionID]);

            PotionSelf = tempPotionSelf;

            PotionSelfRelocate();
        }
    }

    void PotionSelfRelocate()
    {
        for (int i = 0; i < PotionCount; i++)
        {
            PotionSelf[i].transform.position = PotionSelfTransform[i].localPosition;
        }
    }

    public static GameObject[] RemoveElementAndSort(GameObject[] array, GameObject elementToRemove)
    {
        GameObject[] filteredArray = array.Where(go => go != null && go != elementToRemove).ToArray();

        GameObject[] sortedArray = filteredArray.OrderBy(go => go.name).ToArray();

        GameObject[] finalArray = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            if (i < sortedArray.Length)
            {
                finalArray[i] = sortedArray[i];
            }
            else
            {
                finalArray[i] = null;
            }
        }

        return finalArray;
    }

    public void TreatPotion()
    {
        if (Player_Handler.instace.PotionInHand == true)
        {
            if (CurrentNPC.GetComponent<Kust_Marr>().BimariIndex == Player_Handler.instace.PotionId)
            {
                Debug.Log("Patient Treated with potion ID " + Player_Handler.instace.PotionId);
                Player_Handler.instace.PotionInHand = false;
                Player_Handler.instace.PotionId = 0;
                Destroy(CurrentNPC);
                NPConCounter = false;
                DaynightTimer--;
            }
            
        }else { Debug.Log("Nothing in Hand"); }
        
    }

}
