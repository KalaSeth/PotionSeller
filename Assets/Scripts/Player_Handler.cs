using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Handler : MonoBehaviour
{
    public static Player_Handler instace;

    public int PlayerState; // 0 = ShopCounter, 1 = Kitchen, 2 = Self, 3 = BjMode

    public bool PotionInHand;
    public int PotionId;

    public GameObject PlayerHandMesh;
    public GameObject PotionViel;
    [SerializeField] float HandMoveSpeed;

    public GameObject CameraObj;
    public Transform[] CamTransform; // 0 = ShopCounter, 1 = Kitchen, 2 Self, 3 = BjMode
    int CamTransformIndex;
    [SerializeField] float CamMoveSpeed;

    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraObj = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CamMovetoPos(PlayerState);
        LandPotion();
    }

    public void CamMovetoPos(int i)
    {
        CameraObj.transform.position = new Vector3(Mathf.Lerp(CameraObj.transform.position.x, CamTransform[i].transform.localPosition.x, CamMoveSpeed), Mathf.Lerp(CameraObj.transform.position.y, CamTransform[i].transform.localPosition.y, CamMoveSpeed), Mathf.Lerp(CameraObj.transform.position.z, CamTransform[i].transform.localPosition.z, CamMoveSpeed));
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

        }
        else if (state == 4)
        {

        }

    }

    public void LandPotion()
    {
        float hor = Input.GetAxis("Horizontal");

        PlayerHandMesh.transform.position += Vector3.right * hor * HandMoveSpeed * Time.deltaTime;
    }
    
}
