using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Handler : MonoBehaviour
{
    public static Player_Handler instace;

    public int PlayerState; // 0 = ShopCounter, 1 = Kitchen, 2 = Serve, 3 = BjMode

    public GameObject PlayerCam;

    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerCamState(int state)
    {

    }

    
}
