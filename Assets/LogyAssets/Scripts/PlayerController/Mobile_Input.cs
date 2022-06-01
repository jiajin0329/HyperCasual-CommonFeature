using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mobile_Input : MonoBehaviour{
    //Singleton
    static Mobile_Input mobile_Input;
    Mobile_Input() {}

    bool onTouchUp;
    static public bool Get_onTouchUp() {return mobile_Input.onTouchUp;}

    [SerializeField] bool onTouch;
    static public bool Get_onTouch() {return mobile_Input.onTouch;}

    bool onTouchDown;
    static public bool Get_onTouchDown() {return mobile_Input.onTouchDown;}

    Touch touch;
    static public Touch Get_Touch() {return mobile_Input.touch;}

    [SerializeField] Vector2 touchStartPosition;
    static public Vector2 Get_TouchStartPosition() {return mobile_Input.touchStartPosition;}

    [SerializeField] Vector2 touchPosition;
    static public Vector2 Get_TouchPosition() {return mobile_Input.touchPosition;}

    Vector2 lastPosition;

    [SerializeField] Vector2 touchDeltaPosition;
    static public Vector2 Get_TouchDeltaPosition() {return mobile_Input.touchDeltaPosition;}

    void Start() {
        //Singleton
        if(mobile_Input != null) {
            Destroy(this);
            Debug.LogError("Mobile_Input is instantiated");
        }
        else mobile_Input = this;
    }

    void Update() {
        GetInput();
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
}