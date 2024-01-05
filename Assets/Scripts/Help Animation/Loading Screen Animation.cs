using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Circle_Animation;
    public CanvasGroup background;
    
    void Start(){
        gameObject.SetActive(false);
    }
    public void Start_Loading_Screen()
    {
        background.alpha = 0;
        background.LeanAlpha(1,0.4f);
        Circle_Animation.localPosition = new Vector2(0,-Screen.height);
        Circle_Animation.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;
        Circle_Animation.LeanMoveLocalX(0,0.5f).setEaseOutExpo().delay = 0.1f;

        
    }
    

    // Update is called once per frame
    public void Close_Loading_Screen()
    {
        background.LeanAlpha(0,0.5f);
        Circle_Animation.LeanMoveLocalY(-Screen.height,0.8f).setEaseOutExpo().setOnComplete(OnComplete);;
        //Circle_Animation.gameObject.SetActive(false);
        
    }

    void OnComplete(){
        gameObject.SetActive(false);
    }



}
