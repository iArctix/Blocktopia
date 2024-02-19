using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory Data", menuName = "Inventory System/Inventory Data")]
public class InventoryData : ScriptableObject
{
    public int coins;

    //Woods
    public int Oak;
    public int Birch;
    public int Ash;
    public int mahogany;

    //Ores
    public int Copper;
    public int Iron;
    public int silver;
    public int palladium;




}
