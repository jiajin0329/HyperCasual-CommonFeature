using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mobile_Input {
    private bool show_onTouch;

    static private Touch touch;
    static public Touch Get_Touch() {return touch;}

    static private Vector2 touchStartPosition;
    static public Vector2 Get_TouchStartPosition() {return touchStartPosition;}
    private Vector2 show_touchStartPosition;

    static private Vector2 touchPosition;
    static public Vector2 Get_TouchPosition() {return touchPosition;}
    private Vector2 show_touchPosition;

    static private Vector2 lastPosition;

    static private Vector2 touchDeltaPosition;
    static public Vector2 Get_TouchDeltaPosition() {return touchDeltaPosition;}
    private Vector2 show_touchDeltaPosition;

    private Mobile_Input() {}

    private void GetInputPos() {
        if(Input.GetMouseButtonDown(0)) {
            #if UNITY_EDITOR
                touchStartPosition = Input.mousePosition;
            #else
                touch = UnityEngine.Input.GetTouch(0);
                touchStartPosition = touch.position;
            #endif
        }
        else if(show_onTouch = Input.GetMouseButton(0)) {
            #if UNITY_EDITOR
                touchPosition = Input.mousePosition;
                touchDeltaPosition = touchPosition - lastPosition;
                lastPosition = touchPosition;
            #else
                _touchPosition = touch.position;
                static_touchDeltaPosition = touch.deltaPosition;
            #endif
        }
        else if(Input.GetMouseButtonUp(0)) {
            lastPosition = Vector2.zero;
            touchStartPosition = Vector2.zero;
            touchPosition = Vector2.zero;
            touchDeltaPosition = Vector2.zero;
        }
    }

    private void ShowVariable() {
        show_touchStartPosition = touchStartPosition;
        show_touchPosition = touchPosition;
        show_touchDeltaPosition = touchDeltaPosition;
    }

    public void Main() {
        GetInputPos();
        ShowVariable();
    }
}
