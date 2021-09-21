using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipeControl : MonoBehaviour {

    private bool tap, swipeleft, swiperight, swipeup, swipedown;
    private bool InDrag = false;
    private Vector2 StartTap, SwipeDelta;

    void Update()
    {
        tap = swipeleft = swiperight = swipeup = swipedown = false;

        #region StandaloneInputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            InDrag = true;
            StartTap = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {           
            InDrag = false;
            Reset();
        }

        #endregion

        #region MobileInput
        if (Input.touches.Length != 0) {
            if (Input.touches[0].phase == TouchPhase.Began)
            {//if there's only 1 finger touch
                tap = true;
                InDrag = true;
                StartTap = Input.touches[0].position; //coordinates the finger's position
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                InDrag = false;
                Reset();
            }
        }
        #endregion

        //Drag or swipe distance
        SwipeDelta = Vector2.zero;
        if (InDrag) {
            if (Input.touches.Length > 0)
            {
                SwipeDelta = Input.touches[0].position - StartTap;
            }
            else if (Input.GetMouseButton(0)) {
                SwipeDelta = (Vector2)Input.mousePosition - StartTap;
            }
        }

    }

    public void Reset() {
        StartTap = SwipeDelta = Vector2.zero;
    }

}
