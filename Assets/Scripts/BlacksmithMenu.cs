using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlacksmithMenu : MonoBehaviour
{
    public Playerstats stats;
    public InventoryData inventory;
    public int currenttool;  // 1. Bow  2. Sword  3.Pick 4.Axe
    public Image tool;
    public Sprite bowimg;
    public Sprite swordimg;
    public Sprite pickaxeimg;
    public Sprite axeimg;
    public GameObject bowarrow;
    public GameObject swordarrow;
    public GameObject pickaxearrow;
    public GameObject axearrow;


    public TextMeshProUGUI Toolinfo;
    public TextMeshProUGUI Oreneeded;
    public TextMeshProUGUI Woodneeded;
    public TextMeshProUGUI coinsneeded;

    

    public 
    
    void Start()
    {
        currenttool = 1;
        bowarrow.SetActive(true);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        selectedtool(); 
    }

    public void bowbutton()
    {
        currenttool = 1;
    }
    public void swordbutton()
    {
        currenttool = 2;
    }
    public void pickaxebutton()
    {
        currenttool = 3;
    }
    public void Axebutton()
    {
        currenttool = 4;
    }
    

    void selectedtool()
    {
        if (currenttool == 1) 
        {
            bow();
        }
        else if (currenttool == 2)
        {
            sword();
        }
        else if (currenttool == 3)
        {
            pickaxe();
        }
        else if (currenttool == 4)
        {
            axe();
        }
    }
    void bow()
    {
        //Selecting UI
        tool.sprite = bowimg;
        bowarrow.SetActive(true);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(false);
        //Info
        Toolinfo.text = " The bow should be used for ranged combat. Its Current Level is  " + stats.bowlevel;

        if(stats.bowlevel == 1)
        {
            Oreneeded.text = "Copper Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Oak Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.bowlevel == 2)
        {
            Oreneeded.text = "Gold Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Birch Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if(stats.bowlevel == 3)
        {
            Oreneeded.text = "Titanium Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Ash Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if(stats.bowlevel == 4)
        {
            Oreneeded.text = "Max Level";
            Woodneeded.text = "Max Level";
            coinsneeded.text = "Max Level";
        }
    }
    void sword()
    {
        //Selecting UI
        tool.sprite = swordimg;
        bowarrow.SetActive(false);
        swordarrow.SetActive(true);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(false);
        //Info
        Toolinfo.text = " The sword should be used for melee combat its current level is" + stats.swordlevel;

        if (stats.swordlevel == 1)
        {
            Oreneeded.text = "Copper Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Oak Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.swordlevel == 2)
        {
            Oreneeded.text = "Gold Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Birch Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.swordlevel == 3)
        {
            Oreneeded.text = "Titanium Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Ash Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.swordlevel == 4)
        {
            Oreneeded.text = "Max Level";
            Woodneeded.text = "Max Level";
            coinsneeded.text = "Max Level";
        }

    }
    void axe()
    {
        //Selecting UI
        tool.sprite = axeimg;
        bowarrow.SetActive(false);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(true);
        //Info
        Toolinfo.text = " The axe can chop down certain trees for resources the current tier is  " + stats.axelevel;

        if (stats.axelevel == 1)
        {
            Oreneeded.text = "Copper Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Oak Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.axelevel == 2)
        {
            Oreneeded.text = "Gold Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Birch Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.axelevel == 3)
        {
            Oreneeded.text = "Titanium Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Ash Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.axelevel == 4)
        {
            Oreneeded.text = "Max Level";
            Woodneeded.text = "Max Level";
            coinsneeded.text = "Max Level";
        }
    }
    void pickaxe()
    {
        //Selecting UI
        tool.sprite = pickaxeimg;
        bowarrow.SetActive(false);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(true);
        axearrow.SetActive(false);
        //Info
        Toolinfo.text = " The pickaxe can mine certain ores for resources the current tier is  " + stats.pickaxelevel;

        if (stats.pickaxelevel == 1)
        {
            Oreneeded.text = "Copper Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Oak Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.pickaxelevel == 2)
        {
            Oreneeded.text = "Gold Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Birch Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.pickaxelevel == 3)
        {
            Oreneeded.text = "Titanium Required " + inventory.Copper + " / " + "20";
            Woodneeded.text = " Ash Required " + inventory.Oak + " / " + "20";
            coinsneeded.text = " Coins Required " + inventory.coins + " / " + "200";
        }
        else if (stats.pickaxelevel == 4)
        {
            Oreneeded.text = "Max Level";
            Woodneeded.text = "Max Level";
            coinsneeded.text = "Max Level";
        }
    }

    public void upgradebutton()
    {
        if (currenttool == 1)
        {
            if (stats.bowlevel == 1)
            {
                if(inventory.Copper >= 20 && inventory.Oak >= 20 && inventory.coins >= 200)
                {
                    stats.bowlevel++;
                    inventory.Copper -= 20;
                    inventory.Oak -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.bowlevel == 2)
            {
                if (inventory.gold >= 20 && inventory.Birch >= 20 && inventory.coins >= 200)
                {
                    stats.bowlevel++;
                    inventory.gold -= 20;
                    inventory.Birch -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.bowlevel == 3)
            {
                if (inventory.titanium >= 20 && inventory.Ash >= 20 && inventory.coins >= 200)
                {
                    stats.bowlevel++;
                    inventory.titanium -= 20;
                    inventory.Ash -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.bowlevel == 4)
            {
                Debug.Log("Max Level");
            }
        }
        else if (currenttool == 2)
        {
            if (stats.swordlevel == 1)
            {
                if (inventory.Copper >= 20 && inventory.Oak >= 20 && inventory.coins >= 200)
                {
                    stats.swordlevel++;
                    inventory.Copper -= 20;
                    inventory.Oak -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.swordlevel == 2)
            {
                if (inventory.gold >= 20 && inventory.Birch >= 20 && inventory.coins >= 200)
                {
                    stats.swordlevel++;
                    inventory.gold -= 20;
                    inventory.Birch -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.swordlevel == 3)
            {
                if (inventory.titanium >= 20 && inventory.Ash >= 20 && inventory.coins >= 200)
                {
                    stats.swordlevel++;
                    inventory.titanium -= 20;
                    inventory.Ash -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.swordlevel == 4)
            {
                Debug.Log("Max Level");
            }
        }
        else if (currenttool == 3)
        {
            if (stats.pickaxelevel == 1)
            {
                if (inventory.Copper >= 20 && inventory.Oak >= 20 && inventory.coins >= 200)
                {
                    stats.pickaxelevel++;
                    inventory.Copper -= 20;
                    inventory.Oak -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.pickaxelevel == 2)
            {
                if (inventory.gold >= 20 && inventory.Birch >= 20 && inventory.coins >= 200)
                {
                    stats.pickaxelevel++;
                    inventory.gold -= 20;
                    inventory.Birch -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.pickaxelevel == 3)
            {
                if (inventory.titanium >= 20 && inventory.Ash >= 20 && inventory.coins >= 200)
                {
                    stats.pickaxelevel++;
                    inventory.titanium -= 20;
                    inventory.Ash -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.pickaxelevel == 4)
            {
                Debug.Log("Max Level");
            }
        }
        else if (currenttool == 4)
        {
            if (stats.axelevel == 1)
            {
                if (inventory.Copper >= 20 && inventory.Oak >= 20 && inventory.coins >= 200)
                {
                    stats.axelevel++;
                    inventory.Copper -= 20;
                    inventory.Oak -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.axelevel == 2)
            {
                if (inventory.gold >= 20 && inventory.Birch >= 20 && inventory.coins >= 200)
                {
                    stats.axelevel++;
                    inventory.gold -= 20;
                    inventory.Birch -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.axelevel == 3)
            {
                if (inventory.titanium >= 20 && inventory.Ash >= 20 && inventory.coins >= 200)
                {
                    stats.axelevel++;
                    inventory.titanium -= 20;
                    inventory.Ash -= 20;
                    inventory.coins -= 200;
                }
            }
            else if (stats.axelevel == 4)
            {
                Debug.Log("Max Level");
            }
        }
    }
    


}
