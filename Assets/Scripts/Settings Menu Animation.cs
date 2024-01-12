using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsMenuAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Transform Panel_1;
    [SerializeField]private Transform Panel_2;
    [SerializeField]private Transform Panel_3;
    [SerializeField]private Transform Panel_4;
    [SerializeField]private Button button_1;
    [SerializeField]private Button button_2;
    [SerializeField]private Button button_3;
    [SerializeField]private Button button_4;

    public void Start()
    {
        //background.alpha = 0;
        //background.LeanAlpha(1,0.4f);
        EventTrigger.Entry eventtype1 = new EventTrigger.Entry();
        eventtype1.eventID = EventTriggerType.PointerDown;
        eventtype1.callback.AddListener((eventData) => { Button_Pointer_Down(1); });

        EventTrigger.Entry eventtype2 = new EventTrigger.Entry();
        eventtype2.eventID = EventTriggerType.PointerDown;
        eventtype2.callback.AddListener((eventData) => { Button_Pointer_Down(2); });

        EventTrigger.Entry eventtype3 = new EventTrigger.Entry();
        eventtype3.eventID = EventTriggerType.PointerDown;
        eventtype3.callback.AddListener((eventData) => { Button_Pointer_Down(3); });

        EventTrigger.Entry eventtype4 = new EventTrigger.Entry();
        eventtype4.eventID = EventTriggerType.PointerDown;
        eventtype4.callback.AddListener((eventData) => { Button_Pointer_Down(4); });
        Button [] Button_list = {button_1,button_2,button_3,button_4};
        for (int i=0; i<(Button_list.Length);i++){
            Button_list[i].AddComponent<EventTrigger>();
    
        }
        Button_list[0].GetComponent<EventTrigger>().triggers.Add(eventtype1);
        Button_list[1].GetComponent<EventTrigger>().triggers.Add(eventtype2);
        Button_list[2].GetComponent<EventTrigger>().triggers.Add(eventtype3);
        Button_list[3].GetComponent<EventTrigger>().triggers.Add(eventtype4);

        Transform [] Panel_list = {Panel_1,Panel_2,Panel_3,Panel_4};
        Panel_list[0].gameObject.SetActive(true);
        for (int i=1; i<(Panel_list.Length);i++){
            Panel_list[i].gameObject.SetActive(false);
        }


    }
    
    void Button_Pointer_Down(int Button_No){

        Transform [] Panel_list = {Panel_1,Panel_2,Panel_3,Panel_4};
        for (int i=0; i<(Panel_list.Length);i++){
            if (Panel_list[i].gameObject.activeSelf){
                Panel_list[i].LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo().setOnComplete(OnComplete);
            }
        }    
        for (int i=0; i<(Panel_list.Length);i++){    
            if ((Button_No-1) == i){
                Panel_list[i].gameObject.SetActive(true);
                Panel_list[i].localPosition = new Vector2(0,-Screen.height);
                Panel_list[i].LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
                Panel_list[i].LeanMoveLocalX(0,0.5f).setEaseOutExpo().delay = 0.1f;
            }
            else{
                Panel_list[i].gameObject.SetActive(false);
            }
        }
    }

    void OnComplete(){
        gameObject.SetActive(false);
    }
}
