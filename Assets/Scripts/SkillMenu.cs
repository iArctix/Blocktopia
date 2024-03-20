using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillUI : MonoBehaviour
{
    public GameObject skillmenu;
    public GameObject gameplayui;
    public GameObject PlayerCamera;

    //Skill levels
    public TextMeshProUGUI MaxHealthlvl;
    public TextMeshProUGUI Gatherspeedlvl;
    public TextMeshProUGUI Strengthlvl;

    void Update()
    {
        openmenu();

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

}
