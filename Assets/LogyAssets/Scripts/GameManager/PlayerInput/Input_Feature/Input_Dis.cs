using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Input_Dis {
    static private float  static_dis;
    static public float dis {get{return static_dis;}}
    [SerializeField] private float _dis;

    private void _Input_Dis() {
        static_dis = Vector2.Distance(Logy.Input.touchStartPosition, Logy.Input.touchPosition);
    }

    private void ShowVariable() {
        _dis = static_dis;;
    }

    public void Main() {
        _Input_Dis();
        ShowVariable();
    }
}
