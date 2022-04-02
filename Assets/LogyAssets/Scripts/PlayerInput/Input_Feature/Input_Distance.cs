using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Input_Distance {
    static private Vector2 differencePos;
    static public Vector2 Get_DifferencePos() {return differencePos;}
    private Vector2 show_differencePos;


    static private float dis;
    static public float Dis {get{return dis;}}
    private float show_dis;

    private void _Input_Distance() {
        if(Input.GetMouseButton(0)) {
            differencePos = Mobile_Input.Get_TouchPosition() - Mobile_Input.Get_TouchStartPosition();
            dis = Vector2.Distance(differencePos, Vector2.zero);
        }
        else if(Input.GetMouseButtonUp(0)) {
            differencePos = Vector2.zero;
            dis = 0f;
        }
    }

    private void ShowVariable() {
        show_differencePos = differencePos;
        show_dis = dis;
    }

    public void Main() {
        _Input_Distance();
        ShowVariable();
    }
}
