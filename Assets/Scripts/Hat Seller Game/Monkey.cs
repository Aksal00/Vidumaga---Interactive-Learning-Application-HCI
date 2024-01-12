using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public Transform monkey;
    
    void Start()
    {

    }

    // Update is called once per frame
    public void Monkey_voice()
    {
            if(StaticData.game_voices == true){
                GameObject monkey_voice = GameObject.Find("Monkey Voice");
                AudioSource monkey_voice_audioSource = monkey_voice.GetComponent<AudioSource>();
                monkey_voice_audioSource.enabled = true;   
            }
    }
}
