using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject targetButton;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click is over the target button
            if (IsMouseOverButton())
            {
                // Handle button click
                Debug.Log("Button clicked!");
            }
        }
    }

    bool IsMouseOverButton()
    {
        // Cast a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the collider belongs to the target button
            if (hit.collider.gameObject == targetButton)
            {
                return true;
            }
        }

        return false;
    }
}