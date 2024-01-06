using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class Brightness_other_screens : MonoBehaviour
{
    // Start is called before the first frame update
    //public Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;
    AutoExposure exposure;

    void Start()
    {
        brightness.TryGetSettings(out exposure);
        AdjustBrightness(StaticData.game_brightness);
    }

    // Update is called once per frame
    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
            StaticData.game_brightness = value;
        }
        else{
            exposure.keyValue.value = .05f;
            StaticData.game_brightness = .05f;
        }
    }
}
