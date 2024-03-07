using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New player Data", menuName = "playerstats/playerdata")]
public class Playerstats : ScriptableObject
{
    //Tool Levels
    public int bowlevel = 1;
    public int swordlevel = 1;
    public int pickaxelevel = 1;
    public int axelevel = 1;
    //Playerstats
    public float maxhealth;
    //When player levels they get a skill point to spend on upgrading stats
    public float sworddamagemultiplier = 1;
    public float bowdamagemultipler = 1;
    public int playerlevel = 1;
    public int skillpoints = 0;
    public int playertotalexp;






}
