using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kust_Marr : MonoBehaviour
{
    public int BimariIndex;
    public string[] AdmiName;

    int NPCState;
    public GameObject StartPos;
    public GameObject EndtPos;
    public GameObject TabposPos;
    public float MoveSpeed;

    public Animator NPCanim;

    // Add materials and mesh array

    public void Start()
    {
        StartPos = MainShop.instance.SpawnTarget;
        TabposPos = MainShop.instance.CounterTarget;
        EndtPos = MainShop.instance.EndTarget;

        AsignNPCProperty();
        NPCState = 1; 
        NPCanim.SetTrigger("talk");

    }

    public void Update()
    {
        NPCMover();transform.LookAt(MainShop.instance.NPCSpawner.transform);
        Debug.Log(NPCState);
    }

    public void NPCMover()
    {
        if (NPCState == 1) // MOVE TO POS2
        {
            transform.position = Vector3.MoveTowards(transform.position, TabposPos.transform.position, MoveSpeed * Time.deltaTime);
            if (transform.position == TabposPos.transform.position)
            {
                 //(new Vector3(0, 176.359009f, 0));
                AssignDialogue();
                NPCState = 2;
            }
        }
        else if (NPCState == 2) // ROTATE 
        {
            NPCanim.SetTrigger("talk");
            
            NPCState = 3;

        }
        else if (NPCState == 3) // Rest
        {
            if (Player_Handler.instace.Treated == 1)
            {
                NPCState = 4;
                CallEndAnim(1);
            }
            else if (Player_Handler.instace.Treated == 2)
            {
                NPCState = 5;
                CallEndAnim(2);
            }
        }
        else if (NPCState == 4) // RUN Animation based on potion
        {
            transform.position = Vector3.MoveTowards(transform.position, EndtPos.transform.position, MoveSpeed * Time.deltaTime);
            if (transform.position == EndtPos.transform.position)
            {
                Destroy(gameObject);
                
            }
        }
        else if (NPCState == 5) // RUN Animation based on potion
        {
            Destroy(gameObject, 3.29f);
            Player_Handler.instace.Treated = 0;
        }
    }

    void CallEndAnim(int i)
    {
        if (i == 1)
        {
            NPCanim.SetTrigger("happy");
        }else if (i == 2)
        {
            NPCanim.SetTrigger("die");
        }
    }

    void AsignNPCProperty()
    {
        BimariIndex = Random.Range(1, 11);
        Debug.Log("NPC Generated with Bimari ID " + BimariIndex);
    }

    void AssignDialogue()
    {
        if (MainShop.instance.DialoguePanel.activeInHierarchy == false)
        {
            MainShop.instance.DialoguePanel.SetActive(true);
        }

        if (BimariIndex == 1)
        {
            Dialogues.instance.Showtext((int)Random.Range(0, 1));
        }
        else if (BimariIndex == 2)
        {
            Dialogues.instance.Showtext((int)Random.Range(2, 3));
        }
        else if (BimariIndex == 3)
        {
            Dialogues.instance.Showtext((int)Random.Range(4, 5));
        }
        else if (BimariIndex == 4)
        {
            Dialogues.instance.Showtext((int)Random.Range(6, 7));
        }
        else if (BimariIndex == 5)
        {
            Dialogues.instance.Showtext((int)Random.Range(8, 9));
        }
        else if (BimariIndex == 6)
        {
            Dialogues.instance.Showtext((int)Random.Range(10, 11));
        }
        else if (BimariIndex == 7)
        {
            Dialogues.instance.Showtext((int)Random.Range(12, 13));
        }
        else if (BimariIndex == 8)
        {
            Dialogues.instance.Showtext((int)Random.Range(14, 15));
        }
        else if (BimariIndex == 9)
        {
            Dialogues.instance.Showtext((int)Random.Range(16, 17));
        }
        else if (BimariIndex == 10)
        {
            Dialogues.instance.Showtext((int)Random.Range(18, 19));
        }
    }


}
