using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {
    //Singleton
    static Singleton singleton;
    public static Singleton Get() {return singleton;}
    static bool singletonization;
    Singleton() {}

    void Awake() {
        //Singleton
        if(!singletonization) {
            singletonization = true;
            singleton = this;
        }
    }
}