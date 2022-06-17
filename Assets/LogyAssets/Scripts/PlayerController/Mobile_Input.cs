using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mobile_Input : MonoBehaviour{
    //Singleton
    static Mobile_Input Singleton;
    Mobile_Input() {}

    bool onTouchUp;
    static public bool Get_onTouchUp() {return Singleton.onTouchUp;}

    [SerializeField] bool onTouch;
    static public bool Get_onTouch() {return Singleton.onTouch;}

    bool onTouchDown;
    static public bool Get_onTouchDown() {return Singleton.onTouchDown;}

    Touch touch;
    static public Touch Get_Touch() {return Singleton.touch;}

    [SerializeField] Vector2 touchStartPosition;
    static public Vector2 Get_TouchStartPosition() {return Singleton.touchStartPosition;}

    [SerializeField] Vector2 touchPosition;
    static public Vector2 Get_TouchPosition() {return Singleton.touchPosition;}

    Vector2 lastPosition;

    [SerializeField] Vector2 touchDeltaPosition;
    static public Vector2 Get_TouchDeltaPosition() {return Singleton.touchDeltaPosition;}

    void Awake() {
        //Singleton
        if(Singleton != null) {
            Destroy(this);
            Debug.LogError("Mobile_Input is instantiated");
        }
        else Singleton = this;
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