using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider bg_music_slider;
    public Slider other_sound_slider;

    private GameObject BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4;
    void Start()
    {
        BG = GameObject.Find("BG");
        BG_Audio_1 = GameObject.Find("BG_Audio_1");
        BG_Audio_2 = GameObject.Find("BG_Audio_2");
        BG_Audio_3 = GameObject.Find("BG_Audio_3");
        BG_Audio_4 = GameObject.Find("BG_Audio_4");
        
        
        if(StaticData.background_music_volume!=0){
            bg_music_slider.value = StaticData.background_music_volume;
        }
        else{
            bg_music_slider.value = 0.08f;
        }
        
    }
    void Update(){

        Adjust_BG_Volume(bg_music_slider.value);
    }
   
    // Update is called once per frame
    public void Adjust_BG_Volume(float value)
    {
        
        
        GameObject[] BG_Audio_files = {BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4 };
        for(int i = 0; i < BG_Audio_files.Length;i++){
                    AudioSource audioSource = BG_Audio_files[i].GetComponent<AudioSource>();
                    audioSource.volume= value;
                    StaticData.background_music_volume= value;
                    StaticData.background_music_slider_value= value;
        }
        Debug.Log("BG_Music_Volume = "+StaticData.background_music_volume);
        

    }
}
