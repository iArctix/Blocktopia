using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons; // Array of weapon game objects
    private int currentWeaponIndex = 0; // Index of the currently active weapon

    void Start()
    {
        // Ensure only the first weapon is initially active
        SetActiveWeapon(currentWeaponIndex);
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