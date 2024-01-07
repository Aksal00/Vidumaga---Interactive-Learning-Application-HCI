using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    // Start is called before the first frame update
    public static float game_brightness;
    public static float brightness_slider_value;
    public static float background_music_volume;
    public static float background_music_volume_previous;
    public static float background_music_slider_value;
    public static float Other_sound_volume;
    public static float Other_sound_slider_value;
    public static GameObject BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4,Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio;


    public static bool Instructor_voice;
    void Start()
    {
        game_brightness = 1.0f;
        brightness_slider_value = 1.0f;
        background_music_slider_value = 0.03f;
        background_music_volume = 0.03f;
        Other_sound_volume = 0.5f;
        Other_sound_slider_value = 0.5f;
        Instructor_voice = true;
        background_music_volume_previous = background_music_volume;
        BG_Audio_1 = GameObject.Find("BG_Audio_1");
        BG_Audio_2 = GameObject.Find("BG_Audio_2");
        BG_Audio_3 = GameObject.Find("BG_Audio_3");
        BG_Audio_4 = GameObject.Find("BG_Audio_4");
        Panel_1_Audio = GameObject.Find("Panel_1_Audio");
        Panel_2_Audio = GameObject.Find("Panel_2_Audio");
        Panel_3_Audio = GameObject.Find("Panel_3_Audio");
        Panel_4_Audio = GameObject.Find("Panel_4_Audio");
        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] BG_Audio_files = {BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4 };
        for(int i = 0; i < BG_Audio_files.Length;i++){
                    AudioSource vol_audioSource = BG_Audio_files[i].GetComponent<AudioSource>();
                    vol_audioSource.volume= background_music_volume;
        }
        GameObject[] Panel_Audio_list = {Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio};
        for(int i = 0; i <Panel_Audio_list.Length;i++){
                    AudioSource vol_audioSource = Panel_Audio_list[i].GetComponent<AudioSource>();
                    vol_audioSource.volume= Other_sound_volume;

        }

        
    }
}
