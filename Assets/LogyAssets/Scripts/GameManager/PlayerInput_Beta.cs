using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_Beta : MonoBehaviour {
    static private bool static_touching;
    static public bool touching {get{return static_touching;}}
    [SerializeField] private bool _touching;

    static private bool static_touchDown;
    static public bool touchDown {get{return static_touchDown;}}
    [SerializeField] private bool _touchDown;

    static private bool static_touchUp;
    static public bool touchUp {get{return static_touchUp;}}
    [SerializeField] private bool _touchUp;

    static private float  static_touchTime;
    static public float touchTime {get{return static_touchTime;}}
    [SerializeField] private Vector2 _touchTime;

    static private Touch  static_touch;
    static public Touch touch {get{return static_touch;}}
    
    static private Vector2  static_touchPosition;
    static public Vector2 touchPosition {get{return static_touchPosition;}}
    [SerializeField] private Vector2 _touchPosition;

    static private Vector2  lastPosition;

    static private Vector2  static_touchDeltaPosition;
    static public Vector2 touchDeltaPosition {get{return static_touchDeltaPosition;}}
    [SerializeField] private Vector2 _touchDeltaPosition;



    private void Update() {
        SetVariable();
        ShowVariable();
    }

    private void SetVariable() {
        if(static_touching = Input.GetMouseButton(0)) {
            //touchTime
            if(static_touchDown = Input.GetMouseButtonDown(0)) {
                static_touchTime = 0f;
            }

            //touchPosition
            #if UNITY_EDITOR
                if(static_touching) {
                    static_touchPosition = Input.mousePosition;
                    static_touchDeltaPosition = static_touchPosition - lastPosition;
                    lastPosition = static_touchPosition;
                }
            #else
                static_touch = Input.GetTouch(0);
                static_touchPosition = touch.position;
                static_touchDeltaPosition = touch.deltaPosition;
            #endif

            
        }
        else if(Input.GetMouseButton(0)) {

        }
    }

    private void ShowVariable() {
        _touching = static_touching;
        _touchPosition = static_touchPosition;
        _touchDeltaPosition = static_touchDeltaPosition;
    }
}