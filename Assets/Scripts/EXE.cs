using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using System;
using UnityEngine;


public class EXE : MonoBehaviour
{
    // Start is called before the first frame update
    Process newprocess = new Process();
    ProcessStartInfo psi = new ProcessStartInfo();
    
    int state;
    public void execontroller(int state)
    {
        psi.FileName = "Assets\\Scripts\\Hand Tracking\\HandTrackingEXE\\Hand_Tracking_Module.exe";
        newprocess.StartInfo = psi;
        
        if (state == 1){
                newprocess.Start();
        }
        if (state == 0){
                string processName = "Hand_Tracking_Module"; // Replace with the actual process name or executable file name without the extension

                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    foreach (var process in processes)
                    {
                        try
                        {
                            process.Kill(); // Kill the process
                            Console.WriteLine($"Process {process.ProcessName} with ID {process.Id} has been terminated.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error terminating process: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"No process found with the name {processName}.");
                }
        }

    }
    

}