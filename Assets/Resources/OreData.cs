using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Ore")]
public class OreData : ScriptableObject
{
    public int toollevelrequirement;
    public Resourcename Resource = Resourcename.Copper;

    public enum Resourcename
    {
        Copper,
        Gold,
        Titanium,
        Tungsten
    }

}