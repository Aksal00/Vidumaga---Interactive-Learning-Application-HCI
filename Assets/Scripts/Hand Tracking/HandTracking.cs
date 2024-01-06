using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;
using System;
using Unity.Mathematics;

//using UnityEditor.Scripting.Python;
//using System.IO;
public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const int MOUSEEVENTF_LEFTUP = 0x0004;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        string data = udpReceive.data;
        data = data.Remove(0,1);
        data = data.Remove(data.Length-1,1);
        print(data);
        string[] points =data.Split(',');

        for(int i=0; i<21; i++){

            float x=float.Parse(points[i*3]);
            float y=float.Parse(points[i*3+1]);
            float z=float.Parse(points[i*3+2]);
            handPoints[i].transform.localPosition = new Vector3(x,y,z);
            
            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int X, int Y);
            
            int xPos = (int.Parse(points[24])); 
            int yPos = (1080-(int.Parse(points[25])));
            SetCursorPos(xPos,yPos);
            
            int xPos2=(int.Parse(points[12]));
            int yPos2=(1080-(int.Parse(points[13])));

            int xlen = xPos2-xPos;
            int ylen = yPos- yPos2;
            
            int xlensqr = xlen*xlen;
            int ylensqr = ylen*ylen;

            double len = Math.Sqrt(xlensqr+ylensqr);

            if(len<60)
            {
                
                mouse_event(MOUSEEVENTF_LEFTDOWN , (uint)xPos, (uint)yPos, 0, 0);
                
                Console.Write("Clicked");
            }
            else{
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)xPos, (uint)yPos, 0, 0);
            }
            

        }
        

        
        
    }

    

}
