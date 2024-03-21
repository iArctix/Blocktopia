using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLeveling : MonoBehaviour
{
    public Playerstats playerstats; 
    public int xpPerLevel = 100; 

    private void Start()
    {
       
    }

    private void Update()
    {
        
    }


    public void CheckForLevelUp(int xpGained)
    {

        Debug.Log("XP: " + playerstats.playertotalexp + " + " + xpGained);

        float remainderxp;

        if (playerstats.playerlevel < 1)
        {
            remainderxp = playerstats.playertotalexp;
        }
        else
        {
            remainderxp = playerstats.playertotalexp - (100 * playerstats.playerlevel);
        }

        remainderxp += xpGained;
        playerstats.playertotalexp += xpGained;

        Debug.Log("Rem " + remainderxp);

        if (remainderxp >= 100)
        {
            Debug.Log("LEVEL UP");
           
        }
        else
        {
            Debug.Log("SAME LEVEL");
            
        }





    }

   
    private void LevelUp()
    {
        playerstats.playerlevel++;
        playerstats.skillpoints++;
    }

  
}