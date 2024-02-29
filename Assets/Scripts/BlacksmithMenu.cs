using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        tool.sprite = bowimg;
        bowarrow.SetActive(true);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(false);
    }
    void sword()
    {
        tool.sprite = swordimg;
        bowarrow.SetActive(false);
        swordarrow.SetActive(true);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(false);
    }
    void axe()
    {
        tool.sprite = axeimg;
        bowarrow.SetActive(false);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(false);
        axearrow.SetActive(true);
    }
    void pickaxe()
    {
        tool.sprite = pickaxeimg;
        bowarrow.SetActive(false);
        swordarrow.SetActive(false);
        pickaxearrow.SetActive(true);
        axearrow.SetActive(false);
    }



}
