using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCreationCheck : MonoBehaviour
{
    private InputField Potionname;
    [SerializeField] private Button CreateButt;
    int Count;
    private void Start()
    {
        Potionname = GetComponent<InputField>();
    }

    public void LateUpdate()
    {
        NameCheck();
    }

    void NameCheck()
    {
        if (Potionname.textComponent.text.Length < 3)
        {
            
            CreateButt.interactable = false;
        }else if (Potionname.textComponent.text.Length > 2)
        {
            CreateButt.interactable = true;
        }
    }
}
