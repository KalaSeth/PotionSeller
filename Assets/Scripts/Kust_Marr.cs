using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kust_Marr : MonoBehaviour
{
    public int BimariIndex;
    public string[] AdmiName;

    // Add materials and mesh array

    private void Start()
    {
        AsignNPCProperty();
    }

    void AsignNPCProperty()
    {
        BimariIndex = Random.Range(0, 11);
        Debug.Log("NPC Generated with Bimari ID " + BimariIndex);
    }


}
