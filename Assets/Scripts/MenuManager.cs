using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button ContinueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.GameProg > 0)
        {
            ContinueButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
