using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    AutoExposure exposure;

    void Start()
    {
        brightnessSlider.value = StaticData.brightness_slider_value;
        
    }
    void Update(){
        brightness.TryGetSettings(out exposure);
        AdjustBrightness(brightnessSlider.value);
    }
   
    // Update is called once per frame
    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
            StaticData.game_brightness = value;
            StaticData.brightness_slider_value =value;
            Debug.Log("Brightness = "+StaticData.game_brightness);
        }
        else{
            exposure.keyValue.value = .05f;
            StaticData.game_brightness = .05f;
            StaticData.brightness_slider_value =.05f; 
        }
    }
}
