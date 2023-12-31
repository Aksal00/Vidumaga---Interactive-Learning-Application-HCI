using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform instructor_button;

    public Transform dialog_box;
    
    public Transform button1;
    public Transform button2;
    public Transform button3;
    
    public CanvasGroup background;
    private void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(1,0.4f);
        //Instructor
        instructor_button.localPosition = new Vector2(500,-Screen.height);
        instructor_button.LeanMoveLocalY(-100,0.5f).setEaseOutExpo().delay = 0.1f;
        instructor_button.LeanMoveLocalX(500,0.5f).setEaseOutExpo().delay = 0.1f;
        //dialog_box
        dialog_box.localPosition = new Vector2(0,-Screen.height);
        dialog_box.LeanMoveLocalY(80,0.5f).setEaseOutExpo().delay = 0.1f;
        dialog_box.LeanMoveLocalX(-220,0.5f).setEaseOutExpo().delay = 0.1f;
        //buttons  
        
        button1.localPosition = new Vector2(0,-Screen.height);
        button1.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
        button1.LeanMoveLocalX(-420,0.5f).setEaseOutExpo().delay = 0.1f;

        button2.localPosition = new Vector2(0,-Screen.height);
        button2.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
        button2.LeanMoveLocalX(-20,0.5f).setEaseOutExpo().delay = 0.1f;

        button3.localPosition = new Vector2(0,-Screen.height);
        button3.LeanMoveLocalY(20,0.5f).setEaseOutExpo().delay = 0.1f;
        button3.LeanMoveLocalX(-220,0.5f).setEaseOutExpo().delay = 0.1f;


        
    }
    

    // Update is called once per frame
    public void ClosePauseMenu()
    {
        background.LeanAlpha(0,0.5f);
        instructor_button.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();

        dialog_box.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();
        
        button1.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();
        button2.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo();
        button3.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo().setOnComplete(OnComplete);
        
    }

    void OnComplete(){
        gameObject.SetActive(false);
    }



}
