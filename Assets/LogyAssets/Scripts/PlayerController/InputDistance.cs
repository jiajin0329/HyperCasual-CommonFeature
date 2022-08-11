using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputDistance : MonoBehaviour{
    //Singleton
    static InputDistance singleton;
    InputDistance() {}

    [SerializeField] Vector2 differencePos;
    static public Vector2 GetDifferencePos() {return singleton.differencePos;}

    [SerializeField] float distance;
    static public float GetDistance() {return singleton.distance;}

    void Awake() {
        //Singleton
        if(singleton != null) {
            Debug.LogError("InputDistance must only one");
        }
        else singleton = this;
    }

    void Update() {
        _InputDistance();
    }

    void _InputDistance() {
        if(Input.GetMouseButton(0)) {
            differencePos = MobileInput.GetTouchPosition() - MobileInput.GetTouchStartPosition();
            distance = Vector2.Distance(differencePos, Vector2.zero);
        }
        else if(Input.GetMouseButtonUp(0)) {
            differencePos = Vector2.zero;
            distance = 0f;
        }
    }
}
