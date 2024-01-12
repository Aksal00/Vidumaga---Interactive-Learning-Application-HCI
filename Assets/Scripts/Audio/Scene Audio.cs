using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;


public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    //private AudioManager am;
    [Header("Scene BG Audio")]
    [SerializeField] private int BG_Audio_No;

    [Header("Scene Buttons")]
    [SerializeField] private  Button Button_1;
    [SerializeField] private  Button Button_2;
    [SerializeField] private  Button Button_3;
    [SerializeField] private  Button Button_4;
    [SerializeField] private  Button Button_5;
    [SerializeField] private  Button Button_6;
    [SerializeField] private  Button Button_7;
    [SerializeField] private  Button Button_8;
    [SerializeField] private  Button Button_9;
    [SerializeField] private  Button Button_10;

    [Header("Navigation Buttons")]

    [SerializeField] private  Button Back_Button;
    [SerializeField] private  Button Home_Button;
    [SerializeField] private  Button Additional;

    [Header("Instructor Button")]
    [SerializeField] private  Button Instructor_Button;
    [SerializeField] private  int Instructor_Audio_No;

    [Header("Dialog Panels")]
    [SerializeField] private  GameObject Panel_1;
    [SerializeField] private  GameObject Panel_2;
    [SerializeField] private  GameObject Panel_3;
    [SerializeField] private  GameObject Panel_4;
    [SerializeField] private  GameObject Panel_5;
    [SerializeField] private  GameObject Panel_6;
    [SerializeField] private  GameObject Panel_7;
    [SerializeField] private  GameObject Panel_8;
    [SerializeField] private  GameObject Panel_9;
    [SerializeField] private  GameObject Panel_10;
    [SerializeField] private  GameObject Panel_11;
    [SerializeField] private  GameObject Panel_12;
    [SerializeField] private  GameObject Panel_13;
    //[SerializeField] private GameObject Panel_14;
    public static GameObject BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4,Button_Hover_Audio,Button_Click_Audio_1,Button_Click_Audio_2,Short_1,Short_2,Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio,Panel_5_Audio,Panel_6_Audio,Panel_7_Audio,Panel_8_Audio,Panel_9_Audio,Panel_10_Audio,Panel_11_Audio,Panel_12_Audio,Panel_13_Audio,collected_audio,dropped_audio;
    
    
    private int i;
    private static int previous=0;
   
    void Start()
    {
        BG = GameObject.Find("BG");
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
        Button_Hover_Audio = GameObject.Find("Button_Hover_Audio");
        Button_Click_Audio_1 = GameObject.Find("Button_Click_Audio_1");
        Button_Click_Audio_2 = GameObject.Find("Button_Click_Audio_2");
        Short_1 =GameObject.Find("Short_1");
        Short_2 = GameObject.Find("Short_2");
        collected_audio = GameObject.Find("Collected Audio");
        dropped_audio = GameObject.Find("Dropped Audio");

        EventTrigger.Entry eventtype1 = new EventTrigger.Entry();
        eventtype1.eventID = EventTriggerType.PointerEnter;
        eventtype1.callback.AddListener((eventData) => { Button_Hover(1); });

        EventTrigger.Entry eventtype2 = new EventTrigger.Entry();
        eventtype2.eventID = EventTriggerType.PointerExit;
        eventtype2.callback.AddListener((eventData) => { Button_Hover_Exit(1); });

        EventTrigger.Entry eventtype3 = new EventTrigger.Entry();
        eventtype3.eventID = EventTriggerType.PointerDown;
        eventtype3.callback.AddListener((eventData) => { Button_Pointer_Down(1); });

        Button[] Button_list_1 = { Button_1,Button_2,Button_3,Button_4,Button_5,Button_6,Button_7,Button_8,Button_9,Button_10 };
        for(int i=0; i< Button_list_1.Length;i++){
            if (Button_list_1[i]){
                Button_list_1[i].AddComponent<EventTrigger>();
                Button_list_1[i].GetComponent<EventTrigger>().triggers.Add(eventtype1);
                Button_list_1[i].GetComponent<EventTrigger>().triggers.Add(eventtype2);
                Button_list_1[i].GetComponent<EventTrigger>().triggers.Add(eventtype3);
            }
            else{
                break;
            }
        }
            

        EventTrigger.Entry eventtype4 = new EventTrigger.Entry();
        eventtype4.eventID = EventTriggerType.PointerEnter;
        eventtype4.callback.AddListener((eventData) => { Button_Hover(2); });

        EventTrigger.Entry eventtype5 = new EventTrigger.Entry();
        eventtype5.eventID = EventTriggerType.PointerExit;
        eventtype5.callback.AddListener((eventData) => { Button_Hover_Exit(2); });

        EventTrigger.Entry eventtype6 = new EventTrigger.Entry();
        eventtype6.eventID = EventTriggerType.PointerDown;
        eventtype6.callback.AddListener((eventData) => { Button_Pointer_Down(2); });

        Button[] Button_list_2 = { Back_Button,Home_Button,Additional};
        for(int i=0; i< Button_list_2.Length;i++){
            if (Button_list_2[i]){
                Button_list_2[i].AddComponent<EventTrigger>();
                Button_list_2[i].GetComponent<EventTrigger>().triggers.Add(eventtype4);
                Button_list_2[i].GetComponent<EventTrigger>().triggers.Add(eventtype5);
                Button_list_2[i].GetComponent<EventTrigger>().triggers.Add(eventtype6);
            }
            else{
                break;
            }
        }
    



    
        EventTrigger.Entry eventtype7 = new EventTrigger.Entry();
        eventtype7.eventID = EventTriggerType.PointerEnter;
        eventtype7.callback.AddListener((eventData) => { Button_Hover(3); });

        EventTrigger.Entry eventtype8 = new EventTrigger.Entry();
        eventtype8.eventID = EventTriggerType.PointerExit;
        eventtype8.callback.AddListener((eventData) => { Button_Hover_Exit(3); });

        EventTrigger.Entry eventtype9 = new EventTrigger.Entry();
        eventtype9.eventID = EventTriggerType.PointerDown;
        eventtype9.callback.AddListener((eventData) => { Button_Pointer_Down(3); });

        Instructor_Button.AddComponent<EventTrigger>();
        Instructor_Button.GetComponent<EventTrigger>().triggers.Add(eventtype7);
        Instructor_Button.GetComponent<EventTrigger>().triggers.Add(eventtype8);
        Instructor_Button.GetComponent<EventTrigger>().triggers.Add(eventtype9);
     
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
        //Button_audio();
        if(AudioManager.bg_sound == true){
            Panel_Audio();
        }
        

        

    }

    void play_scene_bg_audio(){
        GameObject[] BG_Audio_files = {BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4 };
        for(i = 0; i < BG_Audio_files.Length;i++){
            if (BG_Audio_No == (i+1)){
                if (BG_Audio_No!= previous){
                    AudioSource bg_audioSource = BG_Audio_files[i+1].GetComponent<AudioSource>();
                    bg_audioSource.enabled = true;
                    AudioSource audioSource_previous = BG_Audio_files[previous].GetComponent<AudioSource>();
                    audioSource_previous.enabled = false;
                    previous = i+1;  
                }
                else{
                    AudioSource bg_audioSource = BG_Audio_files[i+1].GetComponent<AudioSource>();
                    bg_audioSource.enabled = true;
                }
                
            }
        }
  
        

    }
    void stop_scene_bg_audio(GameObject parent){
        foreach (Transform child in parent.transform)
        {
            AudioSource bg_audioSource = child.GetComponent<AudioSource>();
            bg_audioSource.enabled =false;
        }
    }

    void Button_Hover(int button_category){
        GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio_1,Button_Click_Audio_2};
        if (button_category == 1|button_category == 2){  
            AudioSource button_audioSource = Button_Audio_files[0].GetComponent<AudioSource>();
            button_audioSource.enabled =true;
        }
        if (button_category == 3 && StaticData.Instructor_voice==true){
            GameObject[] Instructor_Audio_Short={Short_1,Short_2};
            System.Random rnd = new System.Random();
            int random_no = rnd.Next(1,Instructor_Audio_Short.Length+1);
            for(int i=1;i<(Instructor_Audio_Short.Length+1);i++){
                if (random_no == i){
                    AudioSource button_audioSource = Instructor_Audio_Short[i-1].GetComponent<AudioSource>();
                    //button_audioSource.enabled =true;
                } 
            }
        } 

    }
    void Button_Hover_Exit(int button_category){
        GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio_1,Button_Click_Audio_2};
        if (button_category == 1 |button_category == 2){ 
            for(int i = 0; i< Button_Audio_files.Length;i++)
            { 
                AudioSource button_audioSource = Button_Audio_files[i].GetComponent<AudioSource>();
                button_audioSource.enabled =false;
            }
        }
        else if (button_category == 3){
            GameObject[] Instructor_Audio_Short={Short_1,Short_2};
            for(int i=1;i<(Instructor_Audio_Short.Length+1);i++){
                AudioSource button_audioSource = Instructor_Audio_Short[i-1].GetComponent<AudioSource>();
                button_audioSource.enabled =false;
            }

        }
    }
    void Button_Pointer_Down(int button_category){
        if (button_category == 1 |button_category == 3){ 
            GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio_1,Button_Click_Audio_2};
            AudioSource button_audioSource = Button_Audio_files[1].GetComponent<AudioSource>();
            button_audioSource.enabled =true;
            
            
        }
        
        if (button_category == 2){ 
            GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio_1,Button_Click_Audio_2};
            AudioSource button_audioSource = Button_Audio_files[2].GetComponent<AudioSource>();
            button_audioSource.enabled =true;
            
        }


    }
    void Panel_Audio(){
        GameObject[] Panel_list = {Panel_1,Panel_2,Panel_3,Panel_4,Panel_5,Panel_6,Panel_7,Panel_8,Panel_9,Panel_10,Panel_11,Panel_12,Panel_13};
        GameObject[] Panel_Audio_list = {Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio,Panel_5_Audio,Panel_6_Audio,Panel_7_Audio,Panel_8_Audio,Panel_9_Audio,Panel_10_Audio,Panel_11_Audio,Panel_12_Audio,Panel_13_Audio};
        for(int k=0;k<Panel_list.Length;k++){

            if(Panel_list[k] & ((StaticData.Instructor_voice==true)&(AudioManager.bg_sound==true))){
                if(Panel_list[k].activeSelf){
                    AudioSource panel_audioSource = Panel_Audio_list[k].GetComponent<AudioSource>();
                    panel_audioSource.enabled =true;
                    VolumeManager.Adjust_BG_Volume(0.015f,"dont_update");
                }

                else{
                    AudioSource panel_audioSource = Panel_Audio_list[k].GetComponent<AudioSource>();
                    panel_audioSource.enabled =false;
                    VolumeManager.Adjust_BG_Volume(StaticData.background_music_volume_previous,"update");
                    
                }
            }
        }
    }
    public static void game_audio(string audio_name){
        if(StaticData.game_voices == true){
            if (audio_name == "seller_voice"){
                    GameObject seller_voice = GameObject.Find("Seller Voice");
                    AudioSource seller_audioSource = seller_voice.GetComponent<AudioSource>();
                    seller_audioSource.enabled = false;
                    seller_audioSource.enabled = true;
            }
            if (audio_name == "collected"){
                    GameObject Collected_Audio = GameObject.Find("Collected Audio");
                    AudioSource collected_audioSource = Collected_Audio.GetComponent<AudioSource>();
                    collected_audioSource.enabled = false;
                    collected_audioSource.enabled = true;
            }
            if(audio_name == "dropped"){
                    GameObject Dropped_Audio = GameObject.Find("Dropped Audio");
                    AudioSource dropped_audioSource = Dropped_Audio.GetComponent<AudioSource>();
                    dropped_audioSource.enabled = false;
                    dropped_audioSource.enabled = true;
            }
            if(audio_name == "applause"){
                    GameObject Applause_Audio = GameObject.Find("Applause Audio");
                    AudioSource applause_audioSource = Applause_Audio.GetComponent<AudioSource>();
                    applause_audioSource.enabled = false;
                    applause_audioSource.enabled = true;
            }
        }
    }

}
