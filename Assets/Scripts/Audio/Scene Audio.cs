using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    //private AudioManager am;
    [Header("Scene BG Audio")]
    [SerializeField] private int BG_Audio_No;

    [Header("Button Category 1")]
    [SerializeField] private Button Button_1,Button_2,Button_3,Button_4,Button_5;

    [Header("Button Category 2")]
    [SerializeField] private Button Button_6,Button_7,Button_8,Button_9,Button_10;

    [Header("Instructor Button")]
    [SerializeField] private Button Instructor_Button;
    [SerializeField] private int Instructor_Audio_No;
     private GameObject BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4;
    

    private int i;
    private static int previous=0;
    void Start()
    {
          BG = GameObject.Find("BG");
          BG_Audio_1 = GameObject.Find("BG_Audio_1");
          BG_Audio_2 = GameObject.Find("BG_Audio_2");
          BG_Audio_3 = GameObject.Find("BG_Audio_3");
          BG_Audio_4 = GameObject.Find("BG_Audio_4");
          
    }

    // Update is called once per frame
    void Update()
    {
        if(AudioManager.bg_music == true)
        {
            play_scene_bg_audio();

        }
        else{
            stop_scene_bg_audio(BG);
        }

    }

    void play_scene_bg_audio(){
        GameObject[] BG_Audio_files = { BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4 };
        
        
        for(i = 0; i < BG_Audio_files.Length;i++){
            if (BG_Audio_No == i){
                if (BG_Audio_No!= previous){
                    AudioSource audioSource = BG_Audio_files[i].GetComponent<AudioSource>();
                    audioSource.enabled = true;
                    AudioSource audioSource_previous = BG_Audio_files[previous].GetComponent<AudioSource>();
                    audioSource_previous.enabled = false;
                    previous = i;  
                }
                else{
                    AudioSource audioSource = BG_Audio_files[i].GetComponent<AudioSource>();
                    audioSource.enabled = true;
                }
                
            }
        }
  
        

    }
    void stop_scene_bg_audio(GameObject parent){
        foreach (Transform child in parent.transform)
        {
            AudioSource audioSource = child.GetComponent<AudioSource>();
            audioSource.enabled =false;
        }
    }
}
