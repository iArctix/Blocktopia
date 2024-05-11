using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    
    // Start is called before the first frame update
    void Start()
    {
        AreaInfo.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene(3);
    }
    public void GraveyardButton()
    {
        SceneManager.LoadScene(4);
    }


    public void townenter()
    {
       
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
       
        AreaInfo.text = "The first area a lush woodland with basic resources to gather. Watch out for the creatures some are friendly some are not and try your best to beat the areas boss.";
        foresttext.color = Color.green;
    }
    public void forestexit()
    {
        
        AreaInfo.text = " ";
        foresttext.color = Color.white;
    }

    public void mountainenter()
    {

        AreaInfo.text = "This second area is an arid mountainous area. CReatures are more hostile and harder to kill. Resources are scarcer especially wood. Be careful and make sure you are equiped";
        mountaintext.color = Color.green;
    }
    public void mountainexit()
    {

        AreaInfo.text = " ";
        mountaintext.color = Color.white;
    }
    public void graveyardenter()
    {

        AreaInfo.text = "The Graveyard is a haunted scary place. All creatures are out to get you and the dark eerie atmosphere makes it worse for you. Watch out they may come sneak up and haunt you.";
        graveyardtext.color = Color.green;
    }
    public void graveyardexit()
    {

        AreaInfo.text = " ";
        graveyardtext.color = Color.white;
    }
}
