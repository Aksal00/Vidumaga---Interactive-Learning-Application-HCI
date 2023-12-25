using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class DrawWithMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField]
    private float Width = 1.0f;
    /*[SerializeField]
    private GameObject object1;
    [SerializeField]
    private GameObject object2;
    [SerializeField]
    private Image arrowimg;*/
    

    [SerializeField]
    private float minDistance =0.1f;
    public void Start()
    {
        
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;
        line.startWidth = line.endWidth = Width;

    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z =0f;
            
            
            
                
            if(Vector3.Distance(currentPosition,previousPosition)> minDistance)
            {
                if(previousPosition == transform.position)
                {
                    line.SetPosition(0, currentPosition);

                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount-1,currentPosition);
                    
                }
                previousPosition = currentPosition;
            

            }
            
            
        }
        if(Input.GetMouseButtonDown(0)){
            Start();
        }
    }
    
    
}
