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
    public static GameObject BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4,Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio,Panel_5_Audio,Panel_6_Audio,Panel_7_Audio,Panel_8_Audio,Panel_9_Audio,Panel_10_Audio,Panel_11_Audio,Panel_12_Audio,Panel_13_Audio,seller_voice,monkey_voice,collected_audio,dropped_audio;
    public static bool game_voices;
    public static bool Instructor_voice;
    void Start()
    {
        game_brightness = 1.0f;
        brightness_slider_value = 1.0f;
        background_music_slider_value = 0.07f;
        background_music_volume = 0.07f;
        Other_sound_volume = 0.5f;
        Other_sound_slider_value = 0.5f;
        Instructor_voice = true;
        game_voices = true;
        background_music_volume_previous = background_music_volume;
        BG_Audio_1 = GameObject.Find("BG_Audio_1");
        BG_Audio_2 = GameObject.Find("BG_Audio_2");
        BG_Audio_3 = GameObject.Find("BG_Audio_3");
        BG_Audio_4 = GameObject.Find("BG_Audio_4");
        Panel_1_Audio = GameObject.Find("Panel_1_Audio");
        Panel_2_Audio = GameObject.Find("Panel_2_Audio");
        Panel_3_Audio = GameObject.Find("Panel_3_Audio");
        Panel_4_Audio = GameObject.Find("Panel_4_Audio");
        Panel_5_Audio = GameObject.Find("Panel_5_Audio");
        Panel_6_Audio = GameObject.Find("Panel_6_Audio");
        Panel_7_Audio = GameObject.Find("Panel_7_Audio");
        Panel_8_Audio = GameObject.Find("Panel_8_Audio");
        Panel_9_Audio = GameObject.Find("Panel_9_Audio");
        Panel_10_Audio = GameObject.Find("Panel_10_Audio");
        Panel_11_Audio = GameObject.Find("Panel_11_Audio");
        Panel_12_Audio = GameObject.Find("Panel_12_Audio");
        Panel_13_Audio = GameObject.Find("Panel_13_Audio");
        seller_voice = GameObject.Find("Seller Voice");
        monkey_voice = GameObject.Find("Monkey Voice");
        collected_audio = GameObject.Find("Collected Audio");
        dropped_audio = GameObject.Find("Dropped Audio");

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] BG_Audio_files = {BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4 };
        for(int i = 0; i < BG_Audio_files.Length;i++){
                    AudioSource vol_audioSource = BG_Audio_files[i].GetComponent<AudioSource>();
                    vol_audioSource.volume= background_music_volume;
        }
        GameObject[] Panel_Audio_list = {Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio,Panel_5_Audio,Panel_6_Audio,Panel_7_Audio,Panel_8_Audio,Panel_9_Audio,Panel_10_Audio,Panel_11_Audio,Panel_12_Audio,Panel_13_Audio};
        GameObject[] Game_Audio_list = {seller_voice,monkey_voice,collected_audio,dropped_audio};
        for(int i = 0; i <Panel_Audio_list.Length;i++){
                    AudioSource vol_audioSource = Panel_Audio_list[i].GetComponent<AudioSource>();
                    vol_audioSource.volume= Other_sound_volume;

        }
        for(int i = 0; i <Game_Audio_list.Length;i++){
                    AudioSource vol_audioSource = Game_Audio_list[i].GetComponent<AudioSource>();
                    vol_audioSource.volume= Other_sound_volume;

        }

        
    }
}
