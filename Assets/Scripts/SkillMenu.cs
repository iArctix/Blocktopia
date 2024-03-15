using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    public GameObject skillmenu;
    public GameObject gameplayui;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !skillmenu.activeSelf)
        {
            skillmenu.SetActive(true);
            gameplayui.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.P) && skillmenu.activeSelf)
        {
            skillmenu.SetActive(false);
            gameplayui.SetActive(true);
        }

    }
}
