using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEditor;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;


public class LoadingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Loading_Panel;

    [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
    
    public static string GetActiveWindowTitle()
    {
            const int nChars = 256;
            StringBuilder buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, buff, nChars)>  0) //greater than here
            {
                return buff.ToString();
            }
            return "";
    }

    public static int WaitForActiveWindow(string title, int seconds)
    {
            DateTime startTime;
            string activeTitle = "";

            startTime = DateTime.Now;
            activeTitle = GetActiveWindowTitle();

            while (!activeTitle.ToLower().Contains(title.ToLower()))
            {
                //Check for timeout
                //if ((DateTime.Now - startTime).TotalSeconds > seconds) //greater than here
                                

                //Check every 0.2 seconds
                //Thread.Sleep(200);
                activeTitle = GetActiveWindowTitle();
                return 1;
            }

            return 0;
    }
    void Start()
    {
        UnityEngine.Debug.Log("Loading SM on");
    }

    // Update is called once per frame
    void Update()
    {
        window_check();
    }
    void window_check()
    {
        string windowTitleToCheck = "VIDUMAGA - Hand Gesture Tracker";// Replace with the actual window title
        
        int result = WaitForActiveWindow(windowTitleToCheck,5);
        if (result == 0){
            UnityEngine.Debug.Log("Hand Tracker Loading Has Completed");
            Loading_Panel.gameObject.SetActive(false);
        }
        else{
            UnityEngine.Debug.Log("Waiting for hand tracker");
        }

    }
}
