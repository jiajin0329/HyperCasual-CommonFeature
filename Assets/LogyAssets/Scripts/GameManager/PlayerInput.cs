using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    static private PlayerInput playerInput;
    private PlayerInput(){}

    static private bool static_onTouch;
    static public bool onTouch {get{return static_onTouch;}}
    [SerializeField] private bool _onTouch;

    static private Touch  static_touch;
    static public Touch touch {get{return static_touch;}}
    
    static private Vector2  static_touchPosition;
    static public Vector2 touchPosition {get{return static_touchPosition;}}
    [SerializeField] private Vector2 _touchPosition;

    static private Vector2  lastPosition;

    static private Vector2  static_touchDeltaPosition;
    static public Vector2 touchDeltaPosition {get{return static_touchPosition;}}
    [SerializeField] private Vector2 _touchDeltaPosition;

    private void Awake() {
        if(playerInput != null) print("this scene have same class");
        else playerInput = this;
    }

    private void Update() {
        playerInput.SetVariable();
        playerInput.ShowVariable();
    }

    private void SetVariable() {
        static_onTouch = Input.GetMouseButton(0);
        
        #if UNITY_EDITOR
            if(static_onTouch) {
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

    private void ShowVariable() {
        _onTouch = static_onTouch;
        _touchPosition = static_touchPosition;
        _touchDeltaPosition = static_touchDeltaPosition;
    }
}