using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject gameplayui;
    public GameObject otherui;
    public GameObject PlayerCamera;

    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (otherui.activeSelf)
            {
                closemenu();
            }
            else
            {
                openmenu();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            closemenu();

        }
    }

    void closemenu()
    {
        gameplayui.SetActive(true);
        otherui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCamera.GetComponent<CameraRotation>().enabled = true;

    }
    void openmenu()
    {
        gameplayui.SetActive(false);
        otherui.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        PlayerCamera.GetComponent<CameraRotation>().enabled = false;
    }
}
