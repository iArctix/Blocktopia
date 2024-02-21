using UnityEngine;

[CreateAssetMenu(fileName = "New Wood", menuName = "Wood")]
public class WoodData : ScriptableObject
{
    public string woodName;
    public GameObject woodModel;
    public int toollevelrequirement;
}