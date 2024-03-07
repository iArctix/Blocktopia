using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTotown : MonoBehaviour
{
    public InventoryData inventory;
    // Start is called before the first frame update

    public void Respawn()
    {
        if (inventory.coins > 100) 
        {
            inventory.coins -= 100;
        }
        else
        {
            inventory.coins = 0;
        }

        SceneManager.LoadScene(0);
    }
}
