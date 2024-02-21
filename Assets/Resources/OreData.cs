using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Ore")]
public class OreData : ScriptableObject
{
    public string oreName;
    public GameObject oreModel;
    public int toollevelrequirement;
}