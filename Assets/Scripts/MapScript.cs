using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    public TextMeshProUGUI AreaInfo;
    public GameObject Town;
    public TextMeshProUGUI towntext;
    public GameObject Forest;
    public TextMeshProUGUI foresttext;
    public GameObject Mountain;
    public TextMeshProUGUI mountaintext;
    public GameObject Graveyard;
    public TextMeshProUGUI graveyardtext;

    public Image mountain;
    public Image graveyard;

    public Playerstats stats;
    
    // Start is called before the first frame update
    void Start()
    {
        AreaInfo.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
       // mountaincheck();
       // graveyardcheck();
    }

    public void mountaincheck()
    {
        if (stats.playerlevel < 10)
        {
          
            mountaintext.color = Color.red;
            mountaintext.text = "Lvl 10 To Unlock ";
            mountain.color = Color.black;
        }
        else
        {
            mountain.color = Color.white;
            mountaintext.color = Color.white;
            mountaintext.text = "Mountain";

        }
    }
    public void graveyardcheck()
    {
        if (stats.playerlevel < 20)
        {

            graveyardtext.color = Color.red;
            graveyardtext.text = "LvL 20 To Unlock ";
            graveyard.color = Color.black;
        }
        else
        {
            graveyardtext.text = "Graveyard";
            graveyard.color= Color.white;
            graveyardtext.color = Color.white;
        }
    }
    public void townbutton()
    {
        SceneManager.LoadScene(1);
    }
    public void ForestButton()
    {
        SceneManager.LoadScene(2);
    }
    public void MountainButton()
    {
        if (stats.playerlevel < 10)
        {
            
        }
        else
        {
            SceneManager.LoadScene(3);
        }
        
    }
    public void GraveyardButton()
    {
        if (stats.playerlevel < 20)
        {
            
        }
        else
        {
            SceneManager.LoadScene(4);
        }
        
    }


    public void townenter()
    {
        mountaincheck();
        graveyardcheck();
        AreaInfo.text = "This area is your home and is safe. Come here to rest rejuvinate and forge better equiptment";
        towntext.color = Color.green;
       
    }
    public void townexit()
    {
     
        AreaInfo.text = " ";
        towntext.color = Color.white;
    }

    public void forestenter()
    {
       
        AreaInfo.text = "The first area a lush woodland with basic resources to gather. Watch out for the creatures some are friendly some are not .";
        foresttext.color = Color.green;
    }
    public void forestexit()
    {
        
        AreaInfo.text = " ";
        foresttext.color = Color.white;
    }

    public void mountainenter()
    {
        if (stats.playerlevel < 10)
        {
            AreaInfo.text = "???????????";
            mountaintext.color = Color.red;
        }
        else
        {
            AreaInfo.text = "This second area is an arid mountainous area. Creatures are more hostile and harder to kill. Resources are scarcer especially wood. Be careful and make sure you are equiped";
            mountaintext.color = Color.green;
        }
        
    }
    public void mountainexit()
    {

        if (stats.playerlevel < 10)
        {
            AreaInfo.text = " ";
            mountaintext.color = Color.red;
        }
        else
        {
            AreaInfo.text = " ";
            mountaintext.color = Color.white;
        }
    }
    public void graveyardenter()
    {
        if (stats.playerlevel < 20)
        {
            AreaInfo.text = "???????????";
            graveyardtext.color = Color.red;
        }
        else
        {
            AreaInfo.text = "The Graveyard is a haunted scary place. All creatures are out to get you and the dark eerie atmosphere makes it worse for you. Watch out they may come sneak up and haunt you.";
            graveyardtext.color = Color.green;
        }
       
    }
    public void graveyardexit()
    {
        if (stats.playerlevel < 10)
        {
            AreaInfo.text = " ";
            graveyardtext.color = Color.red;
        }
        else
        {
            AreaInfo.text = " ";
            graveyardtext.color = Color.white;
        }
    }
}
