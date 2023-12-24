using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawWithMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField]
    private float Width;

    [SerializeField]
    private float minDistance =0.1f;
    private void Start()
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
    }
}
