using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public void Activity_Menu_Button()
    {
        SceneManager.LoadScene("Scenes/Activity Menu");
    }
    public void Main_Menu_Button()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }
    public void Matching_Activity_Button()
    {
        SceneManager.LoadScene("Scenes/Matching Activity");
    }
    public void Letters_Activity_Button()
    {
        SceneManager.LoadScene("Scenes/Alphabet Menu");
    }
    public void Painting_Activity_Button()
    {
        SceneManager.LoadScene("Scenes/Matching Activity");
    }
    public void Settings_Menu_Button()
    {
        SceneManager.LoadScene("Scenes/Settings Menu");
    }
    public void Games_Menu_Button()
    {
        SceneManager.LoadScene("Scenes/Games Menu");
    }
    public void Letter_A_Button()
    {
        SceneManager.LoadScene("Scenes/Letter A");
    }
    public void Hat_Seller_Game()
    {
        SceneManager.LoadScene("Scenes/Hat Seller Game");
    }



}
