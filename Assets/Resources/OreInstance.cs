using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OreInstance : MonoBehaviour
{
    public OreData oreData;

    void Start()
    {
        Debug.Log("Ore Name: " + oreData.oreName);
        Debug.Log("Level Requirement: " + oreData.toollevelrequirement);
    }
}