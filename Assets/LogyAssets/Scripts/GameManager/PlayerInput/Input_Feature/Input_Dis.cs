using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Input_Dis {
    static private Vector2  static_differencePos;
    static public Vector2 differencePos {get{return static_differencePos;}}
    [SerializeField] private Vector2 _differencePos;


    static private float  static_dis;
    static public float dis {get{return static_dis;}}
    [SerializeField] private float _dis;

    private void _Input_Dis() {
        static_differencePos = Logy.Input.touchPosition - Logy.Input.touchStartPosition;
        static_dis = Vector2.Distance(static_differencePos, Vector2.zero);
    }

    private void ShowVariable() {
        _differencePos = static_differencePos;
        _dis = static_dis;;
    }

    public void Main() {
        _Input_Dis();
        ShowVariable();
    }
}
