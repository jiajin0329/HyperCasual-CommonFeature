using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour {
    private void Awake() {
        Screen.SetResolution(1080, 2340, true);
        Application.targetFrameRate = 60;

        Debug.Log("set " + Application.targetFrameRate + "fps");
    }
}
