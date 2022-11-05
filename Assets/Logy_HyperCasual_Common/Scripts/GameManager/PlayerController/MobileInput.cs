using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobileInput : MonoBehaviour {
    //Singleton
    static MobileInput singleton;
    public static MobileInput Get() {return singleton;}
    static bool singletonization;
    MobileInput() {}

    public bool touchDown;
    public bool touch;
    public bool touchUp;
    
    public UnityEvent TouchDownEvent;
    public UnityEvent TouchUpEvent;
    public UnityEvent TouchEvent;
    

    void Awake() {
        //Singleton
        singleton = null;
        singleton = this;
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            touchUp = false;
            touchDown = true;
        }
        else
            touchDown = false;
        
        if(Input.GetMouseButton(0))
            touch = true;

        if(Input.GetMouseButtonUp(0)) {
            touchDown = false;
            touch = false;
            touchUp = true;
        }
    }
}
