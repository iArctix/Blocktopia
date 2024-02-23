using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    public GameObject pickupTextPrefab; // Prefab for the TMP Text element
    public Transform canvasTransform; // Parent transform for instantiated TMP Text elements
    public float displayDuration = 2f; // Duration to display the TMP Text before it disappears
    public float verticalSpacing = 10f; // Vertical spacing between pickup messages

    private float currentYPosition; // Tracks the Y position for the next pickup message

    // Function to display pickup information
    public void DisplayPickup(string itemName, int amount)
    {
        // Instantiate the TMP Text prefab
        GameObject pickupTextObject = Instantiate(pickupTextPrefab, canvasTransform);

        // Set the text of the TMP Text element
        TextMeshProUGUI textComponent = pickupTextObject.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = itemName + " x" + amount; // Concatenate the item name and amount
        }

        // Set the position of the TMP Text element
        RectTransform rectTransform = pickupTextObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // Set the Y position based on currentYPosition
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentYPosition);

            // Increment currentYPosition for the next pickup message
            currentYPosition += rectTransform.sizeDelta.y + verticalSpacing;
        }

        // Destroy the TMP Text element after display duration
        Destroy(pickupTextObject, displayDuration);
    }




    //// How to call
    /// public PickupUI pickupUI;
    ///pickupUI.DisplayPickup(itemName, amount);

}