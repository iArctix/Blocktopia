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
    }



}
