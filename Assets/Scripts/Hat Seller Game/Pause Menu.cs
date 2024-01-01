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

    public GameObject Seller;
    private Rigidbody2D rb1;

    private Rigidbody2D rb2;
    public bool isPaused;

    public Button Pause_Button;
    public Button Resume_Button;
    public Button Ready_Button;

    void Start()
    {
        pauseMenu.SetActive(false);
        rb1 = Hat.GetComponent<Rigidbody2D>();
        rb2 = Seller.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
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
        pauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        
        rb1.simulated = false;
        rb2.simulated = false;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        //Time.timeScale = 1f;
        isPaused = false;
        rb1.simulated = true;
        rb2.simulated = true;
    }
}
