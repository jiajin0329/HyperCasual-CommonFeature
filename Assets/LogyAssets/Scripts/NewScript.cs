using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewScript : MonoBehaviour{
    //Singleton
    static NewScript _this;
    NewScript() {}

    void Start() {
        //Singleton
        if(_this != null) {
            Destroy(this);
            Debug.LogError("NewScript is Singleton");
        }
        else _this = this;
    }
}