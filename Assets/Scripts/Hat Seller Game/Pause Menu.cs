using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;

    public GameObject Starting_menu;

    public GameObject Hat;

    public Hat hat;

    public GameObject Seller;
    public Motion motion;
    public bool isPaused;

    public Button Pause_Button;
    public Button Resume_Button;
    public Button Ready_Button;

    public void Start()
    {
        pauseMenu.SetActive(false);   
    }

    public void Update()
    {   
        Pause_Button.onClick.AddListener(PauseGame);
        Resume_Button.onClick.AddListener(ResumeGame);
        

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }  
        
    }

    public void PauseGame()
    {
        if(hat.no_of_chances >0)
        {
            pauseMenu.gameObject.SetActive(true);
            isPaused = true;
            motion.rb1.simulated = false;
            motion.rb2.simulated = false;
        }
        
    }
    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        isPaused = false;
        motion.rb1.simulated = true;
        motion.rb2.simulated = true;
    }
}
