using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PickupUI : MonoBehaviour
{
    public GameObject pickupTextPrefab; // Prefab for the TMP Text element
    public Transform canvasTransform; // Parent transform for instantiated TMP Text elements
    public float displayDuration = 2f; // Duration to display the TMP Text before it disappears
    public float verticalSpacing = 10f; // Vertical spacing between pickup messages

    private List<GameObject> activePickupMessages = new List<GameObject>(); // List to track active pickup messages

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

        // Add the pickup message to the list of active messages
        activePickupMessages.Add(pickupTextObject);

        // Position the pickup messages
        PositionPickupMessages();

        // Destroy the TMP Text element after display duration
        Destroy(pickupTextObject, displayDuration);
    }

    // Position pickup messages
    private void PositionPickupMessages()
    {
        float currentYPosition = 0;
        for (int i = activePickupMessages.Count - 1; i >= 0; i--)
        {
            GameObject pickupMessage = activePickupMessages[i];
            if (pickupMessage != null)
            {
                RectTransform rectTransform = pickupMessage.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    // Set the Y position based on the index and vertical spacing
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentYPosition);
                    currentYPosition += rectTransform.sizeDelta.y + verticalSpacing;
                }
            }
            else
            {
                // Remove destroyed GameObject from the list
                activePickupMessages.RemoveAt(i);
            }
        }
    }

    // Remove a pickup message from the list of active messages
    public void RemovePickupMessage(GameObject pickupMessage)
    {
        activePickupMessages.Remove(pickupMessage);

        // Position the pickup messages after removal
        PositionPickupMessages();
    }
}