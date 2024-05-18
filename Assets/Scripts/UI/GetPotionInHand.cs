using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPotionInHand : MonoBehaviour
{
    [SerializeField] int Index;
    GameObject NewPotion;

    private void LateUpdate()
    {
        if (MainShop.instance.PotionSelf[Index] != null)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void OnClickHandID()
    {
        NewPotion = MainShop.instance.PotionSelf[Index];
        Player_Handler.instace.PotionInHand = true;
        Player_Handler.instace.PotionId = NewPotion.GetComponent<PotionComponent>().CreatedPotionID;
    }
}
