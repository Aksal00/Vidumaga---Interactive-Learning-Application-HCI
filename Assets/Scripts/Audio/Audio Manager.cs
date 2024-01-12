using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button BG_Music_Button;
    [SerializeField] private Button BG_Music_Off_Button;
    [SerializeField] private Button Sound_Button;
    [SerializeField] private Button Sound_Off_Button;
    public static bool bg_music;
    public static bool bg_sound;
    void Start()
    {
        bg_music = true;
        bg_sound = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("bg_music :-"+bg_music);
        Debug.Log("bg_sound :-"+bg_sound);

        if (StaticData.Instructor_voice==true&& bg_sound==false){
            Sound_Off_Button.gameObject.SetActive(false);
            Sound_Button.gameObject.SetActive(true);
            bg_sound=true;
        }
    }
    
    public void bg_music_on(){
        bg_music = true;
    }
    public void bg_music_off(){
        bg_music = false;
    }
    public void sound_on(){
        bg_sound = true;
        StaticData.Instructor_voice = true;
        StaticData.game_voices = true;
    }
    public void sound_off(){
        bg_sound = false;
        StaticData.Instructor_voice = false;
        StaticData.game_voices = false;

    }
}
