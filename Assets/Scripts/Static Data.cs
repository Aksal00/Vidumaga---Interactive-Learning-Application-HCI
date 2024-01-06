using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    // Start is called before the first frame update
    public static float game_brightness;
    public static float brightness_slider_value;
    public static float background_music_volume;
    public static float background_music_slider_value;
    public static float Other_sound_volume;
    public static float Other_sound_slider_value;
    void Start()
    {
        game_brightness = 1.0f;
        brightness_slider_value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
