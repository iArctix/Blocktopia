using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUI : MonoBehaviour
{
    public GameObject helpmenu;
    public GameObject gameplayui;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !helpmenu.activeSelf)
        {
            helpmenu.SetActive(true);
            gameplayui.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.H) && helpmenu.activeSelf)
        {
            helpmenu.SetActive(false);
            gameplayui.SetActive(true);
        }

    }
}
