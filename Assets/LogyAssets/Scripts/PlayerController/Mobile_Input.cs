using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mobile_Input : MonoBehaviour{
    //Singleton
    static Mobile_Input mobile_Input;
    Mobile_Input() {}

    static bool onTouchUp;
    static public bool Get_onTouchUp() {return onTouchUp;}

    static bool onTouch;
    static public bool Get_onTouch() {return onTouch;}
    [SerializeField] bool show_onTouch;

    static bool onTouchDown;
    static public bool Get_onTouchDown() {return onTouchDown;}

    static Touch touch;
    static public Touch Get_Touch() {return touch;}

    static Vector2 touchStartPosition;
    static public Vector2 Get_TouchStartPosition() {return touchStartPosition;}
    [SerializeField] Vector2 show_touchStartPosition;

    static Vector2 touchPosition;
    static public Vector2 Get_TouchPosition() {return touchPosition;}
    [SerializeField] Vector2 show_touchPosition;

    Vector2 lastPosition;

    static Vector2 touchDeltaPosition;
    static public Vector2 Get_TouchDeltaPosition() {return touchDeltaPosition;}
    [SerializeField] Vector2 show_touchDeltaPosition;

    void Start() {
        //Singleton
        if(mobile_Input != null) Debug.Log("Mobile_Input is instantiated");
        else mobile_Input = this;
    }

    void Update() {
        GetInput();
        ShowVariable();
    }

    void GetInput() {
        onTouchDown = Input.GetMouseButtonDown(0);
        onTouch = Input.GetMouseButton(0);
        onTouchUp = Input.GetMouseButtonUp(0);

        if(onTouchDown) {
            touchStartPosition = Input.mousePosition;
            lastPosition = touchStartPosition;
            /*
            #if UNITY_EDITOR
                touchStartPosition = Input.mousePosition;
            #else
                touch = Input.GetTouch(0);
                touchStartPosition = touch.position;
            #endif
            */
        }
        if(onTouch) {
            touchPosition = Input.mousePosition;
            touchDeltaPosition = touchPosition - lastPosition;
            lastPosition = touchPosition;

            /*
            #if UNITY_EDITOR
                
            #else
                touchPosition = touch.position;
                touchDeltaPosition = touch.deltaPosition;
            #endif
            */
        }
        if(onTouchUp) {
            touchStartPosition = Vector2.zero;
            touchPosition = Vector2.zero;
            touchDeltaPosition = Vector2.zero;
        }
    }

    void ShowVariable() {
        show_onTouch = onTouch;
        show_touchStartPosition = touchStartPosition;
        show_touchPosition = touchPosition;
        show_touchDeltaPosition = touchDeltaPosition;
    }
}