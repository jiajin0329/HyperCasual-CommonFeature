using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour {
    [SerializeField] Vector2Int resolution;
    [SerializeField] int fps;
    private void Awake() {
        Screen.SetResolution(resolution.x, resolution.y, true);
        Application.targetFrameRate = fps;

        Debug.Log("set " + Application.targetFrameRate + "fps");
    }
}
