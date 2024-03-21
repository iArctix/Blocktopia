using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public float currenthealth;
    //When player levels they get a skill point to spend on upgrading stats
    public float playerlevel = 1;
    public int skillpoints = 0;
    public int playertotalexp;

    //Skills
    public int HealthLevel;
    public int GatherSpeedLevel;
    public int Strengthlevel;

    void Update()
    { 
       

    }




}
