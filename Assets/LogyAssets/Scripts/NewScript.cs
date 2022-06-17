using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewScript : MonoBehaviour {
    //Singleton
    static NewScript Singleton;
    NewScript() {}

    void Start() {
        //Singleton
        if(Singleton != null) {
            Destroy(this);
            Debug.LogError("GoalDoor is instantiated");
        }
        else Singleton = this;
    }
}