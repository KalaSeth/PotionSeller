using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Handler : MonoBehaviour
{
    public static Player_Handler instace;

    public int PlayerState; // 0 = ShopCounter, 1 = Kitchen, 2 = Self, 3 = BjMode

    public bool PotionInHand;
    public int PotionId;
    public bool Dropped;
    public int Treated; // 0 = NA, 1 = Treated, 2 = Dead

    public GameObject PlayerHandMesh;
    public GameObject PotionTransform;
    public GameObject[] PotionViel;
    GameObject CurrPotion;
    [SerializeField] float HandMoveSpeed;

    public GameObject CameraObj;
    public Transform[] CamTransform; // 0 = ShopCounter, 1 = Kitchen, 2 Self, 3 = BjMode
    public Vector3[] Campos;
    int CamTransformIndex;
    [SerializeField] float CamMoveSpeed;

    public Button TreatButt;

    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Campos[0] = new Vector3(0.00820000004f, 0.0557000004f, -0.065200001f);
        Campos[1] = new Vector3(15.6129999f, 0.0557000004f, -0.065200001f);
        Campos[2] = new Vector3(42.1707993f, 0.0557000004f, -0.38499999f);
        Campos[3] = new Vector3(58.5789986f, 0.0557000004f, -0.38499999f);

        CameraObj = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CamMovetoPos(PlayerState);
        if (PotionInHand == true)
        {
            TreatButt.interactable = true;
        }
        else if (PotionInHand == false) 
        { 
            TreatButt.interactable = false; 
        }

        if (PlayerState == 3)
        {
            LandPotion();
        }
    }

    public void CamMovetoPos(int i)
    {
        CameraObj.transform.position = new Vector3(Mathf.Lerp(CameraObj.transform.position.x, Campos[i].x, CamMoveSpeed), Mathf.Lerp(CameraObj.transform.position.y, Campos[i].y, CamMoveSpeed), Mathf.Lerp(CameraObj.transform.position.z, Campos[i].z, CamMoveSpeed));
    }
    
    public void DropCheck()
    {
        Dropped = false;
    }

    public void PlayerCamState(int state)
    {
        PlayerState = state;
        if (state == 0)
        {
           
        }
        else if (state == 1)
        {

        }
        else if (state == 2)
        {

        }
        else if (state == 3)
        {
           // LandPotion();
        }
        else if (state == 4)
        {
          
        }
    }

    public void LandPotion()
    {
        float hor = Input.GetAxis("Horizontal");

        PotionTransform.transform.localPosition += Vector3.right * hor * HandMoveSpeed * Time.deltaTime;

        PotionTransform.transform.localPosition = new Vector3(Mathf.Clamp(PotionTransform.transform.localPosition.x, -0.04f, 0.13f), PotionTransform.transform.localPosition.y, PotionTransform.transform.localPosition.z);


        if (Dropped == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CurrPotion.GetComponent<Rigidbody>().useGravity = true;
         
            }
        }
    }

    public void PotionspawninHand()
    {
        if (PotionTransform.transform.childCount > 0)
        {
            Destroy(PotionTransform.transform.GetChild(0).gameObject);
        }

        if (PotionId == 1)
        {
           CurrPotion = Instantiate(PotionViel[0], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 2)
        {
            CurrPotion = Instantiate(PotionViel[1], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 3)
        {
            CurrPotion = Instantiate(PotionViel[2], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 4)
        {
            CurrPotion = Instantiate(PotionViel[3], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 5)
        {
            CurrPotion = Instantiate(PotionViel[4], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 6)
        {
            CurrPotion = Instantiate(PotionViel[5], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 7)
        {
            CurrPotion = Instantiate(PotionViel[6], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 8)
        {
            CurrPotion = Instantiate(PotionViel[7], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 9)
        {
            CurrPotion = Instantiate(PotionViel[8], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 10)
        {
            CurrPotion = Instantiate(PotionViel[9], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 20)
        {
            CurrPotion = Instantiate(PotionViel[10], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 21)
        {
            CurrPotion = Instantiate(PotionViel[11], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 22)
        {
            CurrPotion = Instantiate(PotionViel[10], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 23)
        {
            CurrPotion = Instantiate(PotionViel[10], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 24)
        {
            CurrPotion = Instantiate(PotionViel[10], PotionTransform.transform.position, PotionTransform.transform.localRotation, PotionTransform.transform);
        }
        else if (PotionId == 25)
        {
            CurrPotion = Instantiate(PotionViel[10], PotionTransform.transform.position, PotionTransform.transform.rotation, PotionTransform.transform);
        }
        else if (PotionId == 30)
        {
            CurrPotion = Instantiate(PotionViel[12], PotionTransform.transform.position, PotionTransform.transform.rotation, PotionTransform.transform);
        }
        else if (PotionId == 0)
        {
            CurrPotion = Instantiate(PotionViel[12], PotionTransform.transform.position, PotionTransform.transform.rotation, PotionTransform.transform);
        }
    }
    
}
