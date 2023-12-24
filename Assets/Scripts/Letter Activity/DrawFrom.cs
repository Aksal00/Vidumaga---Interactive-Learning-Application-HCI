using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]

public class DrawFrom : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField]
    private float Width;

    [SerializeField]
    private float minDistance =0.1f;

    private bool isDragging;

    private Vector3 endPoint;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;
        line.startWidth = line.endWidth = Width;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z =0f;
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging =true;
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
        }
        if (isDragging)
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            line.SetPosition(index:1,currentPosition);
            endPoint = currentPosition;

        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(endPoint, Vector2.zero);
            
             
            //if(hit.collider != null && hit.collider.TryGetComponent(out objectMatchForm) && matchId == objectMatchForm.Get_ID())
            if(hit.collider != null)
            {
                
                this.enabled = false;
            }
            else
            {
                line.positionCount = 0;
                
            }
            line.positionCount = 2;
            
        }
    }
}
