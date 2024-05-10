using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNumber : MonoBehaviour
{
    public TextMeshProUGUI level;
    public Playerstats playerstats;
    // Update is called once per frame
    void Update()
    {
        level.text = "Level: " + playerstats.playerlevel.ToString();
    }
}
