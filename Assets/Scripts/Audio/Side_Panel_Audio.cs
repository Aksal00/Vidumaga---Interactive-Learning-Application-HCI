using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Side_Panel_Audio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private  Button Button_1;
    [SerializeField] private  Button Button_2;
    [SerializeField] private  Button Button_3;
    [SerializeField] private  Button Button_4;
    [SerializeField] private  Button Button_5;
    [SerializeField] private  Button Button_6;
    private GameObject Button_Click_Audio_3,Button_Click_Audio_4;
    void Start()
    {
        Button_Click_Audio_3 = GameObject.Find("Button_Click_Audio_3");
        Button_Click_Audio_4 = GameObject.Find("Button_Click_Audio_4");

        EventTrigger.Entry eventtype10 = new EventTrigger.Entry();
        eventtype10.eventID = EventTriggerType.PointerDown;
        eventtype10.callback.AddListener((eventData) => { Button_Pointer_Down(1); });



        EventTrigger.Entry eventtype11 = new EventTrigger.Entry();
        eventtype11.eventID = EventTriggerType.PointerDown;
        eventtype11.callback.AddListener((eventData) => { Button_Pointer_Down(2); });

        EventTrigger.Entry eventtype12 = new EventTrigger.Entry();
        eventtype12.eventID = EventTriggerType.PointerExit;
        eventtype12.callback.AddListener((eventData) => { Button_Hover_Exit(1); });
                
        EventTrigger.Entry eventtype13 = new EventTrigger.Entry();
        eventtype13.eventID = EventTriggerType.PointerExit;
        eventtype13.callback.AddListener((eventData) => { Button_Hover_Exit(2); });

        Button[] Side_buttons_audio = { Button_1,Button_2,Button_5,Button_6};
        Button[] Side_buttons_controller = { Button_3,Button_4};
        
        for(int i=0; i< Side_buttons_audio.Length;i++){
            if (Side_buttons_audio[i]){
                Side_buttons_audio[i].AddComponent<EventTrigger>();
                Side_buttons_audio[i].GetComponent<EventTrigger>().triggers.Add(eventtype10);
                Side_buttons_audio[i].GetComponent<EventTrigger>().triggers.Add(eventtype12);
            }
            else{
                break;
            }
        }
        for(int i=0; i< Side_buttons_controller.Length;i++){
            if (Side_buttons_controller[i]){
                Side_buttons_controller[i].AddComponent<EventTrigger>();
                Side_buttons_controller[i].GetComponent<EventTrigger>().triggers.Add(eventtype11);
                Side_buttons_controller[i].GetComponent<EventTrigger>().triggers.Add(eventtype13);
            }
            else{
                break;
            }
        }

    }

    // Update is called once per frame

    void Button_Pointer_Down(int button_category){
        GameObject[] Button_Audio_files={Button_Click_Audio_3,Button_Click_Audio_4};
        if (button_category == 1 ){ 
            AudioSource button_audioSource = Button_Audio_files[0].GetComponent<AudioSource>();
            button_audioSource.enabled = true;
           
        }
        
        if (button_category == 2){ 
            AudioSource button_audioSource = Button_Audio_files[1].GetComponent<AudioSource>();
            button_audioSource.enabled =true;
            
        }

    }

    void Button_Hover_Exit(int button_category){
        GameObject[] Button_Audio_files={Button_Click_Audio_3,Button_Click_Audio_4};
        if (button_category == 1 |button_category == 2){ 
            for(int i = 0; i< Button_Audio_files.Length;i++)
            { 
                AudioSource button_audioSource = Button_Audio_files[i].GetComponent<AudioSource>();
                button_audioSource.enabled =false;
            }
        }
    }
}
