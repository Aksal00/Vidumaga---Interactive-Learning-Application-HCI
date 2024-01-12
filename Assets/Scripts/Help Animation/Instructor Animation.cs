using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstructorAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform instructor;

    public Transform dialog_box;

    [SerializeField]private int no_of_buttons;
    
    [Header("If single button dialog box")]
    public Transform button;

    [Header("If double button dialog box")]
    public Transform button1;
    public Transform button2;
    
    public CanvasGroup background;
    

    private void OnEnable()
    {
        //ameObject instructor_voice = GameObject.Find("Instructor Voice");
        background.alpha = 0;
        background.LeanAlpha(1,0.4f);
        //Instructor
        instructor.localPosition = new Vector2(500,-Screen.height);
        instructor.LeanMoveLocalY(-100,0.5f).setEaseOutExpo().delay = 0.1f;
        instructor.LeanMoveLocalX(500,0.5f).setEaseOutExpo().delay = 0.1f;
        //dialog_box
        dialog_box.localPosition = new Vector2(0,-Screen.height);
        dialog_box.LeanMoveLocalY(80,0.5f).setEaseOutExpo().delay = 0.1f;
        dialog_box.LeanMoveLocalX(-220,0.5f).setEaseOutExpo().delay = 0.1f;
        //button
        if (no_of_buttons ==1){
            button.localPosition = new Vector2(0,-Screen.height);
            button.LeanMoveLocalY(20,0.5f).setEaseOutExpo().delay = 0.1f;
            button.LeanMoveLocalX(-220,0.5f).setEaseOutExpo().delay = 0.1f;
        }
        if (no_of_buttons ==2){
            button1.localPosition = new Vector2(0,-Screen.height);
            button1.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
            button1.LeanMoveLocalX(-420,0.5f).setEaseOutExpo().delay = 0.1f;

            button2.localPosition = new Vector2(0,-Screen.height);
            button2.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
            button2.LeanMoveLocalX(-20,0.5f).setEaseOutExpo().delay = 0.1f;


        }
    }
    

    // Update is called once per frame
    public void CloseInstructor()
    {
        
        background.LeanAlpha(0,0.5f);
        instructor.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();

        dialog_box.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();
        if (no_of_buttons ==1){
            button.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo().setOnComplete(OnComplete);
        }
        if (no_of_buttons ==2){
            button1.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();
            button2.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo().setOnComplete(OnComplete);
        }
        
        
    }

    void OnComplete(){
        gameObject.SetActive(false);
        
        
    }



}
