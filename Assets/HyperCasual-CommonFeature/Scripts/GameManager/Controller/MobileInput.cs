using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobileInput : MonoBehaviour {
    //Singleton
    static MobileInput static_this;
    public static MobileInput Get() {return static_this;}
    MobileInput() {}

    public bool touch_down;
    public bool touch_stay;
    public bool touch_up;


    public Vector2 start_input_position;
    public Vector2 input_position;
    public Vector2 different_position;
    public float radian;
    public float distance;
    
    public UnityEvent TouchDownEvent;
    public UnityEvent TouchEvent;
    public UnityEvent TouchUpEvent;
    
    Touch touch;
    bool get_touch;

    void Awake() {
        static_this = null;
        static_this = this;

        TouchDownEvent.AddListener(StartInputPosition);
        TouchDownEvent.AddListener(Calculate);
        TouchEvent.AddListener(InputPosition);
        TouchEvent.AddListener(Calculate);
    }

    void Update() {
        TouchListener();
    }

    void TouchListener() {
        if(Input.touchCount > 0) {
            GetTouch();

            if(touch_stay) {
                touch_down = false;
                TouchEvent.Invoke();
                return;
            }

            get_touch = true;
            touch_down = true;
            touch_stay = true;
            TouchDownEvent.Invoke();
        }
        else {
            if(!get_touch) {
                touch_up = false;
                return;
            }

            get_touch = false;
            touch_stay = false;
            touch_up = true;
            TouchDownEvent.Invoke();
        }
    }
    void GetTouch() {
        touch = Input.GetTouch(Input.touchCount-1);
    }

    void StartInputPosition() {
        start_input_position = touch.position;
    }
    void InputPosition() {
        input_position = touch.position;
    }

    void Calculate() {
        //distance
        different_position = input_position - start_input_position;
        distance = Mathf.Pow(different_position.x*different_position.x + different_position.y*different_position.y, 0.5f);

        //angle
        radian = Mathf.Atan2(different_position.x, different_position.y);
    }
}
