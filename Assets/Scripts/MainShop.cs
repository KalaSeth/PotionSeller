using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject NEWdAY;

    public int Rating;
    public Text RatingText;
    public GameObject RatingG;
    public GameObject RatingD;
    public GameObject MainCanvas;

    public GameObject DialoguePanel;
    public Button Kitchen;

    // Panels
    public GameObject Pstate1;



    // NPC
    public float SpawnDelayTimer;
    public bool NPConCounter;
    public GameObject CurrentNPC;
    public GameObject NPC_Prefab;
    public GameObject NPCMouth_Prefab;
    public GameObject NPCSpawner;
    public GameObject SpawnTarget;
    public GameObject CounterTarget;
    public GameObject EndTarget;

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
        RatingText.text = Rating.ToString() + " Stars";
        if (CurrentNPC == null)
        {
            Kitchen.interactable = false;
        }
        else Kitchen.interactable = true;

        if (DaynightTimer >= 0)
        {
           
            if (NPConCounter == false)
            {
                SpawnDelayTimer -= Time.deltaTime;
                
                if (SpawnDelayTimer <= 0)
                {
                    NPCChainer();
                    SpawnDelayTimer = Random.Range(8, 12);
                }
            }
        }else if (DaynightTimer <= 0)
        {
            if (DayNightIndex == 4)
            {
                CutcseneShow(1);
            }
            DayNightIndex++;
            Instantiate(NEWdAY, transform.position, transform.rotation, MainCanvas.transform);
            GameManager.instance.GameProg++;
            DaynightTimer = Random.Range(4, 6);
        }

        if (Rating <= 0)
        {
            CutcseneShow(2);
        }
        
    }

    public void CutcseneShow(int i)
    {
        GameManager.instance.GameDone = i;
        SceneManager.LoadScene(2);
    }

    public void NPCChainer()
    {
        GameObject gameObject = Instantiate(NPC_Prefab, SpawnTarget.transform.position, SpawnTarget.transform.rotation, SpawnTarget.transform);
        CurrentNPC = gameObject;
        NPConCounter = true;

    }


    public void OncClickCreatePotion()
    {
        potionSelfTransformIndex = PotionCount;

        if (PotionCount < 10)
        {
            GameObject newPotion = Instantiate(PotionPrefab, PotionSelfTransform[potionSelfTransformIndex].position, PotionSelfTransform[potionSelfTransformIndex].rotation, PotionParent).gameObject;

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
            PotionSelf[i].transform.position = PotionSelfTransform[i].position;
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
    public void BoxTreat()
    {
        if (Player_Handler.instace.PotionInHand == true)
        {
            Player_Handler.instace.PlayerState = 0;
            if (Pstate1.activeInHierarchy == false)
            {
                Pstate1.gameObject.SetActive(true);
            }

            Player_Handler.instace.PotionInHand = false;
            Player_Handler.instace.PotionId = 0;
            Player_Handler.instace.Treated = 2;
            DialoguePanel.gameObject.SetActive(false);
            NPConCounter = false;
            DaynightTimer--;
            Rating--;
            Instantiate(RatingD, transform.position, transform.rotation, MainCanvas.transform);
        }
    }
    public void TreatPotion()
    {
        if (Player_Handler.instace.PotionInHand == true)
        {
            Player_Handler.instace.PlayerState = 0;
            if (Pstate1.activeInHierarchy == false)
            {
                Pstate1.gameObject.SetActive(true);
            }
            
            if (CurrentNPC.GetComponent<Kust_Marr>().BimariIndex == Player_Handler.instace.PotionId)
            {
                Debug.Log("Patient Treated with potion ID " + Player_Handler.instace.PotionId);
                Player_Handler.instace.PotionInHand = false;
                Player_Handler.instace.PotionId = 0;
                Player_Handler.instace.Treated = 1;
                DialoguePanel.gameObject.SetActive(false);
                NPConCounter = false;
                DaynightTimer--;
                Rating++;
                Instantiate(RatingG, transform.position, transform.rotation, MainCanvas.transform);
            }
            else if (CurrentNPC.GetComponent<Kust_Marr>().BimariIndex != Player_Handler.instace.PotionId)
            {
                Debug.Log("Patient Treated with potion ID " + Player_Handler.instace.PotionId);
                Player_Handler.instace.PotionInHand = false;
                Player_Handler.instace.PotionId = 0;
                Player_Handler.instace.Treated = 2;
                DialoguePanel.gameObject.SetActive(false);
                NPConCounter = false;
                DaynightTimer--;
                Rating--;
                Instantiate(RatingD, transform.position, transform.rotation, MainCanvas.transform);
            }
        }
        else 
        {
            Debug.Log("Nothing in Hand");
        }
        
    }

}
