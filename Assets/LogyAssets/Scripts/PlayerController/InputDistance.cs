using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputDistance : MonoBehaviour{
    //Singleton
    static InputDistance inputDistance;
    InputDistance() {}

    static Vector2 differencePos;
    static public Vector2 Get_DifferencePos() {return differencePos;}
    [SerializeField] Vector2 show_differencePos;

    static float dis;
    static public float Dis {get{return dis;}}
    [SerializeField] float show_dis;

    void Start() {
        //Singleton
        if(inputDistance != null) Debug.Log("Input_Distance is instantiated");
        else inputDistance = this;
    }

    void Update() {
        _Input_Distance();
        ShowVariable();
    }

    void _Input_Distance() {
        if(Mobile_Input.Get_onTouch()) {
            differencePos = Mobile_Input.Get_TouchPosition() - Mobile_Input.Get_TouchStartPosition();
            dis = Vector2.Distance(differencePos, Vector2.zero);
        }
        else if(Mobile_Input.Get_onTouchUp()) {
            differencePos = Vector2.zero;
            dis = 0f;
        }
    }

    void ShowVariable() {
        show_differencePos = differencePos;
        show_dis = dis;
    }
}
