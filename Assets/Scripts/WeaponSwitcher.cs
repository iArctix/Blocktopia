using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons; // Array of weapon game objects
    private int currentWeaponIndex = 0; // Index of the currently active weapon

    //used for icons and crosshairs etc
    public GameObject swordicon;
    public GameObject bowicon;
    public GameObject pickicon;
    public GameObject axeicon;
    public GameObject sword;
    public GameObject bow;
    public GameObject pick;
    public GameObject axe;
    public Image crosshair;
    public Sprite bowpic;
    public Sprite swordpic;
    public Sprite toolpic;


    void Start()
    {
        
        SetActiveWeapon(currentWeaponIndex);

        swordicon.SetActive(true);
        bowicon.SetActive(false);
        axeicon.SetActive(false);
        pickicon.SetActive(false);
        crosshair.sprite = swordpic;
    }

    void Update()
    {
        // Check for input to switch weapons using number keys
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weapons.Length >= 2)
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && weapons.Length >= 3)
        {
            SwitchWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && weapons.Length >= 4)
        {
            SwitchWeapon(3);
        }

        // Check for input to switch weapons using scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            // Increment or decrement the current weapon index based on scroll direction
            int newIndex = currentWeaponIndex + (scroll < 0 ? 1 : -1);

            // Ensure the new index stays within the bounds of the weapons array
            newIndex = Mathf.Clamp(newIndex, 0, weapons.Length - 1);

            // Switch to the new weapon
            SwitchWeapon(newIndex);
        }


    if(sword.activeSelf)
        {
            swordicon.SetActive(true);
            bowicon.SetActive(false);
            axeicon.SetActive(false);
            pickicon.SetActive(false);
            crosshair.sprite = swordpic;
        }
    else if(bow.activeSelf)
        {
            swordicon.SetActive(false);
            bowicon.SetActive(true);
            axeicon.SetActive(false);
            pickicon.SetActive(false);
            crosshair.sprite = bowpic;
        }
    else if(axe.activeSelf)
        {
            swordicon.SetActive(false);
            bowicon.SetActive(false);
            axeicon.SetActive(true);
            pickicon.SetActive(false);
            crosshair.sprite = toolpic;
        }
    else if(pick.activeSelf)
        {
            swordicon.SetActive(false);
            bowicon.SetActive(false);
            axeicon.SetActive(false);
            pickicon.SetActive(true);
            crosshair.sprite = toolpic;
        }
    }

    void SwitchWeapon(int newIndex)
    {
        // Check if the new index is valid
        if (newIndex >= 0 && newIndex < weapons.Length)
        {
            // Deactivate the current weapon
            SetActiveWeapon(currentWeaponIndex, false);
            
            // Activate the new weapon
            SetActiveWeapon(newIndex, true);
            
            // Update the current weapon index
            currentWeaponIndex = newIndex;
        }
    }

    void SetActiveWeapon(int index, bool isActive = true)
    {
        if (weapons[index] != null)
        {
            weapons[index].SetActive(isActive);
        }
    }
}