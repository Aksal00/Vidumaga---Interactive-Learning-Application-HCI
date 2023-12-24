using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CoverActive : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject LetterCoverImage;
    [SerializeField]
    private Button StartingButton;
    [SerializeField]
    private Button EndingButton;

    public void setCoverImage()
    {
        if (Input.GetButtonDown("StartingButton")){

            LetterCoverImage.SetActive(true);
        }
    }
}
