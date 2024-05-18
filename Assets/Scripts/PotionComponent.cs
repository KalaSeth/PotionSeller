using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionComponent : MonoBehaviour
{
    public string PotionName;
    public Text PotionNameText;

    // if left 0 = no item, 
    public int[] Item;
    public int ItemIndex;

    /// <summary>
    /// Potion IDs
    ///  id  Item              Cure            Side Effect
    ///  0 = nill             nill              nill
    ///  1 = 0                Weakness
    ///  2 = 0, 1             Cold
    ///  3 = 0, 2             Gas
    ///  4 = 1, 2             BodyPain
    ///  5 = 1, 3             Loose Motion
    ///  6 = 3, 4, 5          Hiccup
    ///  7 = 1, 2, 6          Migrane
    ///  8 = 2, 5, 6          Pimples
    ///  9 = 0, 2, 4, 5, 6    Itching
    /// 10 = 1, 3, 4, 5, 6    Eye Sight
    ///  
    /// 20 = 0, 1, 2                            Extreme Vomit
    /// 21 = 0, 1, 2, 3, 4, 5, 6                Death
    /// 22 = 0, 4                               Dizzyness
    /// 23 = 1                                  Blindness
    /// 24 = 4                                  Loose Motion
    /// 25 = 5                                  Gas
    /// 
    /// 30 = Random Items                       Feeling Bad
    /// 
    /// </summary>
    
    public int CreatedPotionID; // 0 = nill

    public void CreatePotion()
    {
        for (ItemIndex = 0; ItemIndex < 7; ItemIndex++)
        {
            Item[ItemIndex] = (int)MainShop.instance.ItemSlider[ItemIndex].value;
        }
        MixingPotion();
    }

    void MixingPotion()
    {
        #region ID_Checks
        // Cure

        if (Item[0] == 1 && Item[1] == 0 && Item[2] == 0 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Weakness
            CreatedPotionID = 1;
        }
        else if (Item[0] == 1 && Item[1] == 1 && Item[2] == 0 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Cold
            CreatedPotionID = 2;
        }
        else if (Item[0] == 1 && Item[1] == 0 && Item[2] == 1 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Gas
            CreatedPotionID = 3;
        }
        else if (Item[0] == 0 && Item[1] == 1 && Item[2] == 1 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //BodyPain
            CreatedPotionID = 4;
        }
        else if (Item[0] == 0 && Item[1] == 1 && Item[2] == 0 && Item[3] == 1 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Loose Motion
            CreatedPotionID = 5;
        }
        else if (Item[0] == 0 && Item[1] == 0 && Item[2] == 0 && Item[3] == 1 && Item[4] == 1 && Item[5] == 1 && Item[6] == 0)
        {
            //Hiccup
            CreatedPotionID = 6;
        }
        else if (Item[0] == 0 && Item[1] == 1 && Item[2] == 1 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 1)
        {
            //Migrane
            CreatedPotionID = 7;
        }
        else if (Item[0] == 0 && Item[1] == 0 && Item[2] == 1 && Item[3] == 0 && Item[4] == 0 && Item[5] == 1 && Item[6] == 1)
        {
            //Pimples
            CreatedPotionID = 8;
        }
        else if (Item[0] == 1 && Item[1] == 0 && Item[2] == 1 && Item[3] == 0 && Item[4] == 1 && Item[5] == 1 && Item[6] == 1)
        {
            //Itching
            CreatedPotionID = 9;
        }
        else if (Item[0] == 0 && Item[1] == 1 && Item[2] == 0 && Item[3] == 1 && Item[4] == 1 && Item[5] == 1 && Item[6] == 1)
        {
            //Eye Sight
            CreatedPotionID = 10;
        }

        // Side Effects

        else if (Item[0] == 1 && Item[1] == 1 && Item[2] == 1 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Extreme Vomit
            CreatedPotionID = 20;
        }
        else if (Item[0] == 1 && Item[1] == 1 && Item[2] == 1 && Item[3] == 1 && Item[4] == 1 && Item[5] == 1 && Item[6] == 1)
        {
            //Death
            CreatedPotionID = 21;
        }
        else if (Item[0] == 1 && Item[1] == 0 && Item[2] == 0 && Item[3] == 0 && Item[4] == 1 && Item[5] == 0 && Item[6] == 0)
        {
            //Dizzyness
            CreatedPotionID = 22;
        }
        else if (Item[0] == 0 && Item[1] == 1 && Item[2] == 0 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Blindness
            CreatedPotionID = 23;
        }
        else if (Item[0] == 0 && Item[1] == 0 && Item[2] == 0 && Item[3] == 0 && Item[4] == 1 && Item[5] == 0 && Item[6] == 0)
        {
            //Loose Motion
            CreatedPotionID = 24;
        }
        else if (Item[0] == 0 && Item[1] == 0 && Item[2] == 0 && Item[3] == 0 && Item[4] == 0 && Item[5] == 1 && Item[6] == 0)
        {
            //Gas
            CreatedPotionID = 25;
        }

        // Else

        else if (Item[0] == 0 && Item[1] == 0 && Item[2] == 0 && Item[3] == 0 && Item[4] == 0 && Item[5] == 0 && Item[6] == 0)
        {
            //Gas
            CreatedPotionID = 0;
        }

        else
        {
            CreatedPotionID = 30;
        }
        #endregion

        //Debug.Log(CreatedPotionID);
    }
}
