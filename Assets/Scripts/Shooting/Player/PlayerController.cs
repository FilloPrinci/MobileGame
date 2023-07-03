using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Camera camera;
    public Transform DebugTouchPosition;
    public float lerpSpeed;

    private Vector3 touchPoint;
    private Vector3 touchedPos;
    private bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        touchedPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            int id = touch.fingerId;
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(id))
            {
                // ui touched
            }
            else {
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {

                    float depth = Vector3.Distance(transform.position, camera.transform.position);

                    touchPoint = new Vector3(touch.position.x, touch.position.y, depth);

                }
            }

           
        }

        SetTouchWorldPosition();

        if (Vector3.Distance(transform.position, touchedPos) > 0.1 && shouldMove)
        {
            // lerp and set the position of the current object to that of the touch, but smoothly over time.
            transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * lerpSpeed);
        }
        else {
            shouldMove = false;
        }
        
    }

    void SetTouchWorldPosition() {
        // set the touch position from the screen touch to world point
        touchedPos = camera.ScreenToWorldPoint(touchPoint);
        DebugTouchPosition.position = touchedPos;
        touchedPos.y = transform.position.y;
        shouldMove = true;
    }
}
