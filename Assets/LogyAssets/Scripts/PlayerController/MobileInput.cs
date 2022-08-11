using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MobileInput : MonoBehaviour{
    //Singleton
    static MobileInput singleton;
    MobileInput() {}

    bool onTouchUp;
    [SerializeField] bool onTouch;
    bool onTouchDown;

    Touch touch;
    static public Touch GetTouch() {return singleton.touch;}

    [SerializeField] Vector2 touchStartPosition;
    static public Vector2 GetTouchStartPosition() {return singleton.touchStartPosition;}

    [SerializeField] Vector2 touchPosition;
    static public Vector2 GetTouchPosition() {return singleton.touchPosition;}

    Vector2 lastPosition;

    [SerializeField] Vector2 touchDeltaPosition;
    static public Vector2 GetTouchDeltaPosition() {return singleton.touchDeltaPosition;}

    void Awake() {
        //Singleton
        if(singleton != null) {
            Debug.LogError("Mobile_Input must only one");
        }
        else singleton = this;
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
    void Update() {
        GetInput();
    }
}