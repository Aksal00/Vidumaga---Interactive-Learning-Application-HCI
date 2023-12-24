using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Unity.VisualScripting;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class ObjectMatchingGame1 : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int matchId;
    private bool isDragging;
    private Vector3 endPoint;
    private ObjectMatchingForm objectMatchForm;

    [SerializeField]private GameObject complete_screen;

    [SerializeField]private GameObject try_again_screen;
    public static int i = 0;
    public static int y = 0;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;     
    }
    private void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging =true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                lineRenderer.SetPosition(index:0,mousePosition);
            }
        
        }
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            lineRenderer.SetPosition(index:1,mousePosition);
            endPoint = mousePosition;

        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(endPoint, Vector2.zero);
            
             
            //if(hit.collider != null && hit.collider.TryGetComponent(out objectMatchForm) && matchId == objectMatchForm.Get_ID())
            if(hit.collider != null && hit.collider.TryGetComponent(out objectMatchForm))
            {
                
                this.enabled = false;
                if( matchId == objectMatchForm.Get_ID()){
                    i++;
                    y++;
                    Debug.Log(message:"i = "+i);
                }
                else{
                    Debug.Log(message:"Incorrect Form!");
                    lineRenderer.positionCount = 2;
                    y++;

                }
                result_display(y,i);


            }
            else
            {
                lineRenderer.positionCount = 0;
                
            }
            lineRenderer.positionCount = 2;
            
        }


    }
    public void result_display(int a,int b){
        
        if (a==4 && b==4){
            Debug.Log(message:"Correct Form!");
            y=0;
            i=0;
            complete_screen.SetActive(true);
            
        }else if(a==4 && b<4){
            Debug.Log(message:"Something went wrong!");
            y=0;
            i=0;
            try_again_screen.SetActive(true);
            
        }

    }
    


}
