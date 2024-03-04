using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryui;
    public GameObject gameplayui;

    public TextMeshProUGUI Bow;
    public TextMeshProUGUI Sword;
    public TextMeshProUGUI Pick;
    public TextMeshProUGUI Axe;

    public TextMeshProUGUI Coins;

    public TextMeshProUGUI Copper;
    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Titanium;

    public TextMeshProUGUI Oak;
    public TextMeshProUGUI Birch;
    public TextMeshProUGUI Ash;

    public InventoryData inv;
    public Playerstats stats;
    
        
    void Update()
    {
        Bow.text = "Lev " + stats.bowlevel;
        Sword.text ="Lev " + stats.swordlevel;
        Pick.text = "Lev " + stats.pickaxelevel;
        Axe.text ="Lev " + stats.axelevel;

        Coins.text = inv.coins.ToString();

        Copper.text = inv.Copper.ToString();
        Gold.text = inv.gold.ToString();
        Titanium.text = inv.titanium.ToString();

        Oak.text = inv.Oak.ToString();
        Birch.text = inv.Birch.ToString();
        Ash.text = inv.Ash.ToString();

        if (Input.GetKeyDown(KeyCode.I) && !inventoryui.activeSelf)
        {
            inventoryui.SetActive(true);
            gameplayui.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.I) && inventoryui.activeSelf)
        {
            inventoryui.SetActive(false);
            gameplayui.SetActive(true);
        }


    }
}
