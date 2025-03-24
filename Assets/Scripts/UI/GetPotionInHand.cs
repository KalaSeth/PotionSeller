using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPotionInHand : MonoBehaviour
{
    [SerializeField] int Index;
    GameObject NewPotion;

    [SerializeField] private Button DeleteButt;

    private void LateUpdate()
    {
        if (MainShop.instance.PotionSelf[Index] != null)
        {
            gameObject.GetComponent<Button>().interactable = true;
            DeleteButt.interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
            DeleteButt.interactable = false;
        }
    }

    public void OnClickHandID()
    {
        NewPotion = MainShop.instance.PotionSelf[Index];
        Player_Handler.instace.PotionInHand = true;
        Player_Handler.instace.PotionId = NewPotion.GetComponent<PotionComponent>().CreatedPotionID;
        Debug.Log(Index);
    }
}
