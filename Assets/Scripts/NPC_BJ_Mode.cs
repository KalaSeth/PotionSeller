using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BJ_Mode : MonoBehaviour
{
    /// <summary>
    /// 0 = No movement
    /// 1 = Left right
    /// 2 = Up down 
    /// 3 = Gass from mouth
    /// </summary>
    int MountState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Potion")
        {
            MainShop.instance.TreatPotion();
        }
    }
}
