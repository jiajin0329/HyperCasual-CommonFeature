using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logy
{
    [System.Serializable]
    public class Input {
        static private bool static_onTouch;
        static public bool onTouch {get{return static_onTouch;}}
        [SerializeField] private bool _onTouch;

        static private Touch  static_touch;
        static public Touch touch {get{return static_touch;}}

        static private Vector2  static_touchStartPosition;
        static public Vector2 touchStartPosition {get{return static_touchStartPosition;}}
        [SerializeField] private Vector2 _touchStartPosition;

        static private Vector2  static_touchPosition;
        static public Vector2 touchPosition {get{return static_touchPosition;}}
        [SerializeField] private Vector2 _touchPosition;

        static private Vector2  lastPosition;

        static private Vector2  static_touchDeltaPosition;
        static public Vector2 touchDeltaPosition {get{return static_touchPosition;}}
        [SerializeField] private Vector2 _touchDeltaPosition;

        private Input() {}

        private void GetInputPos() {
            if(UnityEngine.Input.GetMouseButtonDown(0)) {
                #if UNITY_EDITOR
                    static_touchStartPosition = UnityEngine.Input.mousePosition;
                #else
                    static_touch = UnityEngine.Input.GetTouch(0);
                    static_touchStartPosition = touch.position;
                #endif
            }
            else if(static_onTouch = UnityEngine.Input.GetMouseButton(0)) {
                #if UNITY_EDITOR
                    static_touchPosition = UnityEngine.Input.mousePosition;
                    static_touchDeltaPosition = static_touchPosition - lastPosition;
                    lastPosition = static_touchPosition;
                #else
                    static_touchPosition = touch.position;
                    static_touchDeltaPosition = touch.deltaPosition;
                #endif
            }
            else if(UnityEngine.Input.GetMouseButtonUp(0)) {
                lastPosition = Vector2.zero;
            }
        }

        private void ShowVariable() {
            _onTouch = static_onTouch;
            _touchStartPosition = static_touchStartPosition;
            _touchPosition = static_touchPosition;
            _touchDeltaPosition = static_touchDeltaPosition;
        }

        public void Main() {
            GetInputPos();
            ShowVariable();
        }
    }
}
