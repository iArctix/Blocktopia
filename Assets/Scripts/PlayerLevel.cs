using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public Slider slider;
    public Playerstats stats;
    public Image fillImage;

    public Color fullexpColor = Color.yellow;
    public Color zeroexpColor = Color.green;

    private void Start()
    {

        UpdateEXPBar();
    }

    private void Update()
    {

        UpdateEXPBar();
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(slider.value);
            Debug.Log("total exp" + stats.playertotalexp);
            Debug.Log("Level" + stats.playerlevel);

        }
    }


    private void UpdateEXPBar()
    {

        slider.value = ((stats.playertotalexp - (stats.playerlevel * 100)) / 100);

        fillImage.color = Color.Lerp(zeroexpColor, fullexpColor, slider.normalizedValue);
        fillImage.fillAmount = slider.value;
    }
}

