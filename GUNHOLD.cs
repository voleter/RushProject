using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    private bool isHolding = false;
    private Transform heldObject;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Check for the "5" key press
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            RaycastHit hitInfo;

            // Check if we hit an object
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                heldObject = hitInfo.transform;
                isHolding = true;

                // Store the last mouse position for smooth movement
                lastMousePosition = Input.mousePosition;
            }
        }

        // Check if we're holding an object
        if (isHolding)
        {
            // Check for mouse button release
            if (Input.GetMouseButtonUp(0))
            {
                isHolding = false;
                heldObject = null;
            }
            else
            {
                // Move the object based on mouse movement
                Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
                heldObject.Translate(deltaMousePosition * Time.deltaTime, Space.World);

                // Update the last mouse position
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}
