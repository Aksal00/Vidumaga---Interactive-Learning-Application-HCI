using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingScreenAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Image image_fill;
    public float waitTime;
    void Start()
    {
        image_fill.fillAmount = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        image_fill.fillAmount += 1.0f / waitTime * Time.deltaTime;
        if(image_fill.fillAmount == 1.0f){
            Start();
        }
    }
}
