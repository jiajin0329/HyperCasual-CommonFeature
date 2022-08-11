using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Singleton : MonoBehaviour {
    //Singleton
    static Singleton singleton;
    Singleton() {}

    void Awake() {
        //Singleton
        if(singleton != null) {
            Debug.LogError("Singleton must only one");
        }
        else singleton = this;
    }
}