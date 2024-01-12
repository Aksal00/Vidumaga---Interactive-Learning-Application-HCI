using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider bg_music_slider;
    public Slider other_sound_slider;

    public Toggle instructor_voice_toggle;

    
    void Start()
    {
        
        if(StaticData.background_music_volume!=0){
            bg_music_slider.value = StaticData.background_music_volume;
        }
        else{
            bg_music_slider.value = 0.03f;
        }
        if(StaticData.Other_sound_volume!=0){
            other_sound_slider.value = StaticData.Other_sound_volume;
        }
        else{
            other_sound_slider.value = 0.5f;
        }
        if(StaticData.Instructor_voice == false){
            instructor_voice_toggle.isOn = false;
        }
        else{
            instructor_voice_toggle.isOn = true;
        } 
        
    }
    void Update(){
        Adjust_BG_Volume(bg_music_slider.value, "update");
        Adjust_Other_Sound_Volume(other_sound_slider.value);
    }
   
    // Update is called once per frame
    public static void Adjust_BG_Volume(float value,string update)
    {
        StaticData.background_music_volume= value;
        StaticData.background_music_slider_value= value;
        if (update == "update"){
            StaticData.background_music_volume_previous = value;
        }    
        Debug.Log("BG_Music_Volume = "+StaticData.background_music_volume);
    }
    public void Adjust_Other_Sound_Volume(float value){

        StaticData.Other_sound_volume= value;
        StaticData.Other_sound_slider_value= value;
        Debug.Log("Other_Sound_Volume = "+StaticData.Other_sound_volume);
    }
    
    public void disable_instructor_voice(){

        bool current_status = StaticData.Instructor_voice;
        if(current_status==true){
            
            StaticData.Instructor_voice = false;
            instructor_voice_toggle.isOn = false;
        }
        if(current_status==false){
            StaticData.Instructor_voice = true;
            instructor_voice_toggle.isOn = true;
        }

    }


}
