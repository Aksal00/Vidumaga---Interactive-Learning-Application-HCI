using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangingButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite ButtonImage1;
    public Sprite ButtonImage2;
    public Button button;
    
    int i =1;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButtonImage()
    {
        
        if (i%2==1){

            button.image.sprite = ButtonImage1;
            i++;
        }
        else{
            button.image.sprite = ButtonImage2;
            i++;
        }
    }
}
