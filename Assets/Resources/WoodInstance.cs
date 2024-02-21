using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodInstance : MonoBehaviour
{
    public WoodData woodData;

    void Start()
    {
        Debug.Log("Ore Name: " + woodData.woodName);
        Debug.Log("Level Requirement: " + woodData.toollevelrequirement);
        // Instantiate ore model, etc.
    }
}