using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillUI : MonoBehaviour
{
    public GameObject skillmenu;
    public GameObject gameplayui;
    public GameObject PlayerCamera;
    public Playerstats stats;

    //Skill levels
    public TextMeshProUGUI MaxHealthlvl;
    public TextMeshProUGUI Gatherspeedlvl;
    public TextMeshProUGUI Strengthlvl;
    public TextMeshProUGUI SkillPoints;

    

    void Update()
    {
        openmenu();
        uiupdate();

    }

    public void openmenu()
    {
        if (Input.GetKeyDown(KeyCode.P) && !skillmenu.activeSelf)
        {
            skillmenu.SetActive(true);
            gameplayui.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            PlayerCamera.GetComponent<CameraRotation>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && skillmenu.activeSelf)
        {
            skillmenu.SetActive(false);
            gameplayui.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            PlayerCamera.GetComponent<CameraRotation>().enabled = true;
        }
    }

    public void uiupdate()
    {
        MaxHealthlvl.text = "Level: " + stats.HealthLevel;
        Gatherspeedlvl.text = "Level " + stats.GatherSpeedLevel;
        Strengthlvl.text = "Level " + stats.Strengthlevel;
        SkillPoints.text = "Skill Points : " + stats.skillpoints;
    }
    public void healthplus()
    {
        if(stats.skillpoints > 0)
        {
            stats.skillpoints -= 1;
            stats.HealthLevel += 1;
        }
    }
    public void healthminus()
    {
        if(stats.HealthLevel > 0)
        {
            stats.skillpoints += 1;
            stats.HealthLevel -= 1;
        }
    }

    public void gatherplus()
    {
        stats.skillpoints -= 1;
        stats.GatherSpeedLevel += 1;
    }
    public void gatherminus()
    {
        stats.skillpoints += 1;
        stats.GatherSpeedLevel -= 1;
    }
    public void strengthplus()
    {
        stats.skillpoints -= 1;
        stats.Strengthlevel += 1;
    }
    public void strengthminus()
    {
        stats.skillpoints += 1;
        stats.Strengthlevel -= 1;
    }

}

