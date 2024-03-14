using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider; 
    public PlayerHealth playerHealth;
    public Playerstats stats;
    public Image fillImage; 

    public Color fullHealthColor = Color.green; 
    public Color zeroHealthColor = Color.red; 

    private void Start()
    {
        
        UpdateHealthBar();
    }

    private void Update()
    {
       
        UpdateHealthBar();
    }

   
    private void UpdateHealthBar()
    {
        
        if (slider == null || fillImage == null || playerHealth == null)
        {
            Debug.LogWarning("Slider, FillImage, or PlayerHealth reference not set in PlayerHealthBar script.");
            return;
        }

        
        slider.value = playerHealth.currenthealth / stats.maxhealth;

      
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, slider.normalizedValue);
        fillImage.fillAmount = slider.value;
    }
}