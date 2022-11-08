using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticClass : MonoBehaviour {
    static StaticClass static_this;
    public static StaticClass Get() {return static_this;}
    StaticClass() {}

    void Awake() {
        static_this = null;
        static_this = this;
    }
}