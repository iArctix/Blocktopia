using UnityEngine;

public class BlacksmithMenu : MonoBehaviour
{
    public GameObject gameplayui;
    public GameObject blacksmithui;

    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (blacksmithui.activeSelf)
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
        blacksmithui.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
    void openmenu()
    {
        gameplayui.SetActive(false);
        blacksmithui.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
