using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;


public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    //private AudioManager am;
    [Header("Scene BG Audio")]
    [SerializeField] private int BG_Audio_No;

    [Header("Button Category 1")]
    [SerializeField] private Button Button_1;
    [SerializeField] private Button Button_2;
    [SerializeField] private Button Button_3;
    [SerializeField] private Button Button_4;
    [SerializeField] private Button Button_5;

    [Header("Button Category 2")]
    [SerializeField] private Button Button_6;
    [SerializeField] private Button Button_7;
    [SerializeField] private Button Button_8;
    [SerializeField] private Button Button_9;
    [SerializeField] private Button Button_10;

    [Header("Instructor Button")]
    [SerializeField] private Button Instructor_Button;
    [SerializeField] private int Instructor_Audio_No;

    [Header("Dialog Panels")]
    [SerializeField] private GameObject Panel_1;
    [SerializeField] private GameObject Panel_2;
    [SerializeField] private GameObject Panel_3;
    [SerializeField] private GameObject Panel_4;

    private GameObject BG,BG_Audio_1,BG_Audio_2,BG_Audio_3,BG_Audio_4,Button_Hover_Audio,Button_Click_Audio,Short_1,Short_2,Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio;
    

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
          Button_Hover_Audio = GameObject.Find("Button_Hover_Audio");
          Button_Click_Audio = GameObject.Find("Button_Click_Audio");
          Short_1 =GameObject.Find("Short_1");
          Short_2 = GameObject.Find("Short_2");
          
          
    }

    // Update is called once per frame
    void Update()
    {
        //
        if(AudioManager.bg_music == true)
        {
            play_scene_bg_audio();

        }
        else{
            stop_scene_bg_audio(BG);
        }
        Button_audio(1);
        Button_audio(3);
        if(AudioManager.bg_sound == true){
            Panel_Audio();
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

    public void Button_audio(int button_category){
        if (button_category == 1){            
            Button[] Button_list_1 = { Button_1,Button_2,Button_3,Button_4,Button_5 };
            Button[] Button_list_2 = { Button_6,Button_7,Button_8,Button_9,Button_10 };
            


            EventTrigger.Entry eventtype1 = new EventTrigger.Entry();
            eventtype1.eventID = EventTriggerType.PointerEnter;
            eventtype1.callback.AddListener((eventData) => { Button_Hover(1); });

            EventTrigger.Entry eventtype2 = new EventTrigger.Entry();
            eventtype2.eventID = EventTriggerType.PointerExit;
            eventtype2.callback.AddListener((eventData) => { Button_Hover_Exit(1); });

            EventTrigger.Entry eventtype3 = new EventTrigger.Entry();
            eventtype3.eventID = EventTriggerType.PointerDown;
            eventtype3.callback.AddListener((eventData) => { Button_Pointer_Down(1); });

            for(i=0; i< Button_list_1.Length;i++){
                Button_list_1[i].AddComponent<EventTrigger>();
                Button_list_1[i].GetComponent<EventTrigger>().triggers.Add(eventtype1);
                Button_list_1[i].GetComponent<EventTrigger>().triggers.Add(eventtype2);
                Button_list_1[i].GetComponent<EventTrigger>().triggers.Add(eventtype3);
            }}
        
        if (button_category == 3){
            EventTrigger.Entry eventtype1 = new EventTrigger.Entry();
            eventtype1.eventID = EventTriggerType.PointerEnter;
            eventtype1.callback.AddListener((eventData) => { Button_Hover(3); });

            EventTrigger.Entry eventtype2 = new EventTrigger.Entry();
            eventtype2.eventID = EventTriggerType.PointerExit;
            eventtype2.callback.AddListener((eventData) => { Button_Hover_Exit(3); });

            EventTrigger.Entry eventtype3 = new EventTrigger.Entry();
            eventtype3.eventID = EventTriggerType.PointerDown;
            eventtype3.callback.AddListener((eventData) => { Button_Pointer_Down(3); });

            Instructor_Button.AddComponent<EventTrigger>();
            Instructor_Button.GetComponent<EventTrigger>().triggers.Add(eventtype1);
            Instructor_Button.GetComponent<EventTrigger>().triggers.Add(eventtype2);
            Instructor_Button.GetComponent<EventTrigger>().triggers.Add(eventtype3);


        }

    }
    void Button_Hover(int button_category){
        if (button_category == 1){ 
            GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio};
            AudioSource audioSource = Button_Audio_files[0].GetComponent<AudioSource>();
            audioSource.enabled =true;
        }
        else if (button_category == 3){
            GameObject[] Instructor_Audio_Short={Short_1,Short_2};
            System.Random rnd = new System.Random();
            int random_no = rnd.Next(1,Instructor_Audio_Short.Length+1);
            for(int i=1;i<(Instructor_Audio_Short.Length+1);i++)
            if (random_no == i){
                AudioSource audioSource = Instructor_Audio_Short[i-1].GetComponent<AudioSource>();
                audioSource.enabled =true;
            } 
        } 

    }
    void Button_Hover_Exit(int button_category){
        if (button_category == 1){ 
            GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio};
            AudioSource audioSource = Button_Audio_files[0].GetComponent<AudioSource>();
            audioSource.enabled =false;
            AudioSource audioSource2 = Button_Audio_files[1].GetComponent<AudioSource>();
            audioSource2.enabled =false;
        }
        else if (button_category == 3){
            GameObject[] Instructor_Audio_Short={Short_1,Short_2};
            for(int i=1;i<(Instructor_Audio_Short.Length+1);i++){
                AudioSource audioSource = Instructor_Audio_Short[i-1].GetComponent<AudioSource>();
                audioSource.enabled =false;
            }

        }
    }
    void Button_Pointer_Down(int button_category){
        if (button_category == 1 ||button_category == 3){ 
            GameObject[] Button_Audio_files={Button_Hover_Audio,Button_Click_Audio};
            AudioSource audioSource = Button_Audio_files[1].GetComponent<AudioSource>();
            audioSource.enabled =true;
        }
    }
    void Panel_Audio(){
        GameObject[] Panel_list = {Panel_1,Panel_2,Panel_3,Panel_4};
        GameObject[] Panel_Audio_list = {Panel_1_Audio,Panel_2_Audio,Panel_3_Audio,Panel_4_Audio};
        for(int k=0;k<Panel_list.Length;k++){
            if(Panel_list[k].activeSelf){
                AudioSource panel_audioSource = Panel_Audio_list[k].GetComponent<AudioSource>();
                panel_audioSource.enabled =true;
            }
            else{
                AudioSource panel_audioSource = Panel_Audio_list[k].GetComponent<AudioSource>();
                panel_audioSource.enabled =false;
            }
        }

    }

}
